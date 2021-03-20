import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { DataService } from '../core/data.service';
import { Credentials } from '../models/credentials';

@Component({
    selector: 'app-login',
    templateUrl: 'login.component.html'
})
export class LoginComponent {
    
    constructor(private data: DataService, private router: Router) { }

    errorMessage: string = "";
    
    public credentials: Credentials = new Credentials();

    onLogin() {
        this.errorMessage = "";
        this.data.login(this.credentials)
            .subscribe(success => {
                if (success) {
                    
                    this.router.navigate([""]);
                }
            }, err => this.errorMessage = "Failed to login");
    }
}
