import { Component, OnInit } from '@angular/core';
import { VenuesService } from 'app/Services/venues.service';
import { Venue } from 'app/Models/Venue';
import { VenueType } from 'app/Models/Enums';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { LoginComponent } from 'app/Auth/login/login.component';
import { NewVenueComponent } from 'app/components/new-venue/new-venue.component';
import { AuthService } from 'app/Auth/login/auth.service';
import { CommunicationService } from 'app/Services/communication.service';
import { AddRatingComponent } from 'app/components/add-rating/add-rating.component';


declare const google: any;

interface Marker {
lat: number;
lng: number;
label?: string;
draggable?: boolean;
}
@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

    map:any;

    long:number = 19.967026;
    latt:number = 50.0340335;

    latt1:number = 51.0340335;
    long1:number = 20.967026;
    addrMarker:any;
  venues: Venue[];
  tempMarker: any = null;
  

  modalRef: BsModalRef;
  usersLatlng: any;
  directionsService: any;
  directionsRenderer: any;


  constructor(private venuesService: VenuesService, 
    private modalService: BsModalService,
    private authService: AuthService,
    private communicationService: CommunicationService) 
    {
      this.communicationService.refreshPage().subscribe
      (
        res =>{
          this.displayMaps();
        }
      );
     }

  ngOnInit() {

    this.modalService.show(AddRatingComponent);

  
    
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(
              pos=>{
              this.latt = pos.coords.latitude;
              this.long = pos.coords.longitude;
              this.displayMaps();
          }
           ,
           (error) =>{
            let msg = "";

            switch (error.code) {
              case error.PERMISSION_DENIED:
                msg = "Użytkownik nie chcę udostępniać danych o swojej lokalizacji.";
                break;
              case error.POSITION_UNAVAILABLE:
                msg = "nie można określić położenie użytkownika.";
                break;
              case error.TIMEOUT:
                msg = "Zapytanie zostało przerwane";
                break;
              default:
                msg = "Wystąpił nieznany błąd. Spróbuj później";
                break;
            }
            this.displayMaps();
            alert(msg)

           }
           );
        }
        else {
          alert("Zaktualizuj swoją przeglądarkę żeby korzystaćz z usług geolokalizacji.");
        }
  }


  displayMaps(){

    this.usersLatlng = new google.maps.LatLng(this.latt, this.long);

    

    let bounds = new google.maps.LatLngBounds();

    var mapOptions = {
        zoom: 13,
        center: this.usersLatlng
      
    };


     this.map = new google.maps.Map(document.getElementById("map"), mapOptions);

    document.getElementById("map").addEventListener('onContextMenu', e => {
      e.preventDefault();
      return false;
    })
    

    this.venuesService.getVenues().subscribe(venues=>{    
      this.venues = venues;
      this.venues.forEach(v=>{
    var Latlng = new google.maps.LatLng(v.lattitude, v.longitude);


        let iconUrl = this.getUrlcon(v.venueType);
        var marker = new google.maps.Marker({
          position: Latlng,
          title: v.name,
          icon:iconUrl
      });  
          marker.setMap(this.map);

          this.addContextMenuAndListersToMarker(marker, false);


      })


      
    },err=>{
       console.log(err);
    })

    let infoWindow = new google.maps.InfoWindow();

    let infoContent ="<div class='info-window'><address>Bethany's Pie Shop<br/>117 Franklin Rd<br/>Brentwood, TN 37027</address></div>"

    var marker = new google.maps.Marker({
        position: this.usersLatlng,
        title: "Tu jesteś",
   icon :"https://img.icons8.com/bubbles/50/000000/walking.png"
    });

    marker.setMap(this.map);


    this.map.addListener('click', e => {
      if(this.directionsRenderer){
        this.directionsRenderer.setMap(null);
        this.directionsRenderer = null;
        if(!this.tempMarker){
          return;
        }

      }

    if(this.tempMarker){
      this.tempMarker.setMap(null);
      this.tempMarker = null
    }else{

      this.tempMarker   = new google.maps.Marker({
        position: new google.maps.LatLng(e.latLng.lat(), e.latLng.lng()),
   icon :"https://img.icons8.com/doodle/48/000000/marker--v1.png",
   
    });

      this.tempMarker.setMap(this.map);
      marker.IsTempMarker = true;
      this.addContextMenuAndListersToMarker(this.tempMarker, true);
    
    }
    }) 

   
}
  addContextMenuAndListersToMarker(marker:any, isTempMarker:boolean) {


    marker.addListener('rightclick',(e) => {
      let infoWindow = new google.maps.InfoWindow();    
     let addVenueTr ='';
      if(this.authService.decodedToken && isTempMarker){
      addVenueTr = `<tr onMouseOver="this.style.textShadow='0px 0px 1px black'" onMouseOut="this.style.textShadow='none'">
      <td  id="addNewVenue">Dodaj nowe miejsce</td>
      </tr>`
      }

      infoWindow.setContent(`
      <table class='context-menu' 
      style='cursor: pointer;
       margin:5px;
       font-weight:normal
       '>${addVenueTr}
      <tr id='getDirectionsForTempMarker' onMouseOver="this.style.textShadow='0px 0px 1px black'" onMouseOut="this.style.textShadow='none'">
      <td style='padding:4px'>Sprawdź jak dojechać do tego miejsca</td>
      </tr>
      </table>`);


      // Open the window
      infoWindow.open(this.map, marker);

      google.maps.event.addListenerOnce(infoWindow, 'domready', () => {


       document.getElementById('getDirectionsForTempMarker').addEventListener('click', () => {
         console.log('getDirections');


         this.getDirections(new google.maps.LatLng(marker.getPosition().lat(),
          marker.getPosition().lng()),this.usersLatlng
          )
         });

     if(this.authService.decodedToken && isTempMarker){
       let addVenue = document.getElementById(`addNewVenue`);

       addVenue.addEventListener('click', () => {
       this.openAddNewVenueModal( marker.getPosition().lat(), marker.getPosition().lng());
       });

     }
   
     });

    
     })
  }

  getUrlcon(venueType:VenueType) {

    switch(venueType){
      case VenueType.Restaurant:
      return "https://img.icons8.com/bubbles/50/000000/restaurant.png"
      case VenueType.Doctor:
      return  "https://img.icons8.com/color/48/000000/doctor-male--v1.png"
      case VenueType.Pharmacy:
      return "https://img.icons8.com/color/48/000000/pharmacy-shop.png"
      case VenueType.Playground:
      return "https://img.icons8.com/color/48/000000/playground.png"
      case VenueType.PlayingField:
      return "https://img.icons8.com/office/40/000000/football2--v1.png"
      
      case VenueType.ShoppingCenter:
      return "https://img.icons8.com/color/48/000000/shopping-basket.png"
      case VenueType.ThemePark:
        return "https://img.icons8.com/office/40/000000/dinosaur.png"
        case VenueType.Toilet:
        return "https://img.icons8.com/office/40/000000/toilet.png"
    }  
  }
 setMarkerOnAddress(address) {


    var geocoder = new google.maps.Geocoder();

        if (address.length > 0) {
          geocoder.geocode({ 'address': address },  (results, status) => {
            switch (status) {
              case google.maps.GeocoderStatus.OK:
                if (results[0]) {
                  let mapObject = {
                    "lat": results[0].geometry.location.lat(),
                    "lng": results[0].geometry.location.lng(),
                    "marker": null,
                    "title": address,
                    "infoContent": null,
                    "infoIcon": null
                  }
                  // Remove any previous address marker
                  if (this.addrMarker) {
                    this.addrMarker.setMap(null);
                  }

                  // Set marker on map
                  this.addrMarker = this.drawMarker(mapObject);

                  // Get existing map boundaries
                  let bounds = this.map.getBounds();

                  // Extend boundaries to encompass new marker
                  bounds.extend(this.addrMarker.position);

                  // Make sure rectangle is displayed on the map
                  this.map.fitBounds(bounds);                  
                }
                else {
                  alert("Could not locate address.");
                }
                break;

              case google.maps.GeocoderStatus.ZERO_RESULTS:
                alert("No such address found.");
                break;

              case google.maps.GeocoderStatus.OVER_QUERY_LIMIT:
                alert("Query limit has been exceeded.");
                break;

              case google.maps.GeocoderStatus.REQUEST_DENIED:
                alert("Query request was denied.");
                break;

              case google.maps.GeocoderStatus.INVALID_REQUEST:
                alert("Query request was invalid.");
                break;

              default:
                alert("Unknown status: " + status);
                break;
            }
          });
        }
        else {
          alert("Please enter an address.")
        }
}




 drawMarker(mapObject) {
    // Create a new marker since you may need more than one
    let marker = new google.maps.Marker({
      position: new google.maps.LatLng(mapObject.lat, mapObject.lng),
      map: this.map,
      title: mapObject.title,
      icon: mapObject.infoIcon
    });

    // Add marker to the map
    marker.setMap(this.map);

    return marker;
  }

  openAddNewVenueModal(lat:number, lng:number){
    const initialState = {
      list: [
        {lat:lat, lng:lng}
      ]
    };
    this.modalService.show(NewVenueComponent, {initialState});
  }

   getDirections(from, to) {
     this.directionsService = new google.maps.DirectionsService();
     this.directionsRenderer = new google.maps.DirectionsRenderer();

    // Set route of how to travel from point A to B
    this.directionsService.route(
      {
        origin: from,
        destination: to,
        travelMode: 'DRIVING'
      },
       (response, status)=> {
        if (status === 'OK') {
          this.directionsRenderer.setDirections(response);
          // Render directions on the map
          this.directionsRenderer.setMap(this.map);

         

        } else {
          alert('Directions request failed due to ' + status);
        }
      });
  }
}




