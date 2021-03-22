import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/data.service';
import { TransactionForCreation } from 'src/app/models/transaction-for-creation';

@Component({
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})
export class AddTransactionComponent implements OnInit {
  
  transactionForCreation: TransactionForCreation;
  transactionForm: FormGroup;

  constructor(
    private data: DataService, 
    private fb: FormBuilder) { 
    this.transactionForCreation = new TransactionForCreation();
  }

  ngOnInit(): void {
    this.transactionForm = this.fb.group({
      date: ['', [Validators.required]],
      time: ['', [Validators.required]],
      symbol: ['', [Validators.required]],
      type: ['', [Validators.required]],
      quantity: ['', [Validators.required]],
      notional: ['', [Validators.required]],
      tradePrice: ['', [Validators.required]]
    });
  }

  public onSubmit(): void {
    let date = this.transactionForm.get('date').value;
    let time = this.transactionForm.get('time').value;

    let dateTime = new Date(
      date.year,
      date.month - 1,
      date.day,
      time.hour,
      time.minute,
      time.second);

    this.transactionForCreation.dateTime = dateTime.toISOString();
    this.transactionForCreation.symbol = this.transactionForm.get('symbol').value;
    this.transactionForCreation.type = this.transactionForm.get('type').value;
    this.transactionForCreation.quantity = this.transactionForm.get('quantity').value;
    this.transactionForCreation.notional = this.transactionForm.get('notional').value;
    this.transactionForCreation.tradePrice = this.transactionForm.get('tradePrice').value;

    console.log(this.transactionForCreation);

    this.data.addTransaction(this.transactionForCreation)
      .subscribe(success => {
        this.transactionForm.reset();
      });
  }
}