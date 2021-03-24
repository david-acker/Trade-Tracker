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

    displayedColumns: string[] = ['dateTime', 'symbol', 'type', 'quantity', 'notional', 'tradePrice'];

    transactionsFilters: FormGroup;

    resourceParameters: PagedTransactionsParameters;

    response: PagedTransactionsWithLinks;
    transactions: TransactionWithLinks[] = [];

    pageNumber: number = 1;
    pageSize: number = 10;
    pageCount: number;

    sortDirection: string = 'desc';
    sortDirectionName: string = 'Descending';

    constructor (private data: DataService, private fb: FormBuilder) { 
        this.resourceParameters = new PagedTransactionsParameters();
        this.getPageData();
    }

    ngOnInit(): void {
        this.transactionsFilters = this.fb.group({
            dateRange: this.fb.group({
                start: [''],
                end: ['']
            }, { validator: dateRangeChecker }),
            orderBy: 'DateTime'
        });
    }

    onUpdate(): void {
        this.resourceParameters.rangeStart = parseDateInput(
            this.transactionsFilters.get(['dateRange', 'start']).value);
        
        this.resourceParameters.rangeEnd = parseDateInput(
            this.transactionsFilters.get(['dateRange', 'end']).value);

        let orderBy = this.transactionsFilters.get('orderBy').value;
        this.resourceParameters.order = orderBy + '+' + this.sortDirection;

        this.getPageData();
    }

    onPageChange(pageNumber: number): void {
        this.resourceParameters.pageNumber = pageNumber;
        this.getPageData();
    }

    reverseDirection(): void {
        if (this.sortDirection == 'desc') {
            this.sortDirection = 'asc';
            this.sortDirectionName = 'Ascending';
        } else {
            this.sortDirection = 'desc';
            this.sortDirectionName = 'Descending';
        }
    }

    private getPageData(): void {
        console.log(this.resourceParameters);

        this.data.getPagedTransactionsWithLinks(this.resourceParameters)
            .subscribe(success => {
                this.response = this.data.pagedTransactionsWithLinks;
                this.transactions = this.response.items;
                
                this.pageNumber = this.response.metadata.pageNumber;
                this.pageSize = this.response.metadata.pageSize;
                this.pageCount = this.response.metadata.pageCount;
            })
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
    } else {
        return null;
    }
}