import { Router } from '@angular/router';
import { CampService } from 'src/app/shared/camp.service';
import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/shared/camp.model';
import { ToastrService } from 'ngx-toastr';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-manage-camps',
  templateUrl: './manage-camps.component.html',
  styleUrls: ['./manage-camps.component.css']
})
export class ManageCampsComponent implements OnInit {
listOfCamps:Camp[];
p:number=1;
  constructor(private service:CampService, private toastr:ToastrService,private router:Router,private sanitizer:DomSanitizer) { }

  ngOnInit(): void {
    this.getAllCamps()
  }
getAllCamps(){
  this.service.getCamps().subscribe(res=>
    this.listOfCamps=res as Camp[]
    ),
    error=>{
      console.log(error);
    }
    
}
EditCamp(campId){
console.log(campId);

this.router.navigate(['/editCamp',campId]);

}
DeleteCamp(campId){
  console.log(campId);
  this.service.deleteCamp(campId).subscribe(
    res=>{
    this.toastr.success("Deleted Successfully!","Camp.Add");
    this.getAllCamps();
  }
    ,
    error=>{
      this.toastr.error("Camp Not Deleted")
    }
    
);
}
imageTransform(base64Image){
  base64Image = 'data:image/jpg;base64,' + (this.sanitizer.bypassSecurityTrustResourceUrl(base64Image) as any).changingThisBreaksApplicationSecurity;
  return this.sanitizer.bypassSecurityTrustResourceUrl(base64Image);
}

}
