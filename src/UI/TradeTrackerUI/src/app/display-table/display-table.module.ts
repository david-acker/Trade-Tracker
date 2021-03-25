import { BrowserModule } from '@angular/platform-browser';
import { DisplayTableComponent } from './display-table.component';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    BrowserModule,
    NgbModule,
  ],
  declarations: [DisplayTableComponent],
  exports: [DisplayTableComponent],
  bootstrap: [DisplayTableComponent]
})
export class DisplayTableModule { }
