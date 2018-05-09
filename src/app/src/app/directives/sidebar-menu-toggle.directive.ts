import { Directive, HostListener, ElementRef, Input } from '@angular/core';
import * as $ from 'jquery';

// tslint:disable-next-line:directive-selector
@Directive({ selector: '[sidebar-menu-toggle]' })
export class SidebarMenuToggleDirective {
    el: ElementRef;
    constructor(el: ElementRef) {
        this.el = el;
    }

    @HostListener('click') onClick() {
        const el = $(this.el.nativeElement);
        const parentLi = $(el.parent('li'));

        if (parentLi.hasClass('open')){
            parentLi.removeClass('open');
        }
        else {
            el.closest('ul')
              .find('> li')
              .removeClass('open');
            parentLi.addClass('open');
        }
        const targetClass = el.data('class');

        const html = $('html');
        if (html.hasClass('no-focus')) {
            el.blur();
        }
    }
}
