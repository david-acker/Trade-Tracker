import { CommonModule } from '@angular/common';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faSlidersH as fasSlidersH, 
         faSortAmountDown as fasSortAmountDown, 
         faSortAmountUp as fasSortAmountUp } from '@fortawesome/free-solid-svg-icons';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';

import { TransactionListComponent } from './transactions-list/transaction-list.component';
import { NgbdDatepickerPopupModule } from '../datepicker/datepicker-popup.module';
import { BrowserModule } from '@angular/platform-browser';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';
import { AuthGuard } from '../core/auth-guard.service';
import { DisplayTableModule } from '../display-table/display-table.module';

let routes = [
  {
    path: 'transactions', 
    children: [
      {
        path: 'add',
        component: AddTransactionComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'view',
        component: TransactionListComponent,
        canActivate: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  declarations: [
    AddTransactionComponent,
    TransactionListComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    DisplayTableModule,
    FormsModule,
    FontAwesomeModule,
    MatTableModule,
    NgbModule,
    NgbdDatepickerPopupModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ]
})
export class TransactionsModule { 
  constructor(private library: FaIconLibrary) {
    library.addIcons(
      fasSlidersH, 
      fasSortAmountDown, 
      fasSortAmountUp);
  }
}
