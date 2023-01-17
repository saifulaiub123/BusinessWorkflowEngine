import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "../../../environments/environment";
import { BookingFilterModel } from "../model/booking-filter-model";
import { BookingModel } from "../model/booking-model";
import { BookingPageModel } from "../model/booking-page-model";
import { BookingViewModel } from "../model/booking-view-model";
@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private api: string = environment.apiUrl + "/Booking";
  constructor(private http: HttpClient){

  }

  getInitialPageData(): Observable<BookingPageModel>{
    return this.http.get<BookingPageModel>(`${this.api}/GetInitialPageData`);
  }
  getBookings(): Observable<BookingViewModel[]>{
    return this.http.get<BookingViewModel[]>(`${this.api}/GetBookings`);
  }
  getBookingsByFilter(filter: BookingFilterModel): Observable<any>{
    return this.http.post(`${this.api}/GetBookingsByFilter`,filter);
  }
  getBookingsById(id: Number): Observable<BookingViewModel>{
    return this.http.get<BookingViewModel>(`${this.api}/GetBookingById?id=`+id);
  }
  getBookingsByOperationId(operationId: Number): Observable<BookingViewModel[]>{
    return this.http.get<BookingViewModel[]>(`${this.api}/GetBookingsByOperationId?operationId=`+operationId);
  }
  addBooking(booking: BookingModel): Observable<any>{
    return this.http.post(`${this.api}/AddBooking`,booking);
  }
  updateBooking(booking: BookingModel): Observable<any>{
    return this.http.patch(`${this.api}/UpdateBooking`,booking);
  }
  deleteBooking(id: Number): Observable<any>{
    return this.http.delete<any>(`${this.api}/DeleteBooking?id=`+id);
  }
}
