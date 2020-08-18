import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FacilitiesService } from 'app/Services/facilities.service';
import { VenuesService } from 'app/Services/venues.service';
import { AddRatingComponent } from '../add-rating/add-rating.component';
import { VenueType, VenueTypeDisplay } from 'app/Models/Enums';
import { AuthService } from 'app/Auth/login/auth.service';
import { CommunicationService } from 'app/Services/communication.service';

@Component({
  selector: 'app-new-venue',
  templateUrl: './new-venue.component.html',
  styleUrls: ['./new-venue.component.css']
})
export class NewVenueComponent implements OnInit {

  constructor(private builder: FormBuilder,
    public bsModalRef: BsModalRef, 
    public facilitiesService:FacilitiesService,
    private venuesService: VenuesService,
    private modalService: BsModalService, 
    private authService : AuthService,
    private communicationService: CommunicationService ) { }
    

  addNewVenueForm: FormGroup;
  modalRef: BsModalRef;
  list: any[] = [];
  venueTypes: any[] = [];



  ngOnInit(): void {
    console.log(this.list[0], 'passed data');

    let  index:number = 1;
    for (let item in VenueType) {
      if (isNaN(Number(item))) {
          console.log(item);
          this.venueTypes.push({id:index, name:VenueTypeDisplay.GetDisplayName(item)})
      index++;

      }
  }
 
 
    this.addNewVenueForm = this.builder.group({
      name: ['', Validators.required],
      description: [''],
      webPage: [''],
      emailAddress:[''],
      facilitiesIds:[],
      houseNumber:[ this.list[0].geoCodedAddress ? this.list[0].geoCodedAddress.houseNumber.long_name : ''],
      street:[this.list[0].geoCodedAddress ? this.list[0].geoCodedAddress.street.long_name : ''],
      city:[this.list[0].geoCodedAddress ? this.list[0].geoCodedAddress.city.long_name : ''],
      lattitude:[this.list[0].lat],
      longitude:[this.list[0].lng],
      venueType:[1]
     
  });
  }
  addNewVenue(){
   this.venuesService.AddVenue(this.addNewVenueForm.value).subscribe(
     res=>{
       
       this.bsModalRef.hide();
      const initialState = {
        list: [
          {venueId:res.id,
             userId: +this.authService.decodedToken.nameid,
              userName:this.authService.decodedToken.unique_name}
          ]
        
      };
       if(confirm(`Nowe miejsce ${res.name} zostało dodane! Czy chcesz dodać swoją opinię o ocenę?`)){
        this.modalService.show(AddRatingComponent, {initialState});

       }else{
        this.communicationService.initiateMainPageRefresh()
       }
     }
   )
  }
  

}
