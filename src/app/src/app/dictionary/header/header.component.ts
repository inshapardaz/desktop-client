import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterModule, NavigationExtras } from '@angular/router';
import {TranslateService} from '@ngx-translate/core';
import { AuthenticationService } from '../../providers/authentication.service';
import { Dictionary } from '../../models/dictionary';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() miniHeader: Boolean = false;
  public searchQuery : string = '';
  profile: any;

  @Input() dictionary: Dictionary;

  constructor(
      private router: Router,
      public auth: AuthenticationService,
      public translate: TranslateService
  ) {
  }

  ngOnInit() {
  }

  search( ): void {
      console.log("searching " + this.searchQuery);
    let navigationExtras: NavigationExtras;
    if (this.searchQuery != null && this.searchQuery !== '') {
        navigationExtras = {
        queryParams: { 'search': this.searchQuery }
        };
    } 

    this.router.navigate(['dictionary', this.dictionary.id], navigationExtras);
  }
}
