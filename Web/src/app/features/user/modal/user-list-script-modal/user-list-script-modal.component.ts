import { UserService } from './../../../../@core/services/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogRef } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { User } from '../../../../@core/model/user';

@Component({
  selector: 'ngx-user-list-script-modal',
  templateUrl: './user-list-script-modal.component.html',
  styleUrls: ['./user-list-script-modal.component.scss']
})
export class UserListScriptModalComponent implements OnInit {

 selectedUser: User[] = [];

  settings = {
    selectMode: 'multi',
    actions: {
      add: false,
      delete: false,
      edit: false
    },
    columns: {
      id: {
        title: 'Id',
        type: 'number',
        filter: false,
        hide: true
      },
      name: {
        title: 'Name',
        type: 'string',
        filter: false,
        valuePrepareFunction: (value, row, cell) => {
          return row.firstName +" "+ row.lastName;
         },
      },
      email: {
        title: 'Email',
        type: 'string',
        filter:true,
      },
      phoneNumber: {
        title: 'Phone Number',
        type: 'string',
        filter:true,
      },
      permissionId: {
        title: 'PermissionId',
        type: 'number',
        filter:false,
        hide: true,
        defaultValue: 1
      },
    },
    attr: {
      class: 'table table-bordered'
    },
    pager: { display: false }
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(
    private _userService: UserService,
    protected _ref: NbDialogRef<UserListScriptModalComponent>
    ) {

  }
  ngOnInit(): void {
    this.loadData();
  }

  loadData()
  {
    this._userService.getUsers().subscribe(data => {
      this.source.load(data);
    })
  }

  onRowSelect(event){
    this.selectedUser = event.selected;
  }
  cancel(event)
  {
    this._ref.close();
  }
  saveSelectedBookings(event)
  {
    let p = this.source;
    // if(this.selectedBookings.length > 0)
    // {
    //   this.bookingSharedService.setBookings(this.selectedBookings);
    //   this.ref.close();
    // }
    // const data = {
    //   name : this.
    // }
    const data = [];
    this.selectedUser.forEach(user => {
      data.push({
        id: user.id,
        name: user.firstName + " " + user.lastName,
        email: user.email,
        permissionId: 1
      })
    })
    this._ref.close(data);
  }
}
