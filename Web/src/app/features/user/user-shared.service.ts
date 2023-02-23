import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserSharedService {

  private userUpdated$ = new BehaviorSubject<boolean>(false);
  isUserUpdated$ = this.userUpdated$.asObservable();

  private deleteUser$ = new BehaviorSubject<number>(0);
  idDeleteUser$ = this.deleteUser$.asObservable();

  constructor() {}
  setUserUpdateStatus(status: boolean)
  {
    this.userUpdated$.next(status);
  }

  deleteUser(id: number)
  {
    this.deleteUser$.next(id);
  }
}
