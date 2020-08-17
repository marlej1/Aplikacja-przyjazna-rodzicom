import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Venue, CountOfValueRating } from 'app/Models/Venue';
import { VenuesService } from 'app/Services/venues.service';
import { Opinion } from 'app/Models/Opinion';

@Component({
  selector: 'app-show-details',
  templateUrl: './show-details.component.html',
  styleUrls: ['./show-details.component.css']
})
export class ShowDetailsComponent implements OnInit {
  showOpinions: boolean;

  constructor(public bsModalRef: BsModalRef, private venuesService:VenuesService) { }
  list:any[] = []
  venue:Venue;
  valueRatings:any[] = [];
  opinions:Opinion[] = []

  


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
    this.showOpinions = true;
    this.venuesService.getOpinionsForVenue(this.venue.id).subscribe(res=>{
      console.log(res);
      this.opinions = res;
    })

  }

}
