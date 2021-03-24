import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { AuthService } from "./auth.service";

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        public authService: AuthService, 
        public router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let isLoggedIn: boolean = this.authService.checkLogin();
        
        if (!isLoggedIn) {
            this.router.navigate(
                ['login'], { queryParams: { returnUrl: state.url }});

            return false; 
        }

        return true;
    }
}