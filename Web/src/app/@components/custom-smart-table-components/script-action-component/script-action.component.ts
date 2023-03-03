import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { ConfirmModalComponent } from '../../modal/confirm-modal/confirm-modal.component';
import { ScriptRunConfirmationComponent } from '../../modal/script-run-confirmation/script-run-confirmation.component';

@Component({
  selector: 'ngx-script-action-component',
  templateUrl: './script-action-component.component.html',
  styleUrls: ['./script-action-component.component.scss']
})
export class ScriptActionComponent implements OnInit {

  @Input() value: any = {};
  @Input() rowData: any = {};

  constructor(private _dialogService: NbDialogService,
    private _router : Router,
    private _tableSharedService: SmartTableSharedervice,
    private _toastrService: NbToastrService,) { }

  ngOnInit() {
  }

  viewScript()
  {
    this._router.navigate(['/feature/script/add-edit',{id : this.value.id, actionMode: 'view'}]);
  }
  editScript()
  {
    this._router.navigate(['/feature/script/add-edit',{id : this.value.id, actionMode: 'edit'}]);
  }
  runScript()
  {
    this._dialogService.open(ScriptRunConfirmationComponent)
    .onClose.subscribe((data: any) => {
      if(data.isRun == true)
      {
        this._toastrService.info("Run script","A mail will be sent after executing the script",{ duration: 12000});
        this._tableSharedService.runScript({dynamicValues : data.values != null ? data.values : "", scriptId: this.rowData.id});
      }
    }
    );
  }
  deleteScript()
  {
    this._dialogService.open(ConfirmModalComponent)
    .onClose.subscribe((isDelete: boolean) => {
      if(isDelete)
      {
        this._tableSharedService.deleteScript(this.rowData);
      }
    }
    );
  }
}
