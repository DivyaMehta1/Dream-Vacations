import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './shared/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  userClaims:any
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit(): void {
   
  
}
  Logout() {
     localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
}
