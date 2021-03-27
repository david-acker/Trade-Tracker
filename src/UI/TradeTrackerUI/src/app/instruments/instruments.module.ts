import { AuthGuard } from '../core/auth-guard.service';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { InstrumentDetailComponent } from './instrument-detail/instrument-detail.component';
import { InstrumentTransactionsListDisplayTableComponent } from './instrument-transactions-list-display-table/instrument-transactions-list-display-table.component';

let routes = [
  { path: 'instruments/:symbol', 
    component: InstrumentDetailComponent, 
    canActivate: [AuthGuard] }
];

@NgModule({
  declarations: [
    InstrumentDetailComponent,
    InstrumentTransactionsListDisplayTableComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class InstrumentsModule { }
