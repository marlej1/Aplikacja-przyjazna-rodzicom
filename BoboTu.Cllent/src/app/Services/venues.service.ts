import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Venue } from 'app/Models/Venue';

@Injectable({
  providedIn: 'root'
})
export class VenuesService {


  baseUrl = environment.apiUrl + 'venues/';

  constructor(private http:HttpClient) { }
getVenues():Observable<Venue[]>{
     return this.http.get<Venue[]>(this.baseUrl)
}

}
