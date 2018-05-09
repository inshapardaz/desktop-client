import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { PaginationModule } from 'ngx-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { HeaderComponent } from './header/header.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

import { DictionaryRoutingModule } from './dictionary-routing.module';
import { HomeComponent } from './home/home.component';
import { WordsComponent, WordsByLinkComponent } from './words/words.component';
import { RelationsComponent } from './relations/relations.component';
import { TranslationsComponent } from './translations/translations.component';
import { MeaningsComponent } from './meanings/meanings.component';
import { WordComponent } from './word/word.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DictionaryRoutingModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
    }),
    SweetAlert2Module,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  providers: [
  ],
  declarations: [
    HomeComponent,
    WordsComponent,
    WordsByLinkComponent,
    RelationsComponent,
    TranslationsComponent,
    MeaningsComponent,
    WordComponent,
    HeaderComponent
  ],
  entryComponents: [
  ]
})
export class DictionaryModule { }
