import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

/**
 * Parent Component for all Children:displays navbar 
 */
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
userClaims:any
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit(): void {
}
  


}
