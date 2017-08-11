import { Injectable } from '@angular/core';
import { Http, Response, Headers  } from '@angular/http';
import {Observable} from 'rxjs/Observable';

import { Mapper } from '../mapper';
import {Settings} from '../models/settings';

@Injectable()
export class ApplicationService {
    private serverAddress = 'http://localhost:9586';
    private settingsAddress = this.serverAddress + "/api/settings";

    constructor(private http : Http) {
    }

    public getSettings() : Observable<Settings>{
        return this.http.get(this.settingsAddress)
            .map(r => {
                var e = this.extractData(r, Mapper.MapSettings);
                return e;
            });
    }

    public updateSettings(settings : Settings) : Observable<Settings> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.put(this.settingsAddress, JSON.stringify(settings), {
                                headers: headers
                            })
                        .map(r => {
                                var e = this.extractData(r, Mapper.MapSettings);
                                return e;
                            });
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