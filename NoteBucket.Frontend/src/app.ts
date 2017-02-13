import {Component} from '@angular/core';
import {AuthenticationService} from './services/auth.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app.template.html',
})

export class AppComponent {
    constructor(private auth: AuthenticationService) {
    }
}