import * as _ from 'lodash';
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
  selectedFont = null;
  fonts = [{
    title : 'فجر نوری نستعلیق',
    fontFamily : 'Fajer Noori Nastalique'
  }, {
    title : 'پاک نستعلیق',
    fontFamily : 'Pak Nastaleeq'
  }, {
    title : 'نفیس ویب نسخ',
    fontFamily : 'Nafees Web Naskh'
  }, {
    title : 'نفیس نستعلیق',
    fontFamily : 'Nafees-Nastaleeq'
  }, {
    title : 'مہر نستعلیق',
    fontFamily : 'Mehr-Nastaleeq'
  }, {
    title : 'دھلوی خوشخط',
    fontFamily : 'DehalviKhushKhat'
  }, {
    title : 'اڈوبی عربی',
    fontFamily : 'AdobeArabic'
  }, {
    title : 'اردو نسخ ایشیا ٹائپ',
    fontFamily : 'UrduNaskhAsiatype'
  }];
  
  constructor(
    public translate: TranslateService,
    public settingsService: SettingsService,
    public alertService: AlertingService,
    @Inject(DOCUMENT) private document
  ) {
    this.settingsService.getSettings()
    .subscribe(s => {
      this.isOffline = s.useOffline;
      this.selectedFont = _.find(this.fonts, (f) =>   f.fontFamily === s.uIFont );
    },
    error => {
      this.alertService.error(this.translate.instant('SETTINGS.MESSAGES.LOAD_FAILURE'));
    });
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

  public setFont(font : any) {
    this.document.body.style.cssText= `--custom-font: ${font.fontFamily}`;
    this.selectedFont = font;
    this.saveSettings();
  }

  public setOffline(offline): void {
    this.isOffline = offline;
    this.saveSettings();
  }

  private saveSettings(): void {
    const setting = new SettingModel();
    setting.useOffline = this.isOffline;
    setting.userInterfaceLanguage = this.translate.currentLang;
    setting.uIFont =this.selectedFont.fontFamily;
    console.log(`Setting font ${setting.uIFont}`);
    this.settingsService.updateSettings(setting)
      .subscribe(r => {
        this.alertService.success(this.translate.instant('SETTINGS.MESSAGES.SAVE_SUCCESS'));
      },
      error => {
        this.alertService.error(this.translate.instant('SETTINGS.MESSAGES.SAVE_FAILURE'));
      });
  }
}
