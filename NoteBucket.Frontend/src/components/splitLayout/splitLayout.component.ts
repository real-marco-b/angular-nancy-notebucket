import {Component, Input} from '@angular/core';

@Component({
    selector: 'split-layout',
    template: `
        <div class="split-layout-container">
            <div class="split-layout-fixed">
                <ng-content select=".split-layout-left"></ng-content>
            </div>

            <div class="split-layout-dynamic overlay-container">
                <ng-content select=".split-layout-right"></ng-content>
            </div>
        </div>
    `
})
export class SplitLayoutComponent {
}