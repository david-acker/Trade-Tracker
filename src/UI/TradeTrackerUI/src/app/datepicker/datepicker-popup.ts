import { Component, forwardRef, Input, OnDestroy, Output } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'ngbd-datepicker-popup',
  templateUrl: './datepicker-popup.html',
  styleUrls: ['./datepicker-popup.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => NgbdDatepickerPopup),
      multi: true
    }
  ]
})
export class NgbdDatepickerPopup implements ControlValueAccessor, OnDestroy {
  
  input = new FormControl(new Date());

  subscriptions = []; 

  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(input: Date | null): void {
    if (input !== null) {
      this.input.setValue(input);
    }
  }

  registerOnChange(fn: any): void {
    this.subscriptions.push(
      this.input.valueChanges.subscribe(fn));
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
}
