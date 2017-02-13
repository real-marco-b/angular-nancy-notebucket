import {Component} from '@angular/core';

@Component({
    selector: 'header',
    template: `
        <div class="header"><ng-content></ng-content></div>
    `
})
export class HeaderComponent {
}