import { Search } from './search.model';
import { Booking } from './booking.model';
import { Injectable } from '@angular/core';
import {  HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BookingService {
formData:Booking;
data:Booking;
error:any ;

  constructor(private http:HttpClient) { }
  getBookingDetails(referenceNumber)
  {
    
     return  this.http.get('https://localhost:44385/Api/bookings/GetBookingDetails/'+referenceNumber)
        
    
  }

  postBooking(formData){
    return this.http.post('https://localhost:44385/Api/bookings/book',formData);
      
  }
  deleteBooking(referenceNumber){
    return this.http.delete('https://localhost:44385/Api/bookings/CancelBooking/'+referenceNumber);

  }
  rateCamp(campId,rating){
    return this.http.post('https://localhost:44385/Api/camps/ratecamp/'+campId,rating);
  }
}

