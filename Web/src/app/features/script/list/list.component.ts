import { ScriptService } from './../../../@core/services/script.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { InitUserService } from '../../../@theme/services/init-user.service';
import { Script } from '../../../@core/model/script';

@Component({
  selector: 'ngx-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

sourceScripts: LocalDataSource = new LocalDataSource();

settingsSourceScript = {
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
      filter: true,
    },
    description: {
      title: 'Description',
      type: 'string',
      filter:false,
    },
    destinationServerName: {
      title: 'Destination Server',
      type: 'string',
      filter:true,
    },
    action: {
      title: 'Action',
      type: 'custom',
      renderComponent: UserCustomActionComponent,
      valuePrepareFunction: (value, row, cell) => {
        return {
          id : row.id,
          edit : false,
          delete : true,
        };
      },
      filter: false,
    }
  },
  attr: {
    class: 'table table-bordered'
  }
};
  constructor(private router: Router,
    private _scriptService: ScriptService,
    private _initUserService: InitUserService
    ) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData()
  {
    const user = this._initUserService.getCurrentUser();
    this._scriptService.getScriptsByUserId(user.id).subscribe((data : Script[]) => {
      this.sourceScripts.load(data);
    })
  }
  navigateToAddScript()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }

}
