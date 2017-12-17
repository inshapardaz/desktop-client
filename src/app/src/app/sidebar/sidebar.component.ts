import { Component, OnInit } from '@angular/core';
import { ElectronService } from '../providers/electron.service';
import { SettingsService } from '../providers/settings.service';
import { settings } from 'cluster';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor(private electronService: ElectronService,
              private settingService: SettingsService) { }

  ngOnInit() {
  }

  openWebHome() {
    this.settingService.getSettings()
        .subscribe((s) => {
          if (s != null && s.webHomeUrl != null) {
            this.electronService.shell.openExternal(s.webHomeUrl);
          }
        });
  }
}
