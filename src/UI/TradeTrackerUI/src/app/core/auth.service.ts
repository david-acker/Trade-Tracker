import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { Credentials } from '../models/accounts/credentials';
import { Registration } from '../models/accounts/registration';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private isLoggedIn: boolean = false;
    public redirectUrl: string;

    constructor(
        private http: HttpClient,
        private router: Router) { }

    public login(credentials: Credentials) {
        return this.http.post('/api/account/authenticate', credentials)
            .pipe(
                map((response: any) => {
                    localStorage.setItem('token', response.token);

                    let expirationDate = new Date(response.expiration);
                    localStorage.setItem('token-expiration', expirationDate.toISOString());

                    if (this.redirectUrl) {
                        this.router.navigate([this.redirectUrl]);
                        this.redirectUrl = null;
                    }

                    return true;
                }));
    }

    public register(registration: Registration) {
        return this.http.post('/api/account/register', registration)
            .pipe(
                map((response: any) => {
                    return true;
                }));
    }

    public checkLogin(): boolean {
        let token = localStorage.getItem('token');
        if (token != null) {
            let tokenExpirationString = localStorage.getItem('token-expiration');

            if (tokenExpirationString != null) {
                let tokenExpiration: Date = new Date(tokenExpirationString);

                if (token.length > 0 && tokenExpiration > new Date()) {
                    this.isLoggedIn = true;
                }
            } 
        }

        return this.isLoggedIn;
    }

    public logout(): void {
        this.clearStoredToken();

        this.router.navigateByUrl('');
    }
    
    public clearStoredToken(): void {
        this.isLoggedIn = false;

        localStorage.removeItem('token');
        localStorage.getItem('token-expiration');
    }
}