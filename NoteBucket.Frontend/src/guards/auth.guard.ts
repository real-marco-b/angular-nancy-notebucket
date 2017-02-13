import {Injectable} from '@angular/core';
import {Router, CanActivate} from '@angular/router';
import {AuthenticationService} from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private auth: AuthenticationService) {
    }

    canActivate(): boolean {
        let activatable = this.auth.isLoggedIn();

        if (!activatable) {
            this.router.navigate(['/login']);
        }

        return activatable;
    }
}