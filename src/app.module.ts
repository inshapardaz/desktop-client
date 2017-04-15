import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LocationStrategy, HashLocationStrategy } from "@angular/common";
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app/app.component';
import { HomeComponent } from './app/home/home.component';
import { DictionaryComponent } from './app/dictionary/dictionary.component';
import { routing  } from './app.routes';

@NgModule({
  imports: [
    BrowserModule,
    routing,
    FormsModule,
    HttpModule,
    JsonpModule,
  ],
  providers: [
    HttpModule,
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    DictionaryComponent
  ],

  bootstrap: [AppComponent]
})

export class AppModule { }   