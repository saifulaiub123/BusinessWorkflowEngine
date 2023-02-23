import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'ngx-script-history-status',
  templateUrl: './script-history-status.component.html',
  styleUrls: ['./script-history-status.component.scss']
})
export class ScriptHistoryStatusComponent implements OnInit {

  @Input() value: any = {};
  @Input() rowData: any = {};
  constructor() { }

  ngOnInit(): void {
  }

}
