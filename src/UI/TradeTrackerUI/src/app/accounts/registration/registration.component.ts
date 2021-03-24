import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/app/core/auth.service';
import { Registration } from 'src/app/models/accounts/registration';

@Component({
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  private errorMessage: string = '';
  public registrationForm: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder, 
    private router: Router) { }

  ngOnInit(): void {
    this.registrationForm = this.fb.group({
      firstName: ['First Name', [Validators.required]],
      lastName: ['Last Name', [Validators.required]],
      email: ['Email Address', [Validators.required, Validators.email]],
      userName: ['Username', [Validators.required]],
      password: ['Password', [Validators.required, Validators.minLength(6)]]
    });
  }

  onRegister() {
      let registration: Registration = this.registrationForm.value;
      
      this.errorMessage = '';
      this.authService.register(registration)
          .subscribe(success => {
            this.router.navigate(['Login']);
          }, error => {
            this.errorMessage = 'Failed to register'
          });
  }
}