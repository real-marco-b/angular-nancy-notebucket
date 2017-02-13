import {Component, ViewChild} from '@angular/core';
import {Folder} from '../../objects/Folder';
import {Note} from '../../objects/Note';
import {FolderListComponent} from '../folderList/folderList.component';

@Component({
    selector: 'folders-master-detail',
    template: `
        <div class="master-detail">
            <div class="master-detail-left">
                <folder-list (noteSelected)="showNote($event)"></folder-list>
            </div>

            <div class="master-detail-right">
                <note-detail [note]="selectedNote" (noteSaved)="reloadList($event)"></note-detail>
            </div>
        </div>
    `
})
export class FoldersMasterDetailComponent {
    selectedNote: Note;

    @ViewChild(FolderListComponent)
    private folderList: FolderListComponent;

    constructor() {
        this.selectedNote = null;
    }

    showNote(note: Note) {
        if (note != null) {
            this.selectedNote = note;
        }
    }

    reloadList(note: Note) {
        this.folderList.update(note);
    }
}