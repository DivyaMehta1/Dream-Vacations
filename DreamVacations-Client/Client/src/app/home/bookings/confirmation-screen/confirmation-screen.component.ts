import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-confirmation-screen',
  templateUrl: './confirmation-screen.component.html',
  styleUrls: ['./confirmation-screen.component.css']
})
export class ConfirmationScreenComponent implements OnInit {
referenceNumber:string
message:string
  constructor(private activatedRouter:ActivatedRoute) { }

  /**
   * on init Display ReferenceNumber & Message
   */
  ngOnInit(): void {
   this.referenceNumber=this.activatedRouter.snapshot.paramMap.get('referenceNumber');
   this.message=this.activatedRouter.snapshot.paramMap.get('message');
     
  }

}
