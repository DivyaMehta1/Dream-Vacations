import { NgForm, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BookingService } from 'src/app/shared/booking.service';
import { Booking } from 'src/app/shared/booking.model';
import {NgbRatingConfig} from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.css'],
  providers: [NgbRatingConfig]
})
export class ManageBookingComponent implements OnInit {
referenceNumber:string
bookingDetails:Booking
rating:number
  constructor(public service:BookingService,private toastr: ToastrService,public config:NgbRatingConfig) { }

  ngOnInit(): void {
    this.resetForm();
    this.referenceNumber = '';
    this.config.max = 5;
    this.rating=3;
  
      }
  resetForm(form?:NgForm){
    if(form!=null)
    form.resetForm();
    this.service.formData={
      ReferenceNumber:null,
      CheckInDate:null,
      CheckOutDate:null,
      BillingAddress:'',
      BillingAmount:null,
      CampId:null,
      Country:'',
      State:'',
      Contact:null,
      TotalNights:0,
      ZipCode:null,
      NoOfPeople:0
    }
  }

  /**
   * Called on Submission of ReferenceForm to get Details of Booking
   */
  onSubmit(){
    this.service.getBookingDetails(this.referenceNumber).subscribe(res=>{
    this.bookingDetails=res as Booking
    })
    if(this.service.error!==undefined)
    {
      document.getElementById('error').innerHTML='No Bookings Found with Given ReferenceNumber';
    }
  }

  /**
   * Called on Cancel booking button
   */
  cancelBooking():void{
    this.service.deleteBooking(this.referenceNumber).subscribe(res=>{
      if (res==true)
      {
        this.referenceNumber=null;
        this.toastr.success('Your Booking has been Cancelled'); 
      }
      else
      {
        this.toastr.show(" Plase Try Again!")
      }
    },
    error=>{
      this.toastr.show("Bookings with Past dates cant be deleted")
    }

    );
    
  }
  /**
   * Determines whether checkoutDate is past 
   * @returns true if past 
   */
  isPast():boolean{
    var today = new Date();
    var checkOutDate = new Date(this.bookingDetails.CheckOutDate);
    if(checkOutDate<today)
    {
      return true;
    }
    else 
    {
      return false;

    }
    
  }
  rateCamp(rating){

    this.service.rateCamp(this.bookingDetails.CampId,rating).subscribe(res=>{
      console.log('successfuly rated');
      this.toastr.success("Thanks for Rating")
      
    });
      error=>{
        console.log(error);
      };
  }
  


    
}
