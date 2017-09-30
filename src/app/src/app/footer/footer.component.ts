import { Component, Input } from '@angular/core';
const { version: appVersion } = require('../../../package.json')

@Component({
    selector: 'footer',
    templateUrl: './footer.component.html',
})

export class FooterComponent {
     @Input() miniFooter:boolean = true;
     public appVersion;
     
     constructor(){
        this.appVersion = appVersion        
     }
}
