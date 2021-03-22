import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public loginRequired(): boolean {

        let isRequired = true;

        let token = localStorage.getItem('token');
    
        if (token != null) {
            let tokenExpirationString = localStorage.getItem('token-expiration');

            if (tokenExpirationString != null) {
                let tokenExpiration: Date = new Date(tokenExpirationString);

                if (token.length > 0 && tokenExpiration > new Date()) {
                    isRequired = false;
                }
            } 
        }

        return isRequired;
    }

    public logout(): void {
        localStorage.removeItem('token');
        localStorage.getItem('token-expiration');
    }
}