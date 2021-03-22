import { Component, forwardRef, OnDestroy } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'ngbd-timepicker',
    templateUrl: './timepicker.html',
    styleUrls: ['./timepicker.css'],
    providers: [
      {
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => NgbdTimepicker),
        multi: true
      }
    ]
})
export class NgbdTimepicker implements ControlValueAccessor, OnDestroy {
  time: NgbTimeStruct = {hour: 0, minute: 0, second: 0};
  seconds = true;

  input = new FormControl();

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

