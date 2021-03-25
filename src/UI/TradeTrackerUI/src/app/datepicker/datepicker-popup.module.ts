import { BrowserModule } from '@angular/platform-browser';
import { faCalendar as farCalendar } from '@fortawesome/free-regular-svg-icons';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NgbdDatepickerPopup } from './datepicker-popup';

@NgModule({
  imports: [
    BrowserModule,
    FontAwesomeModule, 
    FormsModule, 
    NgbModule,
    ReactiveFormsModule
  ],
  declarations: [NgbdDatepickerPopup],
  exports: [NgbdDatepickerPopup],
  bootstrap: [NgbdDatepickerPopup]
})
export class NgbdDatepickerPopupModule {
  constructor(private library: FaIconLibrary) {
    library.addIcons(farCalendar);
  }
}
