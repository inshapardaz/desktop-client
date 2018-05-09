import { Title } from '@angular/platform-browser';
import { Component, Inject } from '@angular/core';
import { DOCUMENT } from "@angular/common";
import { ElectronService } from './providers/electron.service';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { DataService } from './providers/data.service'
import { SettingsService } from './providers/settings.service';
import { AlertingService } from './providers/alerting.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isRtl: Boolean = false;

  constructor(public electronService: ElectronService,
    private translate: TranslateService,
    private titleService: Title,
    private dataServices: DataService,
    public settingsService: SettingsService,
    public alertService: AlertingService,
    @Inject(DOCUMENT) private document) {

    this.setLanguages();
    this.translate.onLangChange.subscribe((event: LangChangeEvent) => {
      this.isRtl = event.lang === 'ur';
    });

    this.settingsService.getSettings()
    .subscribe(s => {
      this.document.body.style.cssText= `--custom-font: ${s.uIFont}`;
    },
    error => {
      this.alertService.error(this.translate.instant('SETTINGS.MESSAGES.LOAD_FAILURE'));
    });

    const lpageLoader = $('#page-loader');
    lpageLoader.hide();    

    if (electronService.isElectron()) {
      console.log('Mode electron');
      // Check if electron is correctly injected (see externals in webpack.config.js)
      console.log('c', electronService.ipcRenderer);
      // Check if nodeJs childProcess is correctly injected (see externals in webpack.config.js)
      console.log('c', electronService.childProcess);
    } else {
      console.log('Mode web');
    }
  }

  private setLanguages() {
    this.translate.addLangs(['en', 'ur']);
    this.translate.setDefaultLang('en');

    this.translate.get('APP.TITLE').subscribe((res: string) => {
        this.titleService.setTitle(res);
    });

    const browserLang: string = this.translate.getBrowserLang();
    const selectedLang = localStorage.getItem('ui-lang');

    this.translate.use(selectedLang ? selectedLang : (browserLang.match(/en|ur/) ? browserLang : 'en'));
    this.isRtl = selectedLang === 'ur';
}
}
