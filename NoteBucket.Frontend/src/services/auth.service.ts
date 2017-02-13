import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {Router} from '@angular/router';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import {BaseService} from './service.base';
import {Credentials} from '../objects/Credentials';

export function getUserId() {
    let key = AuthenticationService.StorageKeyId;
    return parseInt(localStorage.getItem(key));
}

@Injectable()
export class AuthenticationService extends BaseService {
    public static StorageKeyToken: string = "identityToken";
    public static StorageKeyId: string = "identity";
    loggedIn: boolean;

    constructor(private router: Router, http: Http) {
        super(http);
        this.loggedIn = this.isLoggedIn();
    }

    public logout(): void {
        localStorage.removeItem(AuthenticationService.StorageKeyToken);
        localStorage.removeItem(AuthenticationService.StorageKeyId);
        this.loggedIn = false;
        this.router.navigate(['login']);
    }

    public isLoggedIn(): boolean {
        return localStorage.getItem(AuthenticationService.StorageKeyToken) !== null &&
            localStorage.getItem(AuthenticationService.StorageKeyId) !== null;
    }

    public login(credentials: Credentials): Observable<boolean> {
        let headers = this.jsonHeaders;
        return this.http.post(this.ep + 'authentication', JSON.stringify(credentials), { headers })
            .map(data => {
                return data.json();
            })
            .map(json => {
                if (json.token !== undefined) {
                    localStorage.setItem(AuthenticationService.StorageKeyToken, json.token);
                    localStorage.setItem(AuthenticationService.StorageKeyId, json.userId);
                    this.loggedIn = true;
                    this.router.navigate(['dashboard']);
                }
                else {
                    this.loggedIn = false;
                }
                return this.loggedIn;
            });
    }
}