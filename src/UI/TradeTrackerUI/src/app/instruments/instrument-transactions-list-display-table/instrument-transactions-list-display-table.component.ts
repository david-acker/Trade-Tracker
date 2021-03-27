import { Component, Input } from '@angular/core';
import { TransactionWithLinks } from '../../models/transactions/transaction-with-links';

@Component({
  selector: 'instrument-transactions-list-display-table',
  templateUrl: './instrument-transactions-list-display-table.component.html',
  styleUrls: ['./instrument-transactions-list-display-table.component.css']
})
export class InstrumentTransactionsListDisplayTableComponent {
    @Input() isLoading: boolean = true;
    @Input() transactions: TransactionWithLinks[] = [];
}
