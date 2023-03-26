
import { Component, Input, OnInit } from '@angular/core';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { UserService } from '../../../@core/services/user.service';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { DashboardComponent } from '../../../features/dashboard/dashboard/dashboard.component';
import { UserAddEditComponent } from '../../../features/user/add-edit/user-add-edit.component';
import { UserSharedService } from '../../../features/user/user-shared.service';
import { ConfirmModalComponent } from '../../modal/confirm-modal/confirm-modal.component';

@Component({
  selector: 'ngx-user-custom-action',
  templateUrl: './user-custom-action.component.html',
  styleUrls: ['./user-custom-action.component.scss']
})
export class UserCustomActionComponent implements OnInit {

  @Input() value: number;
  @Input() rowData: any = {};


  constructor
  (
    private _dialogService: NbDialogService,
    private _tableSharedService: SmartTableSharedervice,
    private _userSharedService: UserSharedService,
  ) { }

  ngOnInit() {
  }

  openEditModal()
  {
    this._dialogService.open(UserAddEditComponent, {
      hasScroll: false,
      closeOnBackdropClick: true,
      autoFocus: false,
      context : {
        userId : this.value
      }
    })
    .onClose.subscribe(value => {

    }
    );
  }
  delete()
  {
    this._dialogService.open(ConfirmModalComponent)
    .onClose.subscribe((isDelete: boolean) => {
      if(isDelete)
      {
        this._userSharedService.deleteUser(this.rowData.id);
      }
    }
    );
  }

}
