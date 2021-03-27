import { Component, Input } from '@angular/core';
import { TransactionWithLinks } from '../../models/transactions/transaction-with-links';

@Component({
  selector: 'transactions-list-display-table',
  templateUrl: './transactions-list-display-table.component.html',
  styleUrls: ['./transactions-list-display-table.component.css']
})
export class TransactionsListDisplayTableComponent {
    @Input() isLoading: boolean = true;
    @Input() transactions: TransactionWithLinks[] = [];
}
