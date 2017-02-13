import {Component} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Credentials} from '../../objects/Credentials';
import {AuthenticationService} from '../../services/auth.service';

@Component({
    selector: 'login',
    templateUrl: 'components/login/login.template.html'
})
export class LoginComponent {
    credentials: Credentials;

    constructor(private auth: AuthenticationService) {
        this.credentials = new Credentials();
    }

    onSubmit(): void {
        this.auth.login(this.credentials).subscribe(succ => {
        });
    }
}