import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TranslateService } from '@ngx-translate/core';
import { DataService } from '../../providers/data.service';
import { AuthenticationService } from '../../providers/authentication.service';
import { AlertingService } from '../../providers/alerting.service';

import { Languages } from '../../models/language';
import { Dictionary } from '../../models/dictionary';
// import { EditDictionaryComponent, EditDictionaryModalComponent } from '../edit-dictionary/edit-dictionary.component';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    isLoading = false;
    errorLoadingDictionaries = false;
    errorMessage: string;
    dictionaries: Dictionary[];
    createLink: string;
    dictionariesLink: string;
    selectedDictionary: Dictionary;
    Languages = Languages;
    constructor(private dictionaryService: DataService,
        private auth: AuthenticationService,
        private alertService: AlertingService,
        private router: Router,
        private translate: TranslateService,
        // private modalService: EditDictionaryModalComponent
    ) { }

    ngOnInit() {
        this.getEntry();
    }

    deleteDictionary(dictionary: Dictionary) {
        this.dictionaryService.deleteDictionary(dictionary.deleteLink)
            .subscribe(r => {
                this.alertService.success(this.translate.instant('DICTIONARIES.MESSAGES.DELETION_SUCCESS', { name: dictionary.name }));
                this.getDictionaries();
            }, e => {
                this.handlerError();
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.DELETION_FAILURE', { name: dictionary.name }));
            });
    }

    getEntry() {
        this.isLoading = true;
        this.errorLoadingDictionaries = false;
        this.dictionaryService.getEntry()
            .subscribe(entry => {
                this.dictionariesLink = entry.dictionariesLink;
                this.getDictionaries();
            }, e => {
                this.handlerError();
                this.errorLoadingDictionaries = true;
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.LOADING_FAILURE'));
            });
    }

    getDictionaries() {
        this.isLoading = true;
        this.errorLoadingDictionaries = false;
        this.dictionaryService.getDictionaries(this.dictionariesLink)
            .subscribe(data => {
                this.dictionaries = data.dictionaries;
                this.createLink = data.createLink;
                this.isLoading = false;
            }, e => {
                this.handlerError();
                this.errorLoadingDictionaries = true;
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.LOADING_FAILURE'));
            });
    }

    downloadDictionary(dictionary: Dictionary) {
        dictionary.isDownloading = true;
        this.dictionaryService.addDownload(dictionary.downloadLink)
            .subscribe(data => {
                dictionary.isDownloading = false;
                this.alertService.success(this.translate.instant('DICTIONARY.MESSAGES.DOWNLOAD_STARTED'));
                this.getDictionaries();
            }, e => {
                dictionary.isDownloading = false;
                this.handlerError();
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.DOWNLOAD_REQUEST_FAILURE'));
            });
    }

    removeDownload(dictionary: Dictionary) {
        dictionary.isDownloading = true;
        this.dictionaryService.removeDownload(dictionary.downloadLink)
            .subscribe(data => {
                dictionary.isDownloading = false;
                this.alertService.success(this.translate.instant('DICTIONARY.MESSAGES.DOWNLOAD_STARTED'));
                this.getDictionaries();
            }, e => {
                dictionary.isDownloading = false;
                this.handlerError();
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.DOWNLOAD_REQUEST_FAILURE'));
            });
    }

    createDictionary() {
        this.selectedDictionary = null;
        // this.modalService.createNewDictionary(this.selectedDictionary, this.createLink, EditDictionaryComponent,
        //   () => this.getDictionaries());
    }

    editDictionary(dictionary: Dictionary) {
        this.selectedDictionary = dictionary;
        // this.modalService.editDictionary(dictionary, EditDictionaryComponent, () => this.getDictionaries());
    }

    createDictionaryDownload(dictionary: Dictionary) {
        this.dictionaryService.createDictionaryDownload(dictionary.createDownloadLink)
            .subscribe(data => {
                this.alertService.success(this.translate.instant('DICTIONARIES.MESSAGES.DOWNLOAD_CREATION_SUCCESS',
                 { name: dictionary.name }));
            }, e => {
                this.handlerError();
                this.alertService.error(this.translate.instant('DICTIONARIES.MESSAGES.DOWNLOAD_REQUEST_FAILURE', 
                { name: dictionary.name }));
            });
    }

    onCreateClosed() {
        this.getDictionaries();
    }

    handlerError() {
        this.isLoading = false;
    }

    filterPublic() {
        this.alertService.info('test');
    }
}
