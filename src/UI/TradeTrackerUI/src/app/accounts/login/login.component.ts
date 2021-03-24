import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthService } from 'src/app/core/auth.service';
import { Credentials } from '../../models/accounts/credentials';

@Component({
    templateUrl: 'login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    private errorMessage: string = '';
    private returnUrl: string;

    public loginForm: FormGroup;

    constructor(
        private authService: AuthService,
        private fb: FormBuilder,
        private route: ActivatedRoute, 
        private router: Router) { }

    ngOnInit(): void {
        this.authService.clearStoredToken();

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';

        this.loginForm = this.fb.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required]]
        });
    }

    onLogin() {
        let credentials: Credentials = this.loginForm.value;
        this.errorMessage = '';

        this.authService.login(credentials)
            .subscribe(success => {
                this.router.navigateByUrl(this.returnUrl);
            }, error => {
                this.errorMessage = 'Failed to login'
            });
    }
}
