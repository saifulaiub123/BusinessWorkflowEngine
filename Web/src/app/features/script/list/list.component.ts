import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { UserCustomActionComponent } from '../../../@components/custom-smart-table-components/user-custom-action/user-custom-action.component';

@Component({
  selector: 'ngx-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

sourceScripts: LocalDataSource = new LocalDataSource();

settingsSourceScript = {
    edit : false,
    delete : true,
    add : false,
  actions: {
    add: false,
    delete: true,
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
    description: {
      title: 'Description',
      type: 'string',
      filter:false,
    },
    destinationServerId: {
      title: 'Destination Server',
      type: 'string',
      filter:true,
    },
    action: {
      title: 'Action',
      type: 'custom',
      renderComponent: UserCustomActionComponent,
      valuePrepareFunction: (value, row, cell) => {
        return row.id;
      },
      filter: false,
    }
  },
  attr: {
    class: 'table table-bordered'
  }
};
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToAddScript()
  {
    this.router.navigateByUrl('feature/script/add-edit')
  }

}
