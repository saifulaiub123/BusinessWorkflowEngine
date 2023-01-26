import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'ngx-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.scss']
})
export class ConfirmModalComponent implements OnInit {

  constructor(protected _ref: NbDialogRef<ConfirmModalComponent>) { }

  ngOnInit(): void {
  }
  ok()
  {
    this._ref.close(true);
  }
  cancel(){
    this._ref.close(false);
  }

}
