import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FacilityType } from 'app/Models/Enums';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Facility } from 'app/Models/Facility';


@Injectable({
  providedIn: 'root'
})
export class FacilitiesService {


  baseUrl = environment.apiUrl + 'facilities/';
  faciltiesCached: Facility[];

  constructor(private http:HttpClient) { }
  
  getFacilities():Observable<Facility[]>{
       return this.http.get<Facility[]>(this.baseUrl)
  }
}
