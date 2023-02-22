import { Component, OnInit } from '@angular/core';

const settings = require('../../../environments/settings.json');

@Component({
  selector: 'ngx-hangfire',
  templateUrl: './hangfire.component.html',
  styleUrls: ['./hangfire.component.scss']
})
export class HangfireComponent implements OnInit {

  hangfireUrl: string;
  // constructor(private sanitizeUrl: SanitizeUrlPipe) { }

  ngOnInit(): void {
    this.hangfireUrl = settings.backendUrl + "/hangfire";
  }
}
