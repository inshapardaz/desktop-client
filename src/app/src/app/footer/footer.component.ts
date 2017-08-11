import { Component, Input } from '@angular/core';
import { TranslateService } from 'ng2-translate/ng2-translate';

import {ApplicationService} from '../../services/application.service'

@Component({
    selector: 'footer',
    templateUrl: './footer.component.html',
})

export class FooterComponent {
    @Input() miniFooter: boolean = true;
    constructor(public translate: TranslateService, 
                public applicationService : ApplicationService) {

    }

    setLanguage(lang): void {
        this.translate.use(lang);
        localStorage.setItem('ui-lang', lang);
        this.applicationService.getSettings()
            .subscribe(settings => {
                settings.userInterfaceLanguage = lang;
                this.applicationService.updateSettings(settings)
                    .subscribe();
            });
    }
}
