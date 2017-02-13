import {Component, Input} from '@angular/core';

@Component({
    selector: 'menu-item',
    template: `
        <div class="menu-item">
            <ng-content></ng-content>
        </div>
    `
})
export class MenuItemComponent {
} 
