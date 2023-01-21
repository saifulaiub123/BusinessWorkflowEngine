import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NbToastrService, NbDialogRef } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { forkJoin } from 'rxjs';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { User } from '../../../@core/data/users';
import { Role } from '../../../@core/model/role';
import { Server } from '../../../@core/model/server';
import { RoleService } from '../../../@core/services/role.service';
import { ServerService } from '../../../@core/services/server.service';
import { UserService } from '../../../@core/services/user.service';
import { UserAddEditComponent } from '../../user/add-edit/user-add-edit.component';
import { UserSharedService } from '../../user/user-shared.service';

@Component({
  selector: 'ngx-script-add-edit',
  templateUrl: './script-add-edit.component.html',
  styleUrls: ['./script-add-edit.component.scss']
})
export class ScriptAddEditComponent implements OnInit {

@Input() userId : number = 1;

serverData: Server[] = [];
selectedRoles: number[] = [];
checkArray: FormArray;
scriptAddEditFormGroup: FormGroup;
sourceUser: LocalDataSource = new LocalDataSource();

submitted: boolean = false;
loading = false;
isFormValid = false;
isEditMode = this.userId != 0 ? true : false;

pageTitle: string = "Script Add/Edit"



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
      filter: true,
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
    action: {
      title: 'Action',
      type: 'custom',
      renderComponent: UserCustomActionComponent,
      valuePrepareFunction: (value, row, cell) => {
        return value;
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
    private _serverService: ServerService,
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    ) { }


    get id() { return this.scriptAddEditFormGroup.get('id'); }
    get name() { return this.scriptAddEditFormGroup.get('name'); }
    get description() { return this.scriptAddEditFormGroup.get('description'); }
    get destinationServerId() { return <FormArray> this.scriptAddEditFormGroup.get('destinationServerId'); }
    get content() { return <FormArray> this.scriptAddEditFormGroup.get('content'); }


  ngOnInit(): void {
    this.createFormGroup();
    this.loadData();
  }
  createFormGroup()
  {
    this.scriptAddEditFormGroup = this._fb.group({
      id: this._fb.control(null, [Validators.required]),
      name: this._fb.control(null, [Validators.required]),
      description: this._fb.control(null, [Validators.required]),
      destinationServerId: this._fb.control(null, []),
      content: this._fb.array([],Validators.min(1))
    });
  }

  loadData()
  {
    // const serverPromise = this._serverService.getAllServer();
    // forkJoin([serverPromise]).subscribe(responses => {
    //   this.serverData = responses[0];
    // });

    if(this.userId != 0)
    {
      this._serverService.getAllServer().subscribe(data => {
        //this.user = data;
      let p = data;

      //this.userAddEditFormGroup.patchValue(data);
    })
        this._userService.getUserById(this.userId).subscribe(data => {
          //this.user = data;
        let p = data;

        //this.userAddEditFormGroup.patchValue(data);
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
  // submit()
  // {
  //   this.loading = false;
  //   let data = this.userAddEditFormGroup.value;
  //   this._userService.updateUser(data).subscribe(() =>{
  //     this._userSharedService.setUserUpdateStatus(true);
  //     this._toastrService.success("Successfull","Updated Successfully");
  //     this._modalRef.close(true);
  //   })
  // }
  submit()
  {

  }

}


