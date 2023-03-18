import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { ServerAddEditComponent } from '../../../features/server/add-edit/add-edit.component';
import { ServerSharedService } from '../../../features/server/server-shared.service';
import { ConfirmModalComponent } from '../../modal/confirm-modal/confirm-modal.component';

@Component({
  selector: 'ngx-server-custom-action',
  templateUrl: './server-custom-action.component.html',
  styleUrls: ['./server-custom-action.component.scss']
})
export class ServerCustomActionComponent implements OnInit {

  @Input() value: number;
  @Input() rowData: any = {};

  constructor
  (
    private _dialogService: NbDialogService,
    private _router : Router,
    private _serverSharedService: ServerSharedService,
    private _toastrService: NbToastrService
  ) { }

  ngOnInit() {
  }

  editServer()
  {
    // this._router.navigate(['/feature/server/add-edit',{id : this.value}]);
    this._dialogService.open(ServerAddEditComponent, {
      hasScroll: false,
      closeOnBackdropClick: true,
      autoFocus: false,
      context : {
        id : this.value
      }
    })
    .onClose.subscribe(value => {
      if(value)
      {
        this._serverSharedService.setServerUpdateStatus(true);
      }
    }
    );
  }

  deleteServer()
  {
    this._dialogService.open(ConfirmModalComponent)
    .onClose.subscribe((isDelete: boolean) => {
      if(isDelete)
      {
        this._serverSharedService.deleteServer(this.value);
      }
    }
    );
  }

}

