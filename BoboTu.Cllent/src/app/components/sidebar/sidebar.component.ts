import { Component, OnInit } from '@angular/core';
import { CommunicationService } from 'app/Services/communication.service';
import { FacilityType, FacilityToDisplay, VenueType, VenueTypeDisplay } from 'app/Models/Enums';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/main', title: 'Strona główna',  icon: 'dashboard', class: '' },

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  opinionMode:boolean = true;
  isCollapsed = false;
  VenueTypesisCollapsed = false;
  facilityArray :any[] = []
  venuTypesArray:any[] =[]

  constructor(private communicationService: CommunicationService) 
  {
   
   }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);

    for (const facilityId in FacilityType) { 
      if(!isNaN(+facilityId)){
        this.facilityArray.push({
          nameForDisplay: FacilityToDisplay.GetDisplayName(FacilityType[+facilityId].toString()) ,
          isSelected: false,
          facilityId: +facilityId

        })
      }  
    }

    for (const venueTypeId in VenueType) { 
      if(!isNaN(+venueTypeId)){
        this.venuTypesArray.push({
          nameForDisplay: VenueTypeDisplay.GetDisplayName(VenueType[+venueTypeId].toString()) ,
          isSelected: false,
          venueTypeId: +venueTypeId

        })
      }  
    }

    console.log(this.venuTypesArray)

    

  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
  filterVenues(){
    console.log(this.facilityArray)
    console.log(this.venuTypesArray)

  let facilityIds =  this.facilityArray.filter(f=>f.isSelected).map(f=>f.facilityId).join(',');
  let venueTypeIds =  this.venuTypesArray.filter(f=>f.isSelected === true).map(f=>f.venueTypeId).join(',');

  console.log(facilityIds)
    console.log(venueTypeIds)
 let filter = {facilityIds,venueTypeIds };
 
    this.communicationService.filterVenuesAndRefresMainhPage(filter)



  }
}
