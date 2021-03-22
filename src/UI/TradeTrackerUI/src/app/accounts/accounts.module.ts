import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

let routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent }
]

@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ]
})
export class AccountsModule { }
