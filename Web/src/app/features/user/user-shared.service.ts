import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserSharedService {

  private userUpdated$ = new BehaviorSubject<boolean>(false);

  isUserUpdated$ = this.userUpdated$.asObservable();

  constructor() {}
  setUserUpdateStatus(status: boolean)
  {
    this.userUpdated$.next(status);
  }
}
