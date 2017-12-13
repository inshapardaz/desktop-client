import { Mapper } from './mapper';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs/Rx';
import { SettingModel } from './models/setting';
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { environment } from '../environments/index';

@Injectable()
export class SettingsService {

  private serverAddress = environment.serverAddress;
  private settingsUrl = this.serverAddress + '/api/settings';

  constructor(private http: Http,
    private auth: AuthenticationService) {

  }

  getSettings(): Observable<SettingModel> {
    return this.auth.AuthGet(this.settingsUrl)
      .map(r => this.extractData(r, Mapper.MapSettings))
      .catch(this.handleError);
  }

  updateSettings(settings: SettingModel): Observable<void> {
    return this.auth.AuthPut(this.settingsUrl, settings)
      .catch(this.handleError);
  }

  private extractData(res: Response, converter: Function) {
    const body = res.json();
    return converter(body);
  }

  private handleError(error: any) {

    const errMsg = (error.message) ? error.message :
    error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg);

    if (error.stack) {
        console.error(error.stack);
    }

    return Observable.throw(errMsg);

  }
}
