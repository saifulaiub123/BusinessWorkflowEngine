import { SmartTableSharedervice } from './../../../@core/shared-service/smart-table-shared.service';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Ng2SmartTableComponent } from 'ng2-smart-table';
import { Permission } from '../../../@core/model/permission';
import { PermissionStore } from '../../../@core/stores/permission.store';

@Component({
  selector: 'ngx-custom-delete',
  templateUrl: './custom-delete.component.html',
  styleUrls: ['./custom-delete.component.scss']
})
export class CustomDeleteComponent implements OnInit {

  @Input() value: any;
  @Input() rowData: any;

  source: any;

  constructor(private _tableSharedService: SmartTableSharedervice) { }

  ngOnInit(): void {

  }
  onDelete(event)
  {
    //this.value.dataSet.data.shift();
    //this.value.dataSet.rows.shift();
    if(this.value.actionMode == 'edit')
    {
      this._tableSharedService.deleteSharedUser(this.rowData);
    }
  }
}
