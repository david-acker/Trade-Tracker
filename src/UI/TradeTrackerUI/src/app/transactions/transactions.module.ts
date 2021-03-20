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

let routes = [
  { path: 'transactions', component: TransactionListComponent },
]

@NgModule({
  declarations: [
    TransactionListComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    FontAwesomeModule,
    MatTableModule,
    NgbModule,
    ReactiveFormsModule,
    NgbdDatepickerPopupModule,
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
