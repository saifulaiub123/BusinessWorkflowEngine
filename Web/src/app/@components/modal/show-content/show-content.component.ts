import { Component, Input, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'ngx-show-content',
  templateUrl: './show-content.component.html',
  styleUrls: ['./show-content.component.scss']
})
export class ShowContentComponent implements OnInit {

  @Input() output;
  constructor(protected _ref: NbDialogRef<ShowContentComponent>) { }

  ngOnInit(): void {
  }
  close(event)
  {
    this._ref.close([]);
  }

}
