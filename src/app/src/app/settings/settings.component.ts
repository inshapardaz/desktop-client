import { Component, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { TranslateService } from '@ngx-translate/core';

import { AlertService } from '../../services/alert.service';
import { SettingsService } from "../../services/settings.service";
import { SettingModel } from "../../models/setting";

@Component({
    selector: 'settings-view',
    templateUrl: './settings-view.html'})

export class SettingsComponent {
    selectedTheme : string = "";
    isOffline : boolean;

    constructor(
        public translate: TranslateService,
        public alertService: AlertService,
        public settingsService : SettingsService
    ) {
        this.getSettings();
    }

    getSettings() {
        let self = this;
        this.settingsService.getSettings()
        .subscribe(s => {
            if (s.userInterfaceLanguage)
                self.setLanguage(s.userInterfaceLanguage);
            self.isOffline = s.useOffline;
            console.log(s);        
        },
        error => {
            this.alertService.error(this.translate.instant('SETTINGS.MESSAGES.LOADING_FAILURE'));
        });
    }

    changeLanguage(language) {
        this.setLanguage(language);
        this.saveSettings();
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

    setOffline(offline) : void {
        this.isOffline = offline;
        this.saveSettings();    
    }

    saveSettings() : void {
        var setting = new SettingModel();
        setting.useOffline = this.isOffline;
        setting.userInterfaceLanguage = this.translate.currentLang;
        this.settingsService.updateSettings(setting)
        .subscribe(r => {
            this.alertService.success(this.translate.instant('SETTINGS.MESSAGES.SAVE_SUCCESS'));
        },
        error => {
            this.alertService.error(this.translate.instant('SETTINGS.MESSAGES.SAVE_FAILURE'));
        });
    }
}