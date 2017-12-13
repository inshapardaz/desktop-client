import { Component, OnInit } from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public translate: TranslateService) { }

  ngOnInit() {
    const lpageLoader = $('#page-loader');
    lpageLoader.hide();
  }

}
