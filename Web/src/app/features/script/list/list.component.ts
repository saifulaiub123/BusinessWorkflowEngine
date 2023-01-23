import { ScriptService } from './../../../@core/services/script.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { InitUserService } from '../../../@theme/services/init-user.service';
import { Script } from '../../../@core/model/script';
import { ScriptActionComponent } from '../../../@components/custom-smart-table-components/script-action-component/script-action.component';
import { forkJoin } from 'rxjs';
import { PermissionType } from '../../../@core/enum/PermissionType';

@Component({
  selector: 'ngx-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  ownScripts: Script[] = [];
  sharedScripts: Script[] = [];

  sourceScripts: LocalDataSource = new LocalDataSource();
  sourceSharedScripts: LocalDataSource = new LocalDataSource();


  settingsSourceScript = {
      edit : false,
      delete : false,
      add : false,
    actions: {
      add: false,
      delete: false,
      edit: false
    },
    hideSubHeader : true,
    noDataMessage : "No script found",
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
        renderComponent: ScriptActionComponent,
        valuePrepareFunction: (value, row, cell) => {
          return {
            id : row.id,
            isViewable : true,
            isEditable : true,
            isDeletable : true,
            isRunnable : true,

          };
        },
        filter: false,
      }
    },
    attr: {
      class: 'table table-bordered'
    }
  };

  settingsSourceSharedScript = {
  edit : false,
  delete : false,
  add : false,
  actions: {
    add: false,
    delete: false,
    edit: false
  },
  hideSubHeader : false,
  noDataMessage : "No shared script found",
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
    },
    description: {
      title: 'Description',
      type: 'string',
      filter:false,
    },
    destinationServerName: {
      title: 'Destination Server',
      type: 'string',
      filter:false,
    },
    userName: {
      title: 'Shared By',
      type: 'string',
      filter:false,
    },
    action: {
      title: 'Action',
      type: 'custom',
      renderComponent: ScriptActionComponent,
      valuePrepareFunction: (value, row, cell) => {
        return {
          id : row.id,
          isViewable : true,
          isEditable : row.scriptUserPermissions[0].permissionId === PermissionType.Modify ? true : false,
          isDeletable : row.scriptUserPermissions[0].permissionId === PermissionType.Modify ? true : false,
          isRunnable : true,
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

    const ownScriptsPromise = this._scriptService.getScriptsByUserId(user.id);
    const sharedScriptsPromise = this._scriptService.getSharedScriptsByUserId(user.id);

    forkJoin([ownScriptsPromise,sharedScriptsPromise]).subscribe(responses => {
      this.ownScripts = responses[0];
      this.sharedScripts = responses[1];

      this.sourceScripts.load(this.ownScripts);
      this.sourceSharedScripts.load(this.sharedScripts);

    });
  }
  navigateToAddScript()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }

}
