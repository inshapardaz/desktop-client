import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { FormsModule, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs/Observable';

import { TranslateService } from '@ngx-translate/core';

import { DataService } from '../../providers/data.service';
import { AlertingService } from '../../providers/alerting.service';
import { Languages } from '../../models/language';
import { Dictionary } from '../../models/dictionary';
import { Word } from '../../models/word';
import { WordPage } from '../../models/WordPage';
import { DictionaryIndex } from '../../models/Dictionary';

import * as _ from 'lodash';

export class Index {
  title: string;
  link: string;
}

@Component({
  selector: 'app-words-by-link',
  templateUrl: './words.empty.html'
})
export class WordsByLinkComponent implements OnInit, OnDestroy {

  private sub: Subscription;

  constructor(private route: ActivatedRoute,
    private router: Router) {

  }
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const dictionaryLink = params['link'];
      if (dictionaryLink === '' || dictionaryLink == null) {
        this.router.navigate(['dictionaries']);
      } else {
        const id = dictionaryLink.substring(dictionaryLink.lastIndexOf('/') + 1);
        this.router.navigate(['dictionary', id]);
      }
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}

@Component({
  selector: 'app-words',
  templateUrl: './words.component.html'
})

export class WordsComponent implements OnInit, OnDestroy {
  numPages = 0;

  private sub1: Subscription;
  private sub2: Subscription;

  // Page data
  isLoading: Boolean = false;
  errorMessage: string;
  id: number;
  dictionary: Dictionary;
  index: DictionaryIndex;
  wordPage: WordPage;
  loadedLink: string;
  indexes: Array<string>;
  selectedWord: Word = null;
  createWordLink: string;
  Languages = Languages;

  // Search
  isInSearch: Boolean = false;
  searchText: Observable<string>;
  searchQuery: string;

  // Index
  selectedIndex: string;

  // Pagination
  currentPage = 0;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private alertService: AlertingService,
    private translate: TranslateService,
    private dictionaryService: DataService) {
  }

  ngOnInit() {
    this.sub1 = this.route
      .params.subscribe(params => {
        this.id = params['id'];
        console.log('Id changed loading data');
        this.loadData();
      });
    this.sub2 = this.route
      .queryParams
      .subscribe(params => {
        this.currentPage = +params['pageNumber'] || 1;
        this.searchQuery = params['search'] || '';
        if (this.searchQuery === '') {
          this.selectedIndex = params['index'] || null;
        }

        this.loadData();
      });

    // this.searchText = this.route.queryParams
    //   .map(params => params['query'] || '');

    // this.searchText.subscribe(
    //   (val) => {
    //     if (val != null && val !== '') {
    //       this.searchForm.controls.query.setValue(val);
    //       if (this.dictionary == null) {
    //         this.getDictionary(d => {
    //           this.doSearch();
    //         });
    //       } else {
    //         this.doSearch();
    //       }
    //     }
    //   });

    // this.selectedIndex = this.route.queryParams
    //   .map(params => params['index'] || '');
    // this.selectedIndex.subscribe(
    //   (val) => {
    //     if (val !== '') {
    //       this.getIndex(val);
    //     }
    //   });
  }

  ngOnDestroy() {
    this.sub1.unsubscribe();
    this.sub2.unsubscribe();
  }

  // Data loading functions
  loadData() {
    if (this.id < 1) {
      return;
    }

    if (this.dictionary == null) {
      this.getDictionaryAndWords();
    } else {
      this.getWords();
    }
  }

  getIndex(index: string) {
    this.isInSearch = false;
    this.isLoading = true;
    this.dictionaryService.getWordStartingWith(index, this.currentPage)
      .subscribe(
      words => {
        this.wordPage = words;
        this.isLoading = false;
      },
      error => {
        this.isLoading = false;
        this.alertService.error(this.translate.instant('DICTIONARY.MESSAGES.LOADING_FAILURE'));
        this.errorMessage = <any>error;
      });
  }

  getDictionaryAndWords() {
    this.isLoading = true;
    this.dictionaryService.getDictionary(this.id)
      .subscribe(
      dict => {
        this.dictionary = dict;
        this.isLoading = false;
        this.createWordLink = dict.createWordLink;
        this.getWords();
      },
      error => {
        this.isLoading = false;
        this.alertService.error(this.translate.instant('DICTIONARY.MESSAGES.LOADING_FAILURE'));
        this.errorMessage = <any>error;
      });
  }

  getWords() {
    this.isInSearch = false;
    this.isLoading = true;

    if (this.searchQuery !== '') {
      this.dictionaryService.searchWords(this.dictionary.searchLink, this.searchQuery, this.currentPage)
        .subscribe(words => {
          this.wordPage = words;
          this.isLoading = false;
          this.isInSearch = true;
        },
        error => {
          this.isLoading = false;
          this.alertService.error(this.translate.instant('DICTIONARY.MESSAGES.SEARCH_LOADING_FAILURE'));
          this.errorMessage = <any>error;
          this.isInSearch = true;
        });
    } else {
      let link = this.dictionary.indexLink;
      if (this.selectedIndex != null) {
        const index = _.find(this.dictionary.indexes, ['title', this.selectedIndex]);
        link = index.link;
      }

      this.dictionaryService.getWords(link, this.currentPage)
        .subscribe(
        words => {
          this.wordPage = words;
          this.isLoading = false;
          this.loadedLink = link;
        },
        error => {
          this.isLoading = false;
          this.alertService.error(this.translate.instant('DICTIONARY.MESSAGES.WORDS_LOADING_FAILURE'));
          this.errorMessage = <any>error;
        });
    }
  }

  // Page Functions
  reloadPage() {
    this.getWords();
  }

  wordSelected(word: Word) {
    this.router.navigate(['word', this.id, word.id]);
  }

  // Search Functions
  clearSearch() {
    this.searchQuery = '';
    this.currentPage = 1;
    this.selectedIndex = '';
    this.isInSearch = false;
    this.navigateToPage();
  }

  search() {
    this.currentPage = 1;
    this.navigateToPage();
  }

  // Navigation Code

  gotoIndex(index: DictionaryIndex) {
    const navigationExtras: NavigationExtras = {
      queryParams: { 'index': index.title },
    };
    this.router.navigate(['/dictionary', this.id], navigationExtras);
  }

  navigateToPage() {
    let navigationExtras: NavigationExtras;
    if (this.searchQuery != null && this.searchQuery !== '') {
      navigationExtras = {
        queryParams: { 'search': this.searchQuery, 'pageNumber': this.currentPage }
      };
    } else if (this.selectedIndex != null && this.selectedIndex !== '') {
      navigationExtras = {
        queryParams: { 'index': this.selectedIndex, 'pageNumber': this.currentPage }
      };
    } else {
      navigationExtras = {
        queryParams: { 'pageNumber': this.currentPage }
      };
    }

    this.router.navigate(['dictionary', this.id], navigationExtras);
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
    this.navigateToPage();
  }
}
