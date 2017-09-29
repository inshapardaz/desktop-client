import { Component, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import {TranslateService} from '@ngx-translate/core';

// import *  as amethyst from '../../assets/css/themes/amethyst';
// import * as city from '../../assets/css/themes/city';
// import * as flat from '../../assets/css/themes/flat';
// import * as modern from '../../assets/css/themes/modern';
// import * as smooth from '../../assets/css/themes/smooth';

@Component({
    selector: 'settings',
    templateUrl: './settings.html'})

export class SettingsComponent {
    public selectedTheme : string = "";
    constructor(
        public translate: TranslateService
    ) {
    }

    setLanguage(lang) : void{
        this.translate.use(lang);
        localStorage.setItem('ui-lang', lang);
    }

    setTheme(theme) : void{
        var $cssTheme = $('#css-theme');
        if (theme === '') {
            $cssTheme.attr('href', '');
        } else {
            $cssTheme.attr('href', theme);
        }
    }
}

// export class ThemeSetting {
//     constructor(public title : string, public css : string, colorClass : string){
//     }
// }
