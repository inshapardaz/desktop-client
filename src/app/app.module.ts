import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { LocationStrategy, HashLocationStrategy } from "@angular/common";
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AUTH_PROVIDERS } from 'angular2-jwt';

import { AppComponent } from './components/app.component';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    JsonpModule
  ],
  providers: [
    HttpModule
  ],
  declarations: [
    AppComponent,
  ],

  bootstrap: [AppComponent]
})

export class AppModule { }   