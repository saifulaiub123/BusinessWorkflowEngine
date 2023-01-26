import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogService } from '@nebular/theme';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { ConfirmModalComponent } from '../../modal/confirm-modal/confirm-modal.component';

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
    private _tableSharedService: SmartTableSharedervice) { }

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
