import { Component } from '@angular/core';
import {ViewEncapsulation} from '@angular/core';


@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['../assets/css/styles.scss','./app.component.scss'],
    encapsulation: ViewEncapsulation.None
})

export class AppComponent {
    logo_image: any = require('../assets/images/angular.png');
 }
