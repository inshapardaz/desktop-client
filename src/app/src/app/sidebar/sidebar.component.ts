import { Component, OnInit } from '@angular/core';
import { ElectronService } from '../providers/electron.service';
import { SettingsService } from '../providers/settings.service';
import { AlertingService } from '../providers/alerting.service';
import { settings } from 'cluster';

import { TranslateService } from '@ngx-translate/core';
import { DataService } from '../providers/data.service';
import { Dictionary } from '../models/dictionary';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  dictionaries: Dictionary[];
  errorLoadingDictionaries = false;
  dictionariesLink: string;

  constructor(private electronService: ElectronService,
              private settingService: SettingsService,
              private dictionaryService: DataService,
              private alertService: AlertingService,
              private translate: TranslateService) { }

  ngOnInit() {
    this.getEntry();
  }

  openWebHome() {
    this.settingService.getSettings()
        .subscribe((s) => {
          if (s != null && s.webHomeUrl != null) {
            this.electronService.shell.openExternal(s.webHomeUrl);
          }
        });
  }

  getEntry() {
    this.errorLoadingDictionaries = false;
    this.dictionaryService.getEntry()
        .subscribe(entry => {
            this.dictionariesLink = entry.dictionariesLink;
            this.getDictionaries();
        }, e => {
            this.errorLoadingDictionaries = true;
            this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.LOADING_FAILURE'));
        });
  }

  getDictionaries() {
    this.errorLoadingDictionaries = false;
    this.dictionaryService.getDictionaries(this.dictionariesLink)
        .subscribe(data => {
            this.dictionaries = data.dictionaries;
            console.log(data.dictionaries);
        }, e => {
            this.errorLoadingDictionaries = true;
            this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.LOADING_FAILURE'));
        });
  }
}
