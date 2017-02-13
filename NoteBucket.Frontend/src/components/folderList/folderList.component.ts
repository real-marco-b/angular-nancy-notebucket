import {Component, Output, EventEmitter} from '@angular/core';
import {FolderService} from '../../services/folder.service';
import {getUserId} from '../../services/auth.service';
import {Folder} from '../../objects/Folder';
import {Note} from '../../objects/Note';

@Component({
    selector: 'folder-list',
    providers: [FolderService],
    templateUrl: 'components/folderList/folderList.template.html'
})
export class FolderListComponent {
    selectedNote: Note;
    folders: Array<Folder>;

    @Output() noteSelected = new EventEmitter();
    showLoadingIndicator: boolean;

    constructor(public FolderService: FolderService) {
        this.showLoadingIndicator = true;
        this.FolderService.getFoldersByOwner(getUserId()).subscribe(res => {
            this.folders = res;
            this.showLoadingIndicator = false;
        });
    }

    onSelectNote(note: Note) {
        this.selectedNote = note;
        this.noteSelected.emit(note);
    }

    public update(note: Note): void {
        for (let folder of this.folders) {
            for (let n of folder.notes) {
                if (n.id == note.id) {
                    n.title = note.title;
                }
            }
        }
    }
}