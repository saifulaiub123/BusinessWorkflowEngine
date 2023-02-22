import { ScriptService } from './../../../@core/services/script.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { InitUserService } from '../../../@theme/services/init-user.service';
import { Script } from '../../../@core/model/script';
import { ScriptActionComponent } from '../../../@components/custom-smart-table-components/script-action-component/script-action.component';
import { forkJoin, Subject, Subscription } from 'rxjs';
import { PermissionType } from '../../../@core/enum/PermissionType';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import * as _ from "underscore";
import { NbToastrService } from '@nebular/theme';
import { ROLES } from '../../../auth/roles';
import { first, take, takeUntil, takeWhile } from 'rxjs/operators';
import { DatePipe } from '@angular/common';

const settings = require('../../../../environments/settings.json');

@Component({
  selector: 'ngx-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy  {

  ownScripts: Script[] = [];
  sharedScripts: Script[] = [];

  isAdmin: boolean = false;

  sourceScripts: LocalDataSource = new LocalDataSource();
  sourceSharedScripts: LocalDataSource = new LocalDataSource();

  ngDestroy = new Subject();

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
      userName: {
        title: 'Created By',
        type: 'string',
        filter: true,
      },
      dateCreated: {
        title: 'Created On',
        type: 'string',
        filter:false,
        valuePrepareFunction: (value, row, cell) => {
          return new Date(value).toLocaleDateString('en-US', { hour: 'numeric',minute: 'numeric', hour12: true });
          //return new DatePipe('en-US').transform(value, 'YYYY/MM/DD hh:mm')
        }
      },
      lastUpdated: {
        title: 'Modified On',
        type: 'string',
        filter:false,
        valuePrepareFunction: (value, row, cell) => {
          return new Date(value).toLocaleDateString('en-US', { hour: 'numeric',minute: 'numeric', hour12: true });
        }
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
    private _initUserService: InitUserService,
    private _tableSharedService: SmartTableSharedervice,
    private _toastrService: NbToastrService,
    ) {}

  ngOnInit(): void {
    this.subscribeSharedData();
    this.loadData();
  }
  subscribeSharedData(){
    this._tableSharedService.isDeleteScript$.pipe(takeUntil(this.ngDestroy)).subscribe((row : any) => {
      if(!_.isEmpty(row))
      {
        this.sourceScripts.remove(row);
        this.sourceSharedScripts.remove(row);
        this.deleteScript(row.id);
      }
    });
    this._tableSharedService.isRunScript$.pipe(takeUntil(this.ngDestroy)).subscribe((row : any) => {
      if(!_.isEmpty(row))
      {
        this.runScript(row.id);
      }
    });
  }
  loadData()
  {
    const user = this._initUserService.getCurrentUser();
    if(user.role.includes(ROLES.ADMIN))
    {
      this.isAdmin = true;
    }
    const ownScriptsPromise = this._scriptService.getScriptsByUserId(user.id);
    const sharedScriptsPromise = this._scriptService.getSharedScriptsByUserId(user.id);

    forkJoin([ownScriptsPromise,sharedScriptsPromise]).subscribe(responses => {
      this.ownScripts = responses[0];
      this.sharedScripts = responses[1];

      this.sourceScripts.load(this.ownScripts);
      this.sourceSharedScripts.load(this.sharedScripts);

    });
  }
  deleteScript(id: number)
  {
    this._scriptService.deleteScript(id).subscribe((data) =>{
      this._toastrService.success("Successfull","Deleted Successfully");
    })
  }
  runScript(id: number)
  {
    this._scriptService.runScript(id).subscribe((data) => {

    })
  }
  navigateToAddScript()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }
  navigateToScriptHistory()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }
  navigateToJobDashboard()
  {
    //window.open(settings.backendUrl + "/hangfire", "_blank");
    this.router.navigateByUrl('feature/hangfire')
  }

  ngOnDestroy(): void {
    this.ngDestroy.next(true);
    this.ngDestroy.complete();
    this._tableSharedService.unsetDeleteScript();
    this._tableSharedService.unsetRunScript();
  }
}
