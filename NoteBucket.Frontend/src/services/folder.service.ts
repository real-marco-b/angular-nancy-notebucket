import {Injectable} from '@angular/core';
import {Http, Headers} from '@angular/http';
import {Folder} from '../objects/Folder';
import {BaseService} from './service.base';

@Injectable()
export class FolderService extends BaseService {
    constructor(http: Http) {
        super(http);
    }

    public getFoldersByOwner(ownerId: number) {
        let headers = this.jsonHeaders;
        return this.http.get(this.ep + "folder/owner/" + ownerId, this.options)
            .map(data => {
                return data.json()
            })
            .map(json => <Folder[]>json);
    }
}
