import 'zone.js/dist/zone-mix';
import 'reflect-metadata';
import 'polyfills';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

// NG Translate
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { OAuthModule } from 'angular-oauth2-oidc';
import { ElectronService } from './providers/electron.service';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap';
// import { ToastModule } from 'ng2-toast';

// Directives
import { UIToggleDirective } from './directives/ui-toggle.directive';
import { SideBarToggleDirective } from './directives/side-bar-toggle.directive';
import { AppearDirective } from './directives/appear.directive';
import { RightToLeftDirective } from './directives/right-to-left.directive';
import { SidebarMenuToggleDirective } from './directives/sidebar-menu-toggle.directive';

//  Modules
import { DictionaryModule } from './dictionary/dictionary.module';

//  Components
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';

// Services
import { AuthenticationService } from './providers/authentication.service';
import { AlertingService } from './providers/alerting.service';
import { SettingsService } from './providers/settings.service';
import { DataService } from './providers/data.service';

import { HomeComponent } from './home/home.component';
import { ErrorUnauthorisedComponent } from './error-unauthorised/error-unauthorised.component';
import { ErrorUnexpectedComponent } from './error-unexpected/error-unexpected.component';
import { SettingsComponent } from './settings/settings.component';
import { ProfileComponent } from './profile/profile.component';

// AoT requires an exported function for factories
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    FooterComponent,
    HomeComponent,
    ErrorUnauthorisedComponent,
    ErrorUnexpectedComponent,
    SettingsComponent,
    ProfileComponent,

    UIToggleDirective,
    SideBarToggleDirective,
    RightToLeftDirective,
    AppearDirective,
    SidebarMenuToggleDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (HttpLoaderFactory),
        deps: [HttpClient]
      }
    }),
    OAuthModule.forRoot(),
    SweetAlert2Module.forRoot(),
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    // BrowserAnimationsModule,
    // ToastModule.forRoot(),
    DictionaryModule
  ],
  providers: [
    HttpClientModule,
    ElectronService,
    AuthenticationService,
    DataService,
    AlertingService,
    SettingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
