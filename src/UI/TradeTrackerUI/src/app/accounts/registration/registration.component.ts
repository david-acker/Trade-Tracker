import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/data.service';
import { Registration } from 'src/app/models/accounts/registration';

@Component({
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public registrationForm: FormGroup;

  errorMessage: string = '';

  constructor(
    private data: DataService,
    private fb: FormBuilder, 
    private router: Router) { }

  ngOnInit(): void {
    this.registrationForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onRegister() {
      this.errorMessage = '';

      let registration: Registration = this.registrationForm.value;
      
      this.data.register(registration)
          .subscribe(success => {
              if (success) {
                  this.router.navigate(['Login']);
              }
          }, err => this.errorMessage = 'Failed to register');
  }
}