import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AuthConfig, OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { environment } from '../environments/index';

import 'rxjs/add/operator/filter';
import { Observable } from 'rxjs/Observable';
import { retry } from 'rxjs/operators/retry';

@Injectable()
export class AuthenticationService {
  public userProfile: any;
  constructor(private http: Http, public router: Router, private oauthService: OAuthService) {
  }

  public configureOAuth() {
    const authority = environment.authServerAddress;

    const authConfig = new AuthConfig();
    authConfig.issuer = authority;
    authConfig.redirectUri = window.location.origin;
    authConfig.silentRefreshRedirectUri = window.location.origin + '/silent-renew.html';
    authConfig.clientId = 'angular2client';
    authConfig.scope = 'openid';
    authConfig.sessionChecksEnabled = true;
    authConfig.requireHttps = false;

    this.oauthService.configure(authConfig);
    this.oauthService.setupAutomaticSilentRefresh();
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  public login() {
    this.oauthService.initImplicitFlow();
  }

  public logout(): boolean {
    this.oauthService.logOut();

    this.router.navigate(['/home']);
    return true;
  }

  public isAuthenticated(): boolean {
    return this.oauthService.getAccessToken() != null;
  }

  public refreshToken() {
    this.oauthService.silentRefresh()
    .then(info => console.log('token refresh ok', info))
    .catch(err => console.error('token refresh error', err));
  }

  public loadUserProfile(): void {
    this
        .oauthService
        .loadUserProfile()
        .then(up => {
          console.log(up);
          this.userProfile = up;
        });
  }

  AuthGet(url: string, options?: RequestOptions): Observable<Response> {
    options = this.setRequestOptions(options);
    return this.http.get(url, options);
  }

  AuthPut(url: string, data: any, options?: RequestOptions): Observable<Response> {
    const body = JSON.stringify(data);
    options = this.setRequestOptions(options);
    return this.http.put(url, body, options);
  }

  AuthDelete(url: string, options?: RequestOptions): Observable<Response> {
    options = this.setRequestOptions(options);
    return this.http.delete(url, options);
  }

  AuthPost(url: string, data: any, options?: RequestOptions): Observable<Response> {
    const body = JSON.stringify(data);
    this.setRequestOptions(options);
    return this.http.post(url, body, options);
  }

  private setRequestOptions(options?: RequestOptions) {
    if (options) {
      if (this.isAuthenticated()) {
        options.headers.append('Authorization', 'Bearer ' + this.oauthService.getIdToken());
      }

      options.headers.append('Content-Type', 'application/json');
    } else {
      const headers = new Headers();
      headers.append('Content-Type', 'application/json');
      headers.append('Authorization', 'Bearer ' + this.oauthService.getIdToken());
      options = new RequestOptions({ headers: headers });
    }
    return options;
  }
}
