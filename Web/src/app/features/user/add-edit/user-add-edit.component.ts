import { UserRole } from './../../../@core/model/user-role';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { LocalDataSource } from 'ng2-smart-table';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';
import { Role } from '../../../@core/model/role';
import { User } from '../../../@core/model/user';
import { RoleService } from '../../../@core/services/role.service';
import { UserService } from '../../../@core/services/user.service';
import { UserSharedService } from '../user-shared.service';
import { Status } from '../../../@core/model/status';

@Component({
  selector: 'app-user-add-edit',
  templateUrl: './user-add-edit.component.html',
  styleUrls: ['./user-add-edit.component.scss']
})
export class UserAddEditComponent implements OnInit {

@Input() userId : number = 0;

user: User = {};
rolesData: Role[] = [];
statusData: Status[] = [];

selectedRoles: number[] = [];
checkArray: FormArray;
userAddEditFormGroup: FormGroup;

submitted: boolean = false;
loading = false;
isFormValid = false;
isEditMode = this.userId != 0 ? true : false;

pageTitle: string = "User Edit"

  constructor(
    private _userService: UserService,
    private _roleService: RoleService,
    private _userSharedService: UserSharedService,
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    protected _modalRef: NbDialogRef<UserAddEditComponent>,
    ) { }


    get firstName() { return this.userAddEditFormGroup.get('firstName'); }
    get lastName() { return this.userAddEditFormGroup.get('lastName'); }
    get email() { return this.userAddEditFormGroup.get('email'); }
    // get phoneNumber() { return this.userAddEditFormGroup.get('phoneNumber'); }
    get roles() { return <FormArray> this.userAddEditFormGroup.get('roles'); }
    get statusId() { return <FormArray> this.userAddEditFormGroup.get('statusId'); }


  ngOnInit(): void {
    this.createFormGroup();
    this.loadData();
  }
  createFormGroup()
  {
    this.userAddEditFormGroup = this._fb.group({
      id: this._fb.control(null, [Validators.required]),
      firstName: this._fb.control(null, [Validators.required]),
      lastName: this._fb.control(null, [Validators.required]),
      email: this._fb.control(null, [Validators.required]),
      // phoneNumber: this._fb.control(null, []),
      roles: this._fb.array([],Validators.min(1)),
      statusId: this._fb.control(null, [Validators.required])
    });
  }

  loadData()
  {
    this._roleService.getRoles().subscribe(data => {
      this.rolesData = data;
    })
    this._userService.getAllStatus().subscribe(data => {
      this.statusData = data;
    })
    if(this.userId != 0)
    {
      this._userService.getUserById(this.userId).subscribe(data => {
        this.user = data;
      const checkArray: FormArray = this.userAddEditFormGroup.get('roles') as FormArray;
        this.user.userRoles.map(x => {
          checkArray.push(new FormControl(x.roleId));
        })
        this.userAddEditFormGroup.patchValue(data);
      })
    }
  }


  onCheckboxChange(e) {
     this.checkArray = this.userAddEditFormGroup.get('roles') as FormArray;
    if (e.target.checked) {
      this.checkArray.push(new FormControl(e.target.value));
    } else {
      let i: number = 0;
      this.checkArray.controls.forEach((item: FormControl) => {
        if (item.value == e.target.value) {
          this.checkArray.removeAt(i);
          return;
        }
        i++;
      });
    }
  }
  submit()
  {
    this.loading = false;
    let data = this.userAddEditFormGroup.value;
    this._userService.updateUser(data).subscribe(() =>{
      this._userSharedService.setUserUpdateStatus(true);
      this._toastrService.success("Successfull","Updated Successfully");
      this._modalRef.close(true);
    })
  }
  cancel()
  {
    this._modalRef.close();
  }

}


