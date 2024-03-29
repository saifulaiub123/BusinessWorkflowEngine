import { CustomDeleteComponent } from './../../../@components/custom-smart-table-components/custom-delete/custom-delete.component';
import { ScriptService } from './../../../@core/services/script.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NbToastrService, NbDialogService } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { forkJoin } from 'rxjs';
import { Server } from '../../../@core/model/server';
import { ServerService } from '../../../@core/services/server.service';
import { UserService } from '../../../@core/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { UserListScriptModalComponent } from '../../user/modal/user-list-script-modal/user-list-script-modal.component';
import { CustomNbSelectComponent } from '../../../@components/custom-smart-table-components/custom-nb-select/custom-nb-select.component';
import { PermissionService } from '../../../@core/services/permission.service';
import { PermissionStore } from '../../../@core/stores/permission.store';
import { User } from '../../../@core/model/user';
import { ScriptUserPermission } from '../../../@core/model/script-user-permission';
import { InitUserService } from '../../../@theme/services/init-user.service';
import { Script } from '../../../@core/model/script';
import { isAdminOrScriptOwner } from '../../../@core/helper/script.helper';
import { ILoginUser } from '../../../@core/interfaces/common/ILoginUser';
import { SharedScriptUser } from '../../../@core/view-model/shared-script-user';
import { SmartTableSharedervice } from '../../../@core/shared-service/smart-table-shared.service';
import * as _ from "underscore";

@Component({
  selector: 'ngx-script-add-edit',
  templateUrl: './script-add-edit.component.html',
  styleUrls: ['./script-add-edit.component.scss']
})
export class ScriptAddEditComponent implements OnInit {

@Input() scriptId : number = 0;
@Input() actionMode: string = 'add' || 'edit' || 'view';


serverData: Server[] = [];
selectedRoles: number[] = [];
script: Script = {};
sharedScriptUser: SharedScriptUser[] = [];
scriptUserPermissions: ScriptUserPermission[] = [];
currentUser: ILoginUser = {};
checkArray: FormArray;
scriptAddEditFormGroup: FormGroup;

deletedUserPermissions: any[] = [];

sourceUserList: LocalDataSource = new LocalDataSource();

submitted: boolean = false;
loading = false;
isFormValid = false;
isAdminOrScriptOwner: boolean = false;
isViewMode: boolean = true;

pageTitle: string = "Script Add/Edit"

settingsUserList = {
  edit : false,
  delete : false,
  add : false,
  actions: {
    add: false,
    delete: false,
    edit: false,
    position: 'right'
  },
   hideSubHeader : true,
   noDataMessage : "No shared user found",
   columns: {
    userId: {
      title: 'Id',
      type: 'number',
      filter: false,
      hide: false
    },
    name: {
      title: 'Name',
      type: 'string',
      filter: true,
    },
    email: {
      title: 'Email',
      type: 'string',
      filter:true,
    },
    permissionId:{
      title: 'PermissionId',
      type: 'number',
      defaultValue: 1,
      hide: true
    },
    permission: {
      title: 'Permission',
      type: 'custom',
      renderComponent: CustomNbSelectComponent,
      valuePrepareFunction: (cell, row, value) => {
        return {
          permissionId : row.permissionId,
          actionMode : this.actionMode
        };
      },
      onComponentInitFunction(instance) {
        instance.save.subscribe(row => {
        });
      },
      filter: false,
    },
    action: {
      title : "Action",
      type: 'custom',
      renderComponent: CustomDeleteComponent,
      valuePrepareFunction: (cell, row, value) => {
        return {actionMode : this.actionMode};
      },
      onComponentInitFunction(instance) {
      },
      filter: false,
    }
  },
  attr: {
    class: 'table table-bordered'
  }
};

  constructor(
    private _userService: UserService,
    private _permissionService: PermissionService,
    private _serverService: ServerService,
    private _scriptService: ScriptService,
    private _initUserService: InitUserService,
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    private _route: ActivatedRoute,
    private _dialogService: NbDialogService,
    private _permissionStore: PermissionStore,
    private _tableSharedService: SmartTableSharedervice
    ) { }


    get id() { return this.scriptAddEditFormGroup.get('id'); }
    get name() { return this.scriptAddEditFormGroup.get('name'); }
    get description() { return this.scriptAddEditFormGroup.get('description'); }
    get destinationServerId() { return this.scriptAddEditFormGroup.get('destinationServerId'); }
    get content() { return this.scriptAddEditFormGroup.get('content'); }
    get parameter() { return this.scriptAddEditFormGroup.get('parameter'); }


