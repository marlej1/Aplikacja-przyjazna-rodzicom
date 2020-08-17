import { Component} from '@angular/core';
import { AuthService } from './Auth/login/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FacilitiesService } from './Services/facilities.service';
import { Facility } from './Models/Facility';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService, private facilitiesService: FacilitiesService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      console.log(this.authService.decodedToken, 'decoded');
    
    }

    this.facilitiesService.getFacilities().subscribe(
      res =>{
        this.facilitiesService.faciltiesCached = res;
      }

    )
   
  }

}
