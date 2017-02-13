import {Observable} from 'rxjs/Observable';
import {Http, Headers, Response, RequestOptions} from '@angular/http';
import {networkConfiguration} from './service.config';
import {AuthenticationService} from './auth.service';

export class BaseService {
    protected ep: string;
    protected http: Http;
    protected jsonHeaders: Headers;
    protected options: RequestOptions;

    constructor(http: Http) {
        this.http = http;
        this.ep = networkConfiguration.restEndpoint;
        this.jsonHeaders = this.createJsonHeaders();
        this.options = new RequestOptions({
            headers: this.jsonHeaders,
            body: '',
        });
    }

    protected createJsonHeaders(): Headers {
        var headers = new Headers();
        let token = localStorage.getItem(AuthenticationService.StorageKeyToken);
        headers.append("Content-Type", "application/json");
        headers.append("Accept", "application/json");
        headers.append("Authorization", "Bearer " + token);
        return headers;
    }
}