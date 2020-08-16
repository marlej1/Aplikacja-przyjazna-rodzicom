import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Venue } from 'app/Models/Venue';

@Component({
  selector: 'app-show-details',
  templateUrl: './show-details.component.html',
  styleUrls: ['./show-details.component.css']
})
export class ShowDetailsComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }
  list:any[] = []
  venue:Venue;

  


  ngOnInit(): void {
    this.venue = this.list[0].venue;

    console.log(this.venue)
  }

}
