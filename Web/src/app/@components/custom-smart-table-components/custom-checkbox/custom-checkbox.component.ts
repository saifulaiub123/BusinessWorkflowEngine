import { Component, Input, OnInit } from '@angular/core';

import { ViewCell } from 'ng2-smart-table';

@Component({
  template: `
    <nb-checkbox disabled [checked]="renderValue"></nb-checkbox>
  `,
})
export class CustomNg2CheckboxComponent implements ViewCell, OnInit {

  renderValue: boolean;

  @Input() value: string | number;
  @Input() rowData: any;

  ngOnInit() {
    this.renderValue = (/true/).test(this.value.toString());
  }

}
