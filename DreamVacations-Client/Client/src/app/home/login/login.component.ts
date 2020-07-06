import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/user.model';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public userService:UserService,private router: Router) { }
  isLoginError:boolean
  user:User
  ngOnInit(): void {
    this.isLoginError=false
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      Id:null,
        Username: '',
      Password: '',
      }
    }
    OnSubmit(username,password){
      this.userService.userAuthentication(username,password).subscribe((data : any)=>{
      localStorage.setItem('userToken',data.access_token);
       this.router.navigate(['/adminDashboard']);
       console.log(data.access_token);
      
     },
     (err : HttpErrorResponse)=>{
       this.isLoginError = true;
     });
   }
      }

    

