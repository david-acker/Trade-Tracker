import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NavMenuComponent } from './nav-menu.component';

@NgModule({
  declarations: [NavMenuComponent],
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule,
    NgbModule
  ]
})
export class NavMenuModule { }
