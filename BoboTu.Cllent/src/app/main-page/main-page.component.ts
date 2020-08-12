import { Component, OnInit } from '@angular/core';
import { VenuesService } from 'app/Services/venues.service';
import { Venue } from 'app/Models/Venue';


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

  constructor(private venuesService: VenuesService) { }

  ngOnInit() {

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

    var myLatlng = new google.maps.LatLng(this.latt, this.long);
    var myLatlng1 = new google.maps.LatLng(this.latt1, this.long1);

    let directionsService = new google.maps.DirectionsService();
    // let directionsRenderer = new google.maps.DirectionsRenderer();
    let bounds = new google.maps.LatLngBounds();

    var mapOptions = {
        zoom: 13,
        center: myLatlng
      
    };

    var map = new google.maps.Map(document.getElementById("map"), mapOptions);


    this.venuesService.getVenues().subscribe(venues=>{    
      this.venues = venues;
      console.log(this.venues);
      this.venues.forEach(v=>{
    var Latlng = new google.maps.LatLng(v.lattitude, v.longitude);

        var marker = new google.maps.Marker({
          position: Latlng,
          title: v.name,
      });
      console.log(marker)
  
          marker.setMap(map);
      })


      
    },err=>{
      console.log(err);
    })

    let infoWindow = new google.maps.InfoWindow();

    let infoContent ="<div class='info-window'><address>Bethany's Pie Shop<br/>117 Franklin Rd<br/>Brentwood, TN 37027</address></div>"

    var marker = new google.maps.Marker({
        position: myLatlng,
        title: "Tu jesteś",
   icon :'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'
    });

  

    // To add the marker to the map, call setMap();
    marker.setMap(map);


    // bounds.extend(marker.position);

    // marker1.setMap(map);

    // bounds.extend(marker1.position);
    // map.fitBounds(bounds);

   



    google.maps.event.addListener(marker, 'click', function () {
        // Add HTML content for window
        infoWindow.setContent(infoContent);
        // Open the window
        infoWindow.open(map, marker);
      
  })



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

}


   // Set route of how to travel from point A to B
      // directionsService.route(
      //   {
      //     origin: 'Wielicka 73, kraków',
      //     destination: 'Wielicka 143, kraków',
      //     travelMode: 'DRIVING'
      //   },
      //   function (response, status) {
      //     if (status === 'OK') {
      //       directionsRenderer.setDirections(response);
      //       // Render directions on the map
      //       directionsRenderer.setMap(map);
      //     } else {
      //       alert('Directions request failed due to ' + status);
      //     }
      //   });

