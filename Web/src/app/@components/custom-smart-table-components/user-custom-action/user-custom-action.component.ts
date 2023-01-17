
import { Component, Input, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { DashboardComponent } from '../../../features/dashboard/dashboard/dashboard.component';
import { UserAddEditComponent } from '../../../features/user/add-edit/user-add-edit.component';

@Component({
  selector: 'ngx-user-custom-action',
  templateUrl: './user-custom-action.component.html',
  styleUrls: ['./user-custom-action.component.scss']
})
export class UserCustomActionComponent implements OnInit {

  @Input() value: number;

  constructor(private _dialogService: NbDialogService,) { }

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
      if(value)
      {

      }
    }
    );

  }

}
