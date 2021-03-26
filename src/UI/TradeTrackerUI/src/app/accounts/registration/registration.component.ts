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
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
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