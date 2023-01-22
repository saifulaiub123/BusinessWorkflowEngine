import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbDialogService } from '@nebular/theme';

@Component({
  selector: 'ngx-script-action-component',
  templateUrl: './script-action-component.component.html',
  styleUrls: ['./script-action-component.component.scss']
})
export class ScriptActionComponent implements OnInit {

  @Input() value: any = {};

  constructor(private _dialogService: NbDialogService,private _router : Router) { }

  ngOnInit() {
  }

  viewScript()
  {
    this._router.navigate(['/feature/script/add-edit',{id : this.value.id, actionMode: 'view'}]);
  }
  editScript()
  {

  }
  runScript()
  {

  }
  deleteScript()
  {

  }

}
