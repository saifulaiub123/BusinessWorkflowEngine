import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ViewCell } from 'ng2-smart-table';
import { Permission } from '../../../@core/model/permission';
import { Server } from '../../../@core/model/server';
import { PermissionStore } from '../../../@core/stores/permission.store';

@Component({
  selector: 'ngx-custom-nb-select',
  templateUrl: './custom-nb-select.component.html',
  styleUrls: ['./custom-nb-select.component.scss']
})
export class CustomNbSelectComponent implements ViewCell, OnInit {

   @Input() value: any;
   @Input() rowData: any;

   selectedPermissionId : number;
   isDisable : boolean;
   actionMode : string;

  permissions : Permission[] = [];

   @Output() save: EventEmitter<any> = new EventEmitter();

  constructor(private _permissionStore: PermissionStore,) { }

  ngOnInit(): void {
    this.selectedPermissionId = this.value.permissionId;
    this.isDisable  = this.value.actionMode == 'view' ? true : false;
    this.permissions = this._permissionStore.getUPermissions();
  }
  onChange(event)
  {
    this.rowData.permissionId = event;
    //this.save.emit(this.rowData)
  }

}
