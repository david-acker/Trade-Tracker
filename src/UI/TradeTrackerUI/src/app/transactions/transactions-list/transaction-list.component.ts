import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidatorFn, FormArray } from '@angular/forms';

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
    pageCount: number;

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
                start: [''],
                end: ['']
            }, { validator: dateRangeChecker })
        });
    }

    public onUpdate(): void {
        let type: string = this.transactionFilters.get('type').value;

        if (type == 'Any') {
            this.resourceParameters.type = '';
        } else {
            this.resourceParameters.type = type;
        }

        let orderBy: string = this.transactionFilters.get('orderBy').value;
        this.resourceParameters.order = orderBy + '+' + this.sortDirection;

        this.resourceParameters.rangeStart = parseDateInput(
            this.transactionFilters.get(['dateRange', 'start']).value);
        
        this.resourceParameters.rangeEnd = parseDateInput(
            this.transactionFilters.get(['dateRange', 'end']).value);

        console.log(this.resourceParameters);

        this.getPageData();
    }

    public onPageChange(pageNumber: number): void {
        this.resourceParameters.pageNumber = pageNumber;
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
            }, error => {
                this.errorMessage = 'An error occurred while loading the transactions'
            });
    }
}

function dateRangeChecker(c: AbstractControl): { [key: string]: boolean } | null {
    const startControl = c.get('start');
    const endControl = c.get('end');

    if (startControl.pristine || endControl.pristine) {
        return null;
    }

    let startDate = new Date(startControl.value);
    let endDate = new Date(endControl.value);

    if (startDate > endDate) {
        return null;
    }

    return { startBeforeEnd: true };
}

function parseDateInput(input: any): string | null {
    if (input !== null && input !== '') {
        let date = new Date(
            input.year, 
            input.month, 
            input.day);
        return date.toISOString();
    }

    return null;
}