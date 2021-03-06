import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../providers/authentication.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    profile: any;
    constructor(public auth: AuthenticationService) { }

    ngOnInit() {
      this.auth.refreshToken();
    }

}
