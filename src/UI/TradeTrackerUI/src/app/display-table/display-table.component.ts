import { Component, forwardRef, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { TransactionWithLinks } from '../models/transactions/transaction-with-links';

@Component({
  selector: 'display-table',
  templateUrl: './display-table.component.html',
  styleUrls: ['./display-table.component.css']
})
export class DisplayTableComponent {
    @Input() isLoading: boolean = true;
    @Input() transactions: TransactionWithLinks[] = [];
}
