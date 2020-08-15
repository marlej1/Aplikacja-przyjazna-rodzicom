import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { VenuesService } from 'app/Services/venues.service';
import { CommunicationService } from 'app/Services/communication.service';


@Component({
  selector: 'app-add-rating',
  templateUrl: './add-rating.component.html',
  styleUrls: ['./add-rating.component.css']
})
export class AddRatingComponent implements OnInit {

  addNewRatingAndOpinionForm:FormGroup;
  constructor(private builder:FormBuilder,
    public bsModalRef: BsModalRef,
    private venuesService: VenuesService,
    private communicationService: CommunicationService)
     { }
    modalRef: BsModalRef;

  list:any[] = []

  ngOnInit(): void {
  this.addNewRatingAndOpinionForm =  this.builder.group({
      rating:[1],
      opinion:['']

    })
  }


  addNewRatingAndOpinion(){
    this.addNewRatingAndOpinionForm.value

    
    this.venuesService.PartiallyUpdateVenue(this.addNewRatingAndOpinionForm.value, this.list[0].userId as number, this.list[0].venueId as number).subscribe(
      res=>{
        if(res){
          alert('Dziękujemy za dodanie opinii!');
          
        }
      },
      err=>{

      },
      ()=>{
        this.communicationService.initiateMainPageRefresh();
      }
    );

    this.bsModalRef.hide();
    this.addNewRatingAndOpinionForm.reset();
    
  
  }

}
