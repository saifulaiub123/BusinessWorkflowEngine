import { ShowContentComponent } from './../../modal/show-content/show-content.component';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { ConfirmModalComponent } from '../../modal/confirm-modal/confirm-modal.component';
import { ScriptRunConfirmationComponent } from '../../modal/script-run-confirmation/script-run-confirmation.component';

@Component({
  selector: 'ngx-script-history-result',
  templateUrl: './script-history-result.component.html',
  styleUrls: ['./script-history-result.component.scss']
})
export class ScriptHistoryResultComponent implements OnInit {

  @Input() value: any = {};
  @Input() rowData: any = {};

  constructor(
    private _dialogService: NbDialogService,
    ) { }

  ngOnInit() {
  }
  showOutput()
  {
    this._dialogService.open(ShowContentComponent,{
      hasScroll: false,
      closeOnBackdropClick: true,
      autoFocus: false,
      context : {
        output : this.value
      }
    })
  }

}
