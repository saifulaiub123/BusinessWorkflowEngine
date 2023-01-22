import { ScriptService } from './../../../@core/services/script.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NbToastrService, NbDialogRef, NbDialogService } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { forkJoin } from 'rxjs';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { Role } from '../../../@core/model/role';
import { Server } from '../../../@core/model/server';
import { RoleService } from '../../../@core/services/role.service';
import { ServerService } from '../../../@core/services/server.service';
import { UserService } from '../../../@core/services/user.service';
import { UserAddEditComponent } from '../../user/add-edit/user-add-edit.component';
import { UserSharedService } from '../../user/user-shared.service';
import { ActivatedRoute } from '@angular/router';
import { UserListScriptModalComponent } from '../../user/modal/user-list-script-modal/user-list-script-modal.component';
import { CustomNbSelectComponent } from '../../../@components/custom-smart-table-components/custom-nb-select/custom-nb-select.component';
import { PermissionService } from '../../../@core/services/permission.service';
import { PermissionStore } from '../../../@core/stores/permission.store';
import { User } from '../../../@core/model/user';

@Component({
  selector: 'ngx-script-add-edit',
  templateUrl: './script-add-edit.component.html',
  styleUrls: ['./script-add-edit.component.scss']
})
export class ScriptAddEditComponent implements OnInit {

@Input() scriptId : number = 0;
@Input() actionMode: string;


serverData: Server[] = [];
selectedRoles: number[] = [];
checkArray: FormArray;
scriptAddEditFormGroup: FormGroup;
sourceUserList: LocalDataSource = new LocalDataSource();

submitted: boolean = false;
loading = false;
isFormValid = false;

pageTitle: string = "Script Add/Edit"



settingsUserList = {
  edit : false,
  delete : false,
  add : false,
  actions: {
    add: false,
    delete: false,
    edit: false
  },
   hideSubHeader : true,
   noDataMessage : "No shared user found",
   columns: {
    id: {
      title: 'Id',
      type: 'number',
      filter: false,
      hide: false
    },
    name: {
      title: 'Name',
      type: 'string',
      filter: true,
      valuePrepareFunction: (value, row, cell) => {
        return row.name;
       },
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

        return row.permissionId;
      },
      onComponentInitFunction(instance) {
        instance.save.subscribe(row => {
           console.log(row);
        });
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
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    private _route: ActivatedRoute,
    private _dialogService: NbDialogService,
    private _permissionStore: PermissionStore,
    ) { }


    get id() { return this.scriptAddEditFormGroup.get('id'); }
    get name() { return this.scriptAddEditFormGroup.get('name'); }
    get description() { return this.scriptAddEditFormGroup.get('description'); }
    get destinationServerId() { return this.scriptAddEditFormGroup.get('destinationServerId'); }
    get content() { return this.scriptAddEditFormGroup.get('content'); }


  ngOnInit(): void {

    this.scriptId = parseInt(this._route.snapshot.paramMap.get('id'));
    this.scriptId = isNaN(this.scriptId) ? 0 : this.scriptId;
    this.actionMode = this._route.snapshot.paramMap.get('actionMode');
    this.createFormGroup();
    this.loadData();
  }
  createFormGroup()
  {
    this.scriptAddEditFormGroup = this._fb.group({
      id: this._fb.control(null, []),
      name: this._fb.control({value: null,disabled: this.actionMode == 'view'}, [Validators.required]),
      description: this._fb.control({value: null,disabled: this.actionMode == 'view'}, [Validators.required]),
      destinationServerId: this._fb.control({value: null,disabled: this.actionMode == 'view'}, [Validators.required]),
      content: this._fb.control({value: null,disabled: this.actionMode == 'view'},[Validators.required])
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
        this._scriptService.getScriptById(this.scriptId).subscribe(data => {
        this.scriptAddEditFormGroup.patchValue(data);
      })
    }
  }


  // onCheckboxChange(e) {
  //    this.checkArray = this.userAddEditFormGroup.get('roles') as FormArray;
  //   if (e.target.checked) {
  //     this.checkArray.push(new FormControl(e.target.value));
  //   } else {
  //     let i: number = 0;
  //     this.checkArray.controls.forEach((item: FormControl) => {
  //       if (item.value == e.target.value) {
  //         this.checkArray.removeAt(i);
  //         return;
  //       }
  //       i++;
  //     });
  //   }
  // }
  submit()
  {
    this.loading = false;
    let data = this.scriptAddEditFormGroup.value;
    if(this.scriptId == 0)
    {
      this._scriptService.addScript(data).subscribe(() =>{
        this._toastrService.success("Successfull","Added Successfully");
      })
    }
    else{
      data.id = this.scriptId;
      this._scriptService.updateScript(data).subscribe(() =>{
        this._toastrService.success("Successfull","Updated Successfully");
      })
    }

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

  openUsersModal()
  {
    this._dialogService.open(UserListScriptModalComponent, {
      hasScroll: true,
      closeOnBackdropClick: true
    })
    .onClose.subscribe((data: User[]) => {
      let p = data;
      this.sourceUserList.load(data);
    }
    );
  }

}


