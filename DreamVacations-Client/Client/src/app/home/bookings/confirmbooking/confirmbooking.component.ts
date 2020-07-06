import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit } from '@angular/core';
import { CampService } from 'src/app/shared/camp.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Camp } from 'src/app/shared/camp.model';
import { Booking } from 'src/app/shared/booking.model';
import { BookingService } from 'src/app/shared/booking.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-confirmbooking',
  templateUrl: './confirmbooking.component.html',
  styleUrls: ['./confirmbooking.component.css']
})
export class ConfirmbookingComponent implements OnInit {
  campId:string
  checkIn:any
  checkOut:any
  capacity:number
  numberOfDays:number
  formData:Booking
  selectedCamp:Camp
  message:string
  constructor(public campService:CampService,public bookingService:BookingService,private activatedRouter:ActivatedRoute,private router:Router,private toastr: ToastrService,private sanitizer:DomSanitizer) {
       
  }

       /**
        * on init Retrieve CampId,checkin,checkout,capacity  
        * get CampDetails of Given Camp
        * & Calculate No.OfDays based on checkin & checkout
        * @param [form] 
        */
       ngOnInit(form?:NgForm): void {
        
        this.selectedCamp= new Camp();
        this.formData= new Booking();
        
        this.campId=this.activatedRouter.snapshot.paramMap.get('id');
        this.checkIn=this.activatedRouter.snapshot.paramMap.get('checkin');
        this.checkOut=this.activatedRouter.snapshot.paramMap.get('checkout');
        this.capacity= Number.parseInt(this.activatedRouter.snapshot.paramMap.get('capacity'));
        this.getCamp(this.campId);
        
        this.numberOfDays=this.getNoOfDays(this.checkIn,this.checkOut);
        this.resetForm(this.formData);
        console.log(typeof this.checkOut);
        
      }

  /**
   * Resets form
   * @param formData 
   */
  resetForm(formData:Booking):void{
    formData=null;
  }

  /**
   * Gets campDetails with given Id as param
   * @param campId 
   */
  getCamp(campId:string):void{
    this.campService.getCamp(campId).subscribe(res=>
      {
        this.selectedCamp= res as Camp;
        console.log(this.selectedCamp);
     
      }
     ),
     error=>{
       console.log(error);
     }
   
  }
  
  /**
   * Called when BookingForm is Submitted
   * Uploads formData & calls API
   */
  onSubmit(){
    console.log(this.formData.CampId);
   this.formData.CampId= this.campId;
   this.formData.CheckInDate=this.checkIn;
   this.formData.CheckOutDate=this.checkOut;
   this.formData.NoOfPeople=this.capacity;
   this.formData.TotalNights=this.numberOfDays
   if(this.isWeekend())
   {
    this.formData.BillingAmount=this.numberOfDays*this.selectedCamp.Amount*0.7;
   }
   else
   {
    this.formData.BillingAmount=this.numberOfDays*this.selectedCamp.Amount;
   
   }
   this.bookingService.postBooking(this.formData).subscribe(res=>{
  
    if(res.toString().localeCompare("Booked"))
     {
      this.message ="Your Camp has been successfully booked for"+this.checkIn+" to "+this.checkOut;
      this.router.navigate(['/confirmationScreen',res,this.message]);
      
     }
     else 
     {
       this.toastr.info("Camp Already Booked")
       this.router.navigate(['/dashboard']);
     }
   },
   error=>{
     console.log(error);
   });
   
  }

  /**
   * Calculates  no of days
   * @param checkin 
   * @param checkout 
   * @returns no of days 
   */
  getNoOfDays(checkin,checkout):number{
        var date2 = new Date(checkout);
        var date1 = new Date(checkin);
        var Difference_In_Time = date2.getTime() - date1.getTime(); 
        return  (Difference_In_Time / (1000 * 3600 * 24))+1;
        
  }

  /**
   * Determines whether weekend is
   * @returns true if weekend 
   */
  isWeekend():boolean{
    var day = new Date(this.checkIn).getDay();
    var isWeekend= (day === 6) || (day === 0) || (day===5);
    return isWeekend;
  }
  /**
   *Transform Image from 64BaseString to Image.jpg
   * @param base64Image 
   * @returns  Jpg Format
   */
  imageTransform(base64Image){
    base64Image = 'data:image/jpg;base64,' + (this.sanitizer.bypassSecurityTrustResourceUrl(base64Image) as any).changingThisBreaksApplicationSecurity;
    return this.sanitizer.bypassSecurityTrustResourceUrl(base64Image);
}

  
}
