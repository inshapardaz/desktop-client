import { Component } from '@angular/core';
import { ViewEncapsulation } from '@angular/core';
import { RouterModule , Router, NavigationStart } from '@angular/router';
import { Title }     from '@angular/platform-browser';

@Component({
    selector: 'my-app',
    templateUrl: './app.html',
    encapsulation: ViewEncapsulation.None
})

export class AppComponent {
}