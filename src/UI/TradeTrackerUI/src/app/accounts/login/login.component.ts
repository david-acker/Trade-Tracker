import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { DataService } from '../../core/data.service';
import { Credentials } from '../../models/credentials';

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    
    constructor(private data: DataService, private router: Router) { }

    public credentials: Credentials = new Credentials();

    errorMessage: string = "";

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
