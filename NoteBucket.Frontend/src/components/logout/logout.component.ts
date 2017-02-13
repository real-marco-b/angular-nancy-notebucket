import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {AuthenticationService} from '../../services/auth.service';

@Component({
    selector: 'logout',
    template: ''
})
export class LogoutComponent {
    constructor(router: Router, authService: AuthenticationService) {
        authService.logout();
        router.navigate(['/']);
        
    }
}