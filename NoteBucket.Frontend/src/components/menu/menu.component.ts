import {Component, ContentChildren, AfterViewInit, QueryList} from '@angular/core';
import {MenuItemComponent} from './menu-item.component';

@Component({
    selector: 'app-menu',
    template: `
        <ng-content></ng-content>
    `
})
export class MenuComponent {
}