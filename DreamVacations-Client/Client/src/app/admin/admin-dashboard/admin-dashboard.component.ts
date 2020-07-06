import { RouterModule } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
access_token:any

  constructor(private activatedRouter:ActivatedRoute) { }

  ngOnInit(): void {
    this.access_token=this.activatedRouter.snapshot.paramMap.get('token');
    
  }

}
