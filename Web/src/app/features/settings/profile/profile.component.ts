import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NbToastrService } from '@nebular/theme';
import { Role } from '../../../@core/model/role';
import { User } from '../../../@core/model/user';
import { RoleService } from '../../../@core/services/role.service';
import { UserService } from '../../../@core/services/user.service';
import { UserSharedService } from '../../user/user-shared.service';
import { getDeepFromObject } from '../../../auth/helpers';
import { NB_AUTH_OPTIONS } from '@nebular/auth';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  @Input() userId : number = 0;

  user: User = {};
  rolesData: Role[] = [];
  selectedRoles: number[] = [];
  checkArray: FormArray;
  userAddEditFormGroup: FormGroup;

  submitted: boolean = false;
  loading = false;
  isFormValid = false;
  isEditMode = this.userId != 0 ? true : false;
  isAdmin: boolean;

  pageTitle: string = "Profile"


  minLoginLength: number = this.getConfigValue(('forms.validation.name.minLength'));
  maxLoginLength: number = this.getConfigValue(('forms.validation.name.maxLength'));
  minLength: number = this.getConfigValue('forms.validation.password.minLength');
  maxLength: number = this.getConfigValue('forms.validation.password.maxLength');



  constructor(
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    private _userService: UserService,
    private _roleService: RoleService,
    private _userSharedService: UserSharedService,
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    ) { }


    get name() { return this.userAddEditFormGroup.get('name'); }
    get email() { return this.userAddEditFormGroup.get('email'); }
    get phoneNumber() { return this.userAddEditFormGroup.get('phoneNumber'); }
    get roles() { return <FormArray> this.userAddEditFormGroup.get('roles'); }

  ngOnInit(): void {

    const currentUser = (JSON.parse(localStorage.getItem("UserData")));
    this.userId = currentUser.id;
    this.isAdmin = true;
    if(currentUser.role.includes('Admin'))
    {
      this.isAdmin = true;
    }

    this. createFormGroup();
    this.loadData();
  }
  createFormGroup()
  {

    const passwordValidators = [
      Validators.minLength(this.minLength),
      Validators.maxLength(this.maxLength),
    ];

    this.userAddEditFormGroup = this._fb.group({
      id: this._fb.control(null, [Validators.required]),
      name: this._fb.control(null, [Validators.required]),
      email: this._fb.control(null, [Validators.required]),
      phoneNumber: this._fb.control(null, []),
      roles: this._fb.array([],Validators.min(1))
    });
  }

  loadData()
  {
    this._roleService.getRoles().subscribe(data => {
      this.rolesData = data;
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
    this.loading = true;
    this.submitted = true;
    let data = this.userAddEditFormGroup.value;
    this._userService.updateUser(data).subscribe(() =>{
      this._userSharedService.setUserUpdateStatus(true);
      this.loading = false;
      this._toastrService.success("Successfull","Updated Successfully");
    })
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }
}


