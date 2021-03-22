import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NgbdTimepicker } from './timepicker';

@NgModule({
  imports: [BrowserModule, FormsModule, NgbModule],
  declarations: [NgbdTimepicker],
  exports: [NgbdTimepicker],
  bootstrap: [NgbdTimepicker]
})
export class NgbdTimepickerModule {}
