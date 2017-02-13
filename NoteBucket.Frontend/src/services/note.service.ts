import {Injectable} from '@angular/core';
import {Http, Headers, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {Note} from '../objects/Note';
import {BaseService} from './service.base';

@Injectable()
export class NoteService extends BaseService {
    constructor(http: Http) {
        super(http);
    }

    public getNote(id: number): Observable<Note> {
        let headers = this.jsonHeaders;
        return this.http.get(this.ep + "note/" + id, { headers })           
            .map(data => {
                return data.json()
            })
            .map(json => <Note>json);
    }

    public updateNote(note: Note): Observable<Response> {
        let headers = this.jsonHeaders;
        return this.http.put(this.ep + "note", JSON.stringify(note), { headers });
    }
}