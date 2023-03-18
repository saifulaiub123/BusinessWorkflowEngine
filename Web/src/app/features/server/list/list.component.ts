import { Router } from '@angular/router';
import { ServerSharedService } from './../server-shared.service';
import { ServerService } from './../../../@core/services/server.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { Server } from '../../../@core/model/server';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { ServerCustomActionComponent } from '../../../@components/custom-smart-table-components/server-custom-action/server-custom-action.component';
import { ServerAddEditComponent } from '../add-edit/add-edit.component';

@Component({
  selector: 'ngx-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ServerListComponent implements OnInit, OnDestroy {

  servers: Server[] = [];

  sourceServer: LocalDataSource = new LocalDataSource();

   settingsSourceServer = {
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
        filter: true
      },
      machineName: {
        title: 'Machine Name',
        type: 'string',
        filter: true,
      },
      ipAddress: {
        title: 'IP Address',
        type: 'string',
        filter: false,
      },
      action: {
        title: 'Action',
        type: 'custom',
        renderComponent: ServerCustomActionComponent,
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

    constructor(private _serverService: ServerService,
       private _toastrService: NbToastrService,
       private _serverSharedService: ServerSharedService,
       private _dialogService: NbDialogService,
       private _router: Router) { }
    ngOnDestroy(): void {
        // this._userSharedService.deleteUser(0);
    }

    ngOnInit(): void {
      this.subscribeSharedData();
      this.loadData();
    }
    subscribeSharedData(){
      this._serverSharedService.isServerUpdated$.subscribe((status : boolean) => {
        if(status)
        {
          this.loadData();
        }
       });
       this._serverSharedService.isDeleteServer$.subscribe((id : number) => {
        if(id > 0)
        {
          this.delete(id);
          this._serverSharedService.deleteServer(0);
        }
       });

    }

    loadData()
    {
      this._serverService.getAllServer().subscribe(data => {
        this.servers = data;
        this.sourceServer.load(data);
      })
    }

    delete(id: number)
    {
      this._serverService.delete(id).subscribe((data) =>{
          this._toastrService.success("Server deleted successfull","Delete Server",{ duration: 12000});
          this.loadData();
      })
    }

    navigateToAddServer()
    {
      // this._router.navigateByUrl('feature/server/add-edit')
      this._dialogService.open(ServerAddEditComponent, {
        hasScroll: false,
        closeOnBackdropClick: true,
        autoFocus: false,
        // context : {
        //   id : 0
        // }
      })
      .onClose.subscribe(value => {
        if(value)
        {
          this.loadData();
        }
      }
      );
    }

  }


