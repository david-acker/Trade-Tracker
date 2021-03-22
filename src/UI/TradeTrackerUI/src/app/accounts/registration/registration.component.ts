import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/data.service';
import { Registration } from 'src/app/models/registration';

@Component({
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(private data: DataService, private router: Router) { }

  public registration: Registration = new Registration();

  errorMessage: string = '';
  
  onRegister() {
      this.errorMessage = '';
      this.data.register(this.registration)
          .subscribe(success => {
              if (success) {
                  this.router.navigate(['Login']);
              }
          }, err => this.errorMessage = 'Failed to register');
  }
}
