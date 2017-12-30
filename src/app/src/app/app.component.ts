import { Title } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { ElectronService } from './providers/electron.service';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { DataService } from './providers/data.service'
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
    private dataServices: DataService) {

    this.setLanguages();
    this.translate.onLangChange.subscribe((event: LangChangeEvent) => {
      this.isRtl = event.lang === 'ur';
    });    

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
