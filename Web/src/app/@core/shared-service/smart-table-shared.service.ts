import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SmartTableSharedervice {

  private deleteRow$ = new BehaviorSubject<boolean>(false);
  idDeleteRow$ = this.deleteRow$.asObservable();

  private deleteScript$ = new BehaviorSubject(null);
  isDeleteScript$ = this.deleteScript$.asObservable();

  private deleteSharedUser$ = new BehaviorSubject<boolean>(false);
  isDeleteSharedUser$ = this.deleteSharedUser$.asObservable();

  private runScript$ = new BehaviorSubject(null);
  isRunScript$ = this.runScript$.asObservable();

  constructor() {}
  deleteScript(row: any)
  {
    this.deleteScript$.next(row);
  }
  unsetDeleteScript()
  {
    this.deleteScript$.next(null);
  }

  deleteSharedUser(row: any)
  {
    this.deleteSharedUser$.next(row);
  }

  deleteRow(row: any)
  {
    this.deleteRow$.next(row);
  }

  runScript(data: any)
  {
    this.runScript$.next(data);
  }
  unsetRunScript()
  {
    this.runScript(null);
  }
}
