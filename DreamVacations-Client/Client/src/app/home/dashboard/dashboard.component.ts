import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/shared/camp.model';
import { NgForm } from '@angular/forms';
import { CampService } from 'src/app/shared/camp.service';
import { Router } from '@angular/router';
import {NgbRatingConfig} from '@ng-bootstrap/ng-bootstrap';
import { DomSanitizer } from '@angular/platform-browser';

 

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [NgbRatingConfig]
})
export class DashboardComponent implements OnInit {
  checkin:string;
  checkout:string;
  capacity:number;
  filteredCamps:Camp[]
  p:number=1;
  currentRate = 5;
  constructor(public service:CampService ,private router: Router,config: NgbRatingConfig,private sanitizer:DomSanitizer){
    this.checkin = this.getDate(new Date(new Date().getTime()))    
    this.checkout = this.getDate(new Date(new Date().getTime() + 24 * 60 * 60 * 1000));
    this.capacity = 0;
    config.max = 5;
    config.readonly = true;
    }

    ngOnInit(): void {
      this.resetForm();
       
    }

    
    /**
     * Gets date from DatePicker Component & return in string format
     * @param d for DatePicker
     * @returns  
     */
    getDate(d):string {
      var output = d.getFullYear() + '-' +
          ((d.getMonth()+1)<10 ? '0' : '') + (d.getMonth()+1) + '-' +
          (d.getDate()<10 ? '0' : '') + d.getDate();
      return output ;
    }

    /**
     * Resets formData of Form inside Component
     * @param [form] 
     */
    resetForm(form?:NgForm){
      if(form!=null)
      form.reset;
    
    }
    
    /**
     * Called on SubmitForm for Search Functionality
     */
    onSubmit(){
      this.filterCamps();
    }

    /**
     * Filters camps on the basis of Search Filer
     */
    filterCamps(){
      console.log(this.checkin);
      this.service.searchCamps(this.checkin,this.checkout,this.capacity).subscribe(res=>
        this.filteredCamps= res as Camp[])
      }

      /**
       * Gets booking details of selcted Booking
       * @param campId 
       */
      getBookingDetails(campId:any){
  
        this.router.navigate(['/confirmBooking',campId,this.checkin,this.checkout,this.capacity]);
        
      }
      /**
       * Transforms 64BaseStringImage into Image
       * @param base64Image 
       * @returns  
       */
      imageTransform(base64Image){
        base64Image = 'data:image/jpg;base64,' + (this.sanitizer.bypassSecurityTrustResourceUrl(base64Image) as any).changingThisBreaksApplicationSecurity;
        return this.sanitizer.bypassSecurityTrustResourceUrl(base64Image);
    }
    /**
     * Checks if given checkin & checkout Dates are valid or not
     * @param checkout 
     * @param checkin
     * @returns true if checkin date is more than checkout
     */
    invalidateDates(checkout,checkin):boolean{
      return    checkin>checkout?true:false
    }

}
