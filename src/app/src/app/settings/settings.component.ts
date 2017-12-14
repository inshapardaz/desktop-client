import { SettingModel } from '../models/setting';
import { Component, Inject } from '@angular/core';
import { DOCUMENT } from "@angular/common";

import { SettingsService } from '../providers/settings.service';
import { TranslateService } from '@ngx-translate/core';
import { AlertingService } from '../providers/alerting.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})

export class SettingsComponent {
  public selectedTheme = '';
  isOffline: boolean;

  constructor(
    public translate: TranslateService,
    public settingsService: SettingsService,
    public alertService: AlertingService,
        @Inject(DOCUMENT) private document
  ) {
  }

  public setLanguage(lang: string) {
    this.translate.use(lang);
    localStorage.setItem('ui-lang', lang);
    this.saveSettings();
  }

  public setTheme(theme: string) {
    console.log(`Changing theme to ${theme}`)

    if (theme === '') {
      this.document.getElementById('theme').setAttribute('href', '');
    } else {
      this.document.getElementById('theme').setAttribute('href', `assets/css/themes/${theme}`);
    }
  }

  public setOffline(offline): void {
    this.isOffline = offline;
    this.saveSettings();
  }

  private saveSettings(): void {
    const setting = new SettingModel();
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
