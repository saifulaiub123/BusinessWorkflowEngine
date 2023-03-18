import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { Server } from '../../../@core/model/server';
import { ServerService } from '../../../@core/services/server.service';

@Component({
  selector: 'ngx-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.scss']
})
export class ServerAddEditComponent implements OnInit {

  @Input() id : number = 0;

  server: Server = {};

  selectedRoles: number[] = [];
  serverAddEditFormGroup: FormGroup;

  submitted: boolean = false;
  loading = false;
  isFormValid = false;
  isEditMode = this.id != 0 ? true : false;

  pageTitle: string = "Server Edit"
    constructor(
      private _serverService: ServerService,
      private _fb: FormBuilder,
      private _toastrService: NbToastrService,
      protected _modalRef: NbDialogRef<ServerAddEditComponent>,
      ) { }


      get name() { return this.serverAddEditFormGroup.get('name'); }
      get machineName() { return this.serverAddEditFormGroup.get('machineName'); }
      get ipAddress() { return this.serverAddEditFormGroup.get('ipAddress'); }
      get userName() { return this.serverAddEditFormGroup.get('userName'); }
      get password() { return this.serverAddEditFormGroup.get('password'); }



    ngOnInit(): void {
      this.createFormGroup();
      this.loadData();
    }
    createFormGroup()
    {
      this.serverAddEditFormGroup = this._fb.group({
        // id: this._fb.control(null, [Validators.required]),
        name: this._fb.control(null, [Validators.required]),
        machineName: this._fb.control(null, [Validators.required]),
        ipAddress: this._fb.control(null, []),
        userName: this._fb.control(null,[Validators.required]),
        password: this._fb.control(null, [])
      });
    }

    loadData()
    {
      if(this.id > 0)
      {
        this._serverService.getServerById(this.id).subscribe(data => {
          this.server = data;
          this.serverAddEditFormGroup.patchValue(data);
        })
      }
    }

    submit()
    {
      this.loading = false;
      let data = this.serverAddEditFormGroup.value;
      if(this.id > 0)
      {
        data['id'] = this.id;
        this._serverService.updateServer(data).subscribe(() =>{
          this._toastrService.success("Successfull","Updated Successfully");
          this._modalRef.close(true);
        })
      }
      else{
        this._serverService.addServer(data).subscribe(() => {
          this._toastrService.success("Successfull","Added Successfully");
          this._modalRef.close(true);
        })
      }

    }
    cancel()
    {
      this._modalRef.close();
    }

  }
