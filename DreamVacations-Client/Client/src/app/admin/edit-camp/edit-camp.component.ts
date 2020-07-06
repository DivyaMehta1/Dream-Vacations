import { Route } from '@angular/compiler/src/core';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { Camp } from './../../shared/camp.model';
import { CampService } from 'src/app/shared/camp.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-camp',
  templateUrl: './edit-camp.component.html',
  styleUrls: ['./edit-camp.component.css']
})
export class EditCampComponent implements OnInit {
campId:string
formData:Camp
file: File;
base64textString: string
imageUrl: string | ArrayBuffer ;
fileName: string = "No file selected" 
enterImage:boolean=true;

  constructor(private activatedRouter:ActivatedRoute,public service:CampService,private toastr:ToastrService,private router:Router) { 
    

  }

  ngOnInit(): void {
    this.formData = new Camp();
    this.campId=this.activatedRouter.snapshot.paramMap.get('id');
    this.getCampDetails(this.campId);
  }

  /**
   * Gets camp details
   * @param campId 
   */
  getCampDetails(campId:string){
    this.service.getCamp(this.campId).subscribe(res=>{
      this.formData= res as Camp
    },
    error=>{
      console.log(error);
    });
  }
  
  /**
   * OnSubmission of EditForm
   * @param formData 
   */
  onSubmit(formData){
    this.UpdateCamp(formData);
  }

  /**
   * Updates camp with FormData & calls API
   * @param formData 
   */
  UpdateCamp(formData){
    this.formData.Image=this.base64textString;
    this.service.updateCamp(formData).subscribe(res=>{
      this.toastr.success("successfully Updated");
      this.router.navigate(['/manageCamps'])
    }),
    error=>{
      this.toastr.error("Please Try Again: "+error);
      console.log(error);
    }

  }
  
/**
 * Handles reader  & converts it to 64BaseStringImage
 * @param readerEvt 
 */
handleReaderLoaded(readerEvt) {
    var binaryString = readerEvt.target.result;
    this.base64textString= btoa(binaryString);
  }

  /**
   * Loads selected File ReaderLoader
   * @param file 
   */
  onFileChange(file: File) {
    if (file) {
      this.enterImage = false
      this.fileName = file.name
      this.file = file
  
      const reader = new FileReader()
      const reader2 = new FileReader()
      
      reader.onload =this.handleReaderLoaded.bind(this)
      reader.readAsBinaryString(file);
  
      reader2.readAsDataURL(file)
      reader2.onload = event => {
          this.imageUrl = reader2.result;
        };
    }
  }

}
