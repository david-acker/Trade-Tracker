import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, AbstractControl } from '@angular/forms';

import { DataService } from '../../core/data.service';
import { PagedTransactionsParameters } from '../../models/transactions/paged-transactions-parameters';
import { PagedTransactionsWithLinks } from '../../models/transactions/paged-transactions-with-links';
import { TransactionWithLinks } from '../../models/transactions/transaction-with-links';

@Component({
    templateUrl: './transaction-list.component.html',
    styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {
    private errorMessage: string = '';
    private resourceParameters: PagedTransactionsParameters = 
        new PagedTransactionsParameters();

    public transactionFilters: FormGroup;

    response: PagedTransactionsWithLinks;
    transactions: TransactionWithLinks[] = [];

    pageNumber: number = 1;
    pageSize: number = 10;
    pageSizes: number[] = [ 10, 25, 50, 100 ];
    pageCount: number;
    totalRecordCount: number;

    sortDirection: string = 'desc';
    sortDirectionName: string = 'Descending';

    displayedColumns: string[] = [
        'dateTime', 'symbol', 'type', 
        'quantity', 'notional', 'tradePrice'];

    constructor (
        private data: DataService, 
        private fb: FormBuilder) {
        this.getPageData();
    }

    ngOnInit(): void {
        this.transactionFilters = this.fb.group({
            type: 'Any',
            orderBy: 'DateTime',
            dateRange: this.fb.group({
                start: ['', [isValidDate]],
                end: ['', [isValidDate]]
            }, { validators: dateRangeValidator }),
            selection: this.fb.group({
                including: ['', [commaSeparatedValidator]],
                excluding: ['', [commaSeparatedValidator]]
            })
        });
    }

    public isFieldEmpty(field: string): boolean {
        const fieldValue = this.transactionFilters.get(['selection', field]).value;
        
        return fieldValue == '' || fieldValue == null;
    }

    public onSelectionChange(updatedFieldName: string): void {
        let correspondingFieldName: string;

        if (updatedFieldName == 'including') {
            correspondingFieldName = 'excluding';
        } else {
            correspondingFieldName = 'including';
        }

        let correspondingControl: AbstractControl = 
            this.transactionFilters.get(['selection', correspondingFieldName]);

        if (!this.isFieldEmpty(updatedFieldName)) {
            if (!correspondingControl.disabled) {
                correspondingControl.disable();
            }
        } else {
            if (correspondingControl.disabled) {
                correspondingControl.enable();
            }
        }
    }

    public onUpdate(): void {
        const type: string = this.transactionFilters.get('type').value;

        if (type == 'Any') {
            this.resourceParameters.type = '';
        } else {
            this.resourceParameters.type = type;
        }

        const orderBy: string = 
            this.transactionFilters.get('orderBy').value;
        this.resourceParameters.order = orderBy + '+' + this.sortDirection;

        const startDateString: string = 
            this.transactionFilters.get(['dateRange', 'start']).value;
        if (startDateString != null && startDateString != '') {
            this.resourceParameters.rangeStart = 
                parseDateInputToISO(startDateString);
        } else {
            this.resourceParameters.rangeStart = null;
        }

        const endDateString: string = 
            this.transactionFilters.get(['dateRange', 'end']).value;
        if (endDateString != null && endDateString != '') {
            this.resourceParameters.rangeEnd = 
                parseDateInputToISO(endDateString);
        } else {
            this.resourceParameters.rangeEnd = null;
        }

        this.resourceParameters.selection = null;

        if (!this.isFieldEmpty('including')) {
            const symbols: string = 
                this.transactionFilters.get(['selection', 'including']).value;

            this.resourceParameters.selection = symbols + '+' + 'Include';
        } 

        if (!this.isFieldEmpty('excluding')) {
            const symbols: string = 
                this.transactionFilters.get(['selection', 'excluding']).value;

            this.resourceParameters.selection = symbols + '+' + 'Exclude';
        } 

        console.log(this.resourceParameters);

        this.getPageData();
    }

    public onPageChange(pageNumber: number): void {
        this.resourceParameters.pageNumber = pageNumber;
        this.getPageData();
    }

    public onPageSizeChange(event: any): void {
        let pageSize = event.target.value;
        this.resourceParameters.pageSize = pageSize;
        this.getPageData();
    }

    public reverseDirection(): void {
        if (this.sortDirection == 'desc') {
            this.sortDirection = 'asc';
            this.sortDirectionName = 'Ascending';
        } else {
            this.sortDirection = 'desc';
            this.sortDirectionName = 'Descending';
        }
    }

    private getPageData(): void {
        this.errorMessage = '';

        this.data.getPagedTransactionsWithLinks(this.resourceParameters)
            .subscribe(success => {
                this.response = this.data.pagedTransactionsWithLinks;
                this.transactions = this.response.items;
                
                this.pageNumber = this.response.metadata.pageNumber;
                this.pageSize = this.response.metadata.pageSize;
                this.pageCount = this.response.metadata.pageCount;
                this.totalRecordCount = this.response.metadata.totalRecordCount;
            }, error => {
                this.errorMessage = 'An error occurred while loading the transactions'
            });
    }
}

function dateRangeValidator(c: AbstractControl): { [key: string]: boolean } | null {
    const startControl = c.get('start');
    const endControl = c.get('end');

    if (startControl.pristine || endControl.pristine) {
        return null;
    }

    const startDateString = startControl.value;
    const endDateString = endControl.value;

    if ((startDateString == '' || startDateString == null) &&
        (endDateString == '' || endDateString == null)) {
        return null;
    }

    const isValidStartDate = isValidDate(startDateString);
    const isValidEndDate = isValidDate(endDateString);

    if (!isValidStartDate && !isValidEndDate) {
        return null;
    }

    const startDate = new Date(parseDateInput(startDateString));
    const endDate = new Date(parseDateInput(endDateString));
    
    if (startDate < endDate) {
        return null;
    }

    return { dateRangeValidator: true };
}

function isValidDate(input: any): boolean | null {
    if (input !== null && input !== '') {
        const year = Number(input.year);
        const month = Number(input.month);
        const day = Number(input.day);

        if (isNaN(year) || isNaN(month) || isNaN(day)) {
            return false;
        }

        const date = new Date(year, month - 1, day);

        return date instanceof Date && !isNaN(date.valueOf());
    }

    return true;
}

function commaSeparatedValidator(control: AbstractControl): {[key: string]: boolean} | null {
    const input: string = control.value;
    if (input != null && input != '') {
        let splitString: string[] = (input.split(','));

        const regex = /[^a-zA-Z\d.:]/;

        let isValid = true;
        splitString.forEach(element => {
            if (element.match(regex) != null) {
                isValid = false;
            }
        });

        return !isValid 
            ? { commaSeparatedValidator: true } 
            : null;
    }

    return null;
}

function parseDateInput(input: any): Date {
    const year = Number(input.year);
    const month = Number(input.month);
    const day = Number(input.day);

    return new Date(year, month - 1, day);
}

function parseDateInputToISO(input: any): string {
    const date = new Date(parseDateInput(input));

    return date.toISOString();
}