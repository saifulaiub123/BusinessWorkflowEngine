import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { User } from '../../../@core/model/user';
import { UserService } from '../../../@core/services/user.service';
import { UserSharedService } from '../user-shared.service';

@Component({
  selector: 'ngx-user-pending',
  templateUrl: './user-pending.component.html',
  styleUrls: ['./user-pending.component.scss']
})
export class UserPendingComponent implements OnInit {

  users: User[] = [];

sourceUser: LocalDataSource = new LocalDataSource();

 settingsSourceUser = {
  edit : false,
    delete : false,
    add : false,
  actions: {
    add: false,
    delete: false,
    edit: false
  },
   hideSubHeader : false,
   noDataMessage : "No data found",
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
        return row.firstName + " " + row.lastName;
      },
    },
    email: {
      title: 'Email',
      type: 'string',
      filter:true,
    },
    action: {
      title: 'Action',
      type: 'custom',
      renderComponent: UserCustomActionComponent,
      valuePrepareFunction: (value, row, cell) => {
        return row.id;
      },
      filter: false,
    }
  },
  attr: {
    class: 'table table-bordered'
  }
};

  constructor(private _userService: UserService,private _userSharedService: UserSharedService,private _toastrService: NbToastrService,) { }
  ngOnDestroy(): void {
      this._userSharedService.deleteUser(0);
  }

  ngOnInit(): void {
    this.subscribeSharedData();
    this.loadData();
  }
  subscribeSharedData(){
    this._userSharedService.isUserUpdated$.subscribe((status : boolean) => {
      if(status)
      {
        this.loadData();
      }
     });
  }

  loadData()
  {
    this._userService.getPendingUsers().subscribe(data => {
      this.users = data;
      this.sourceUser.load(data);
    })
  }

}
