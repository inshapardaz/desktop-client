import { Component, Input  } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { TranslateService } from '@ngx-translate/core';

import { AlertingService } from '../../providers/alerting.service';
import { DataService } from '../../providers/data.service';
import { Meaning } from '../../models/meaning';
import { RelationTypes } from '../../models/relationTypes';
// import { EditMeaningModalComponent, EditMeaningComponent } from '../edit-meaning/edit-meaning.component';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'word-meanings',
  templateUrl: './meanings.component.html',
  styleUrls: ['./meanings.component.css']
})
export class MeaningsComponent {
  public _meaningsLink: string;
  public relationTypes: RelationTypes;
  public isLoading: Boolean = false;
  public errorMessage: string;
  public meanings: Array<Meaning>;

  selectedMeaning: Meaning = null;
  @Input() createLink: string;
  @Input() wordId: number;
  @Input()
  set meaningsLink(relationsLink: string) {
      this._meaningsLink = (relationsLink) || '';
      this.getMeanings();
  }
  get meaningsLink(): string { return this._meaningsLink; }

  constructor(private route: ActivatedRoute,
      private router: Router,
      private alertService: AlertingService,
      private translate: TranslateService,
      private dictionaryService: DataService,
      // private modalService: EditMeaningModalComponent
    ) {
  }

  getMeanings() {
      this.isLoading = true;
      this.dictionaryService.getMeanings(this._meaningsLink)
          .subscribe(
          meanings => {
              this.meanings = meanings;
              this.isLoading = false;
          },
          error => {
              this.alertService.error(this.translate.instant('MEANING.MESSAGES.LOAD_FAILURE'));
              this.errorMessage = <any>error;
          });
  }

  addMeaning() {
      this.selectedMeaning = null;
    //   this.modalService.createNewMeaning(this.selectedMeaning, this.createLink, EditMeaningComponent, () => this.getMeanings());
  }

  editMeaning(meaning: Meaning) {
      this.selectedMeaning = meaning;
    //   this.modalService.editMeaning(this.selectedMeaning, EditMeaningComponent, () => this.getMeanings());
  }

  deleteMeaning(meaning: Meaning) {
      this.dictionaryService.deleteMeaning(meaning.deleteLink)
      .subscribe(r => {
          this.alertService.success(this.translate.instant('MEANING.MESSAGES.DELETE_SUCCESS'));
          this.getMeanings();
      }, error => {
          this.errorMessage = <any>error;
          this.isLoading = false;
          this.alertService.error(this.translate.instant('MEANING.MESSAGES.DELETE_FAILURE'));
      });
  }
}