  ngOnInit(): void {
    this.currentUser = this._initUserService.getCurrentUser();
    this.scriptId = parseInt(this._route.snapshot.paramMap.get('id'));
    this.scriptId = isNaN(this.scriptId) ? 0 : this.scriptId;
    if(this.scriptId != 0)
    {
      this.actionMode = this._route.snapshot.paramMap.get('actionMode');
    }
    this.subscribeSharedData();
    this.createFormGroup();
    this.loadData();
  }

  subscribeSharedData(){
    this._tableSharedService.isDeleteSharedUser$.subscribe((row : any) => {
      if(!_.isEmpty(row))
      {
        this.removeFromSharedUserSource(row);
      }
     });
  }
  createFormGroup()
  {
    this.scriptAddEditFormGroup = this._fb.group({
      id: this._fb.control(null, []),
      name: this._fb.control({value: null,disabled: this.actionMode == 'view'}, [Validators.required]),
      description: this._fb.control({value: null,disabled: this.actionMode == 'view'}, []),
      sendTo: this._fb.control({value: null,disabled: this.actionMode == 'view'}, []),
      destinationServerId: this._fb.control({value: null,disabled: this.actionMode == 'view'}, [Validators.required]),
      content: this._fb.control({value: null,disabled: this.actionMode == 'view'},[Validators.required]),
      parameter: this._fb.control({value: null,disabled: this.actionMode == 'view'}, []),
    });
  }

  loadData()
  {
    const serverPromise = this._serverService.getAllServer();
    const permissionPromise = this._permissionService.getAllPermission();

    forkJoin([serverPromise,permissionPromise]).subscribe(responses => {
      this.serverData = responses[0];
      this._permissionStore.setUPermissions(responses[1]);
    });

    if(this.scriptId != 0)
    {
      const scriptByIdPromise = this._scriptService.getScriptById(this.scriptId,this.actionMode);
      const sharedScriptPromise = this._scriptService.getScriptSharedUser(this.scriptId);
      forkJoin([scriptByIdPromise, sharedScriptPromise]).subscribe(res =>{
        this.script = res[0];
        this.sharedScriptUser = res[1];

        this.isAdminOrScriptOwner = isAdminOrScriptOwner(this.script,this.currentUser);
        this.scriptAddEditFormGroup.patchValue(this.script);
        this.sourceUserList.load(this.sharedScriptUser);
      })
    }
  }
  submit()
  {
    this.loading = false;
    let data = this.scriptAddEditFormGroup.value;
    this.scriptUserPermissions = [];

    this.sourceUserList.getAll().then(async (userData) => {
      userData.forEach(data =>{
        this.scriptUserPermissions.push({
            scriptId : this.scriptId != 0 ? this.scriptId : null,
            userId : data.userId,
            permissionId: data.permissionId
          }
        )
      })
      data['scriptUserPermissions'] = this.scriptUserPermissions;

      if(this.scriptId == 0)
      {
        this._scriptService.addScript(data).subscribe(() =>{
          this._toastrService.success("Successfull","Added Successfully");
          this.scriptAddEditFormGroup.reset();
        })
      }
      else{
        data.id = this.scriptId;
        data['deletedScriptUserPermissions'] = this.deletedUserPermissions;

        this._scriptService.updateScript(data).subscribe(() => {
          this._toastrService.success("Successfull","Updated Successfully");
        })
      }
    });
  }

  onChange(fileList: FileList)
  {
    let file = fileList[0];
    let fileReader: FileReader = new FileReader();
    let self = this;
    fileReader.onloadend = function(x) {
      self.content.setValue(fileReader.result);
    }
    fileReader.readAsText(file);
  }

  removeFromSharedUserSource(row: any)
  {
    this.sourceUserList.remove(row);
    const isExist = this.deletedUserPermissions.some(function(el) {
      return el.userId === row.userId;
    });
    if(!isExist)
    {
      this.deletedUserPermissions.push({
        scriptId : this.scriptId != 0 ? this.scriptId : null,
        userId : row.userId,
        permissionId: row.permissionId
      });
    }
  }
  openUsersModal()
  {
    this._dialogService.open(UserListScriptModalComponent, {
      hasScroll: true,
      closeOnBackdropClick: true
    })
    .onClose.subscribe((data: any[]) => {
      data.forEach(item => {

        this.sourceUserList.getAll().then((data) =>{
        const isExist = data.some(function(el) {
          return el.userId === item.userId;
        });
        if(!isExist)
        {
          this.sourceUserList.prepend(item);
        }
        })
      })
    }
    );
  }
}


