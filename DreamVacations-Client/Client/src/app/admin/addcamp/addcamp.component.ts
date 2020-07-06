import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/shared/camp.model';
import { CampService } from 'src/app/shared/camp.service';
import { ToastrService } from 'ngx-toastr';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-addcamp',
  templateUrl: './addcamp.component.html',
  styleUrls: ['./addcamp.component.css']
})
export class AddcampComponent implements OnInit {
  formData:Camp
  selectedFile:File=null;
  imageControl:FormControl;

  file: File;
   base64textString: string
   imageUrl: string | ArrayBuffer ;
   fileName: string = "No file selected" 

   enterImage:boolean=true;
  constructor(public service:CampService,private toastr:ToastrService) { 

  }
  ngOnInit(): void {
    this.resetForm(this.formData);
    this.formData=new Camp();
  
  }

  /**
   * Resets form
   * @param formData 
   */
  resetForm(formData){
    if(formData!=null)
    formData=null;
  }

  /**e
   * Submits  ADD FormData
   */
  onSubmit(){
    this.insertRecord();
}

/**
 * Inserts record & makes API call
 */
insertRecord(){
  console.log(this.file);
  console.log(this.base64textString);
  this.formData.Image=this.base64textString;
  this.service.postCamp(this.formData).subscribe(res=>{
    this.toastr.success("Added Successfully!","Camp.Add");
    this.resetForm(this.formData);
    
  },
  error=>{
    this.toastr.error("Something went wrong.",error);
  });
}
handleReaderLoaded(readerEvt) {
  var binaryString = readerEvt.target.result;
  this.base64textString= btoa(binaryString);
  //console.log(btoa(binaryString));
}
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
