import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NbToastrService } from '@nebular/theme';
import { User } from '../../../@core/model/user';
import { UserService } from '../../../@core/services/user.service';
import { UserSharedService } from '../../user/user-shared.service';
import { getDeepFromObject } from '../../../auth/helpers';
import { NB_AUTH_OPTIONS } from '@nebular/auth';
import { Router } from '@angular/router';


@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  user: User = {};
  userId: number = 0;
  changePasswordFormGroup: FormGroup;

  submitted: boolean = false;
  loading = false;
  isFormValid = false;
  isAdmin: boolean;

  pageTitle: string = "Change Password"


  minLoginLength: number = this.getConfigValue(('forms.validation.name.minLength'));
  maxLoginLength: number = this.getConfigValue(('forms.validation.name.maxLength'));
  minLength: number = this.getConfigValue('forms.validation.password.minLength');
  maxLength: number = this.getConfigValue('forms.validation.password.maxLength');



  constructor(
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    private _userService: UserService,
    private _fb: FormBuilder,
    private _toastrService: NbToastrService,
    private _router: Router
    ) { }


    get currentPassword() { return this.changePasswordFormGroup.get('currentPassword'); }
    get newPassword() { return this.changePasswordFormGroup.get('newPassword'); }
    get confirmPassword() { return this.changePasswordFormGroup.get('confirmPassword'); }

  ngOnInit(): void {

    const currentUser = (JSON.parse(localStorage.getItem("UserData")));
    this.userId = currentUser.id;
    this. createFormGroup();
  }
  createFormGroup()
  {

    const passwordValidators = [
      Validators.minLength(this.minLength),
      Validators.maxLength(this.maxLength),
    ];

    this.changePasswordFormGroup = this._fb.group({
      currentPassword: this._fb.control(null, [Validators.required]),
      newPassword: this._fb.control('', [...passwordValidators]),
      confirmPassword: this._fb.control('', [...passwordValidators]),
    });
  }

  update()
  {
    this.loading = true;
    this.submitted = true;
    let data = this.changePasswordFormGroup.value;
    data.id = this.userId;
    this._userService.changePassword(data).subscribe(() =>{
      this.loading = false;
      this.changePasswordFormGroup.reset();
      this._toastrService.success("Successfull","Updated Successfully");
      this._router.navigateByUrl("/auth/logout");
    })
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }
}


