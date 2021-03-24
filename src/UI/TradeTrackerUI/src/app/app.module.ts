import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AccountsModule } from './accounts/accounts.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard } from './core/auth-guard.service';
import { AuthService } from './core/auth.service';
import { DataService } from './core/data.service';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgbdDatepickerPopupModule } from './datepicker/datepicker-popup.module';
import { PositionsModule } from './positions/positions.module';
import { TransactionsModule } from './transactions/transactions.module';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    AppRoutingModule,
    AccountsModule,
    BrowserModule,
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    TransactionsModule,
    BrowserAnimationsModule,
    NgbdDatepickerPopupModule,
    PositionsModule,
  ],
  providers: [
    AuthGuard,
    DataService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
