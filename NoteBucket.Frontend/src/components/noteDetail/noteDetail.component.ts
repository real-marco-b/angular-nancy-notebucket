import {Component, Input, EventEmitter, Output} from '@angular/core';
import {NgForm} from '@angular/forms';
import {NoteService} from '../../services/note.service';
import {Note} from '../../objects/Note';

@Component({
    selector: 'note-detail',
    providers: [NoteService],
    templateUrl: 'components/noteDetail/noteDetail.template.html'
})
export class NoteDetailComponent {
    private currentNote: Note;

    private showSavingIndicator: boolean;
    private saved: boolean;
    private service: NoteService;

    @Output() private noteSaved = new EventEmitter();

    constructor(service: NoteService) {
        this.saved = false;
        this.showSavingIndicator = false;
        this.service = service;
    }

    @Input()
    set note(n: Note) {
        if(n != null) {
            this.showSavingIndicator = true;
            this.service.getNote(n.id).subscribe(res => {
                this.showSavingIndicator = false;
                this.saved = false;
                this.currentNote = res;
            });
        }
    }

    get note() {
        return this.currentNote;
    }

    onSubmit(): void {
        this.showSavingIndicator = true;
        this.saved = false;
      
        this.service.updateNote(this.currentNote).subscribe(resp => {
            this.showSavingIndicator = false;
            if (resp.ok) {
                this.saved = true;
                this.noteSaved.emit(this.currentNote);
            }
        });
    }
}