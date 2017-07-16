import { Component, Input } from '@angular/core';
import { TranslateService } from 'ng2-translate/ng2-translate';

@Component({
    selector: 'footer',
    templateUrl: './footer.component.html',
})

export class FooterComponent {
    @Input() miniFooter: boolean = true;
    constructor(public translate: TranslateService) {

    }

    setLanguage(lang): void {
        this.translate.use(lang);
        localStorage.setItem('ui-lang', lang);
    }
}
