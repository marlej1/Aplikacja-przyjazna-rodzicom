import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Venue, CountOfValueRating } from 'app/Models/Venue';

@Component({
  selector: 'app-show-details',
  templateUrl: './show-details.component.html',
  styleUrls: ['./show-details.component.css']
})
export class ShowDetailsComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }
  list:any[] = []
  venue:Venue;
  valueRatings:any[] = [];

  


  ngOnInit(): void {
    this.venue = this.list[0].venue;

    console.log(this.venue)

    for (let i = 1; i <=5; i++) {
     let valueRating =  new CountOfValueRating();
     valueRating.ratingValue = i;
     let vr =   this.venue.countOfValueRatings.find(v =>{return v.ratingValue === i});
     if(vr){
      valueRating.count = vr.count;
     }else{
      valueRating.count = 0;
       
     }
      
      this.valueRatings.push(valueRating);
      
    }
  }
  getComments(){
    console.log('getCommenta');
  }

}
