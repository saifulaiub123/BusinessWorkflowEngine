import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ngx-page',
  template: `
    <ngx-one-column-layout>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
