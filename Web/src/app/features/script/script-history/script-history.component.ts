import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { Subject, forkJoin } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ScriptActionComponent } from '../../../@components/custom-smart-table-components/script-action-component/script-action.component';
import { ScriptHistoryResultComponent } from '../../../@components/custom-smart-table-components/script-history-result/script-history-result.component';
import { ScriptHistoryStatusComponent } from '../../../@components/custom-smart-table-components/script-history-status/script-history-status.component';
import { PermissionType } from '../../../@core/enum/PermissionType';
import { Script } from '../../../@core/model/script';
import { ScriptHistory } from '../../../@core/model/script-history';
import { ScriptHistoryService } from '../../../@core/services/script-history.service';
import { ScriptService } from '../../../@core/services/script.service';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import { InitUserService } from '../../../@theme/services/init-user.service';
import { ROLES } from '../../../auth/roles';

@Component({
  selector: 'ngx-script-history',
  templateUrl: './script-history.component.html',
  styleUrls: ['./script-history.component.scss']
})
export class ScriptHistoryComponent implements OnInit {

  scriptHitory: ScriptHistory[] = [];
  isAdmin: boolean = false;

  sourceScriptHistory: LocalDataSource = new LocalDataSource();

  ngDestroy = new Subject();

  settingsSourceScriptHistory = {
    edit : false,
    delete : false,
    add : false,
    actions: {
      add: false,
      delete: false,
      edit: false
    },
    hideSubHeader : true,
    noDataMessage : "No history found",
    columns: {
      id: {
        title: 'Id',
        type: 'number',
        filter: false,
        hide: true
      },
      scriptId: {
        title: 'Script Id',
        type: 'html',
        valuePrepareFunction: (value, row, cell) => {
          return '<a href="#/feature/script/add-edit;id='+value+';actionMode=view">'+value+'</a>';
        }
      },
      scriptName: {
        title: 'Script',
        type: 'string',
        filter: false,
      },
      status: {
        title: 'Status',
        type: 'custom',
        renderComponent: ScriptHistoryStatusComponent,
        valuePrepareFunction: (value, row, cell) => {
          return value;
        }
      },
      dateCreated: {
        title: 'Created On',
        type: 'string',
        filter:false,
        valuePrepareFunction: (value, row, cell) => {
          return new Date(value).toLocaleDateString('en-US', { hour: 'numeric',minute: 'numeric', hour12: true });
        }
      },
      output: {
        title: 'Output',
        type: 'custom',
        renderComponent: ScriptHistoryResultComponent,
        valuePrepareFunction: (value, row, cell) => {
          return value;
        }
      },
      createdByName: {
        title: 'Executed By',
        type: 'string',
        filter: false,
      },
      scriptOwnerName: {
        title: 'Script Owner',
        type: 'string',
        filter: false,
      },
    },
    attr: {
      class: 'table table-bordered'
    }
  };

  constructor(private router: Router,
    private _scriptService: ScriptService,
    private _scriptHistoryService: ScriptHistoryService,
    private _initUserService: InitUserService,
    private _tableSharedService: SmartTableSharedervice,
    private _toastrService: NbToastrService,
    ) {}

  ngOnInit(): void {
    this.subscribeSharedData();
    this.loadData();
  }
  subscribeSharedData(){
    // this._tableSharedService.isDeleteScript$.pipe(takeUntil(this.ngDestroy)).subscribe((row : any) => {
    //   if(!_.isEmpty(row))
    //   {
    //     this.sourceScripts.remove(row);
    //     this.sourceSharedScripts.remove(row);
    //     this.deleteScript(row.id);
    //   }
    // });
    // this._tableSharedService.isRunScript$.pipe(takeUntil(this.ngDestroy)).subscribe((row : any) => {
    //   if(!_.isEmpty(row))
    //   {
    //     this.runScript(row.id);
    //   }
    // });
  }
  loadData()
  {
    const user = this._initUserService.getCurrentUser();
    if(user.role.includes(ROLES.ADMIN))
    {
      this.isAdmin = true;
    }
    this._scriptHistoryService.getByUserId(user.id).subscribe((data) => {
      this.sourceScriptHistory.load(data);
    });
  }

  navigateToScript()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }
  ngOnDestroy(): void {
    this.ngDestroy.next(true);
    this.ngDestroy.complete();
    this._tableSharedService.unsetDeleteScript();
    this._tableSharedService.unsetRunScript();
  }
}
