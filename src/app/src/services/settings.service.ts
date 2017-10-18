import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import * as _ from 'lodash';

import { Mapper } from '../mapper';
import { SettingModel } from '../models/setting';

@Injectable()
export class SettingsService {
    private serverAddress = 'http://localhost:9586';
    private settingsUrl = this.serverAddress + '/api/settings';
    
    constructor(private auth: AuthService, 
        private http: Http) {
    }

    getSettings(): Observable<SettingModel> {
        return this.auth.AuthGet(this.settingsUrl)
        .map(r => this.extractData(r, Mapper.MapSettings))
        .catch(this.handleError);
    }
   
    updateSettings(settings : SettingModel) : Observable<void>{
        return this.auth.AuthPut(this.settingsUrl, settings)
            .catch(this.handleError);
    }

    private extractData(res: Response, converter: Function) {
        let body = res.json();
        return converter(body);
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        if (error.stack)
            console.error(error.stack);
        return Observable.throw(errMsg);
    }
}
