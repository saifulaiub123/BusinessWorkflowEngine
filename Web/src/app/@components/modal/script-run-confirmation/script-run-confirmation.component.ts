import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'ngx-script-run-confirmation',
  templateUrl: './script-run-confirmation.component.html',
  styleUrls: ['./script-run-confirmation.component.scss']
})
export class ScriptRunConfirmationComponent implements OnInit {

  constructor(protected _ref: NbDialogRef<ScriptRunConfirmationComponent>) { }

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

