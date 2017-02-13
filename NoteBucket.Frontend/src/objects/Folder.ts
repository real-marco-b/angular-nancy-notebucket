import {User} from './User';
import {Note} from './Note';

export class Folder {
    constructor() {
        this.notes = new Array<Note>();
    }

    public id: number;

    public name: string;

    public owner: User;

    public notes: Note[];
}