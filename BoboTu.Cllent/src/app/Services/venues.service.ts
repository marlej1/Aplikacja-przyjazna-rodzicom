import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { Venue } from 'app/Models/Venue';
import { VenueForCreation } from 'app/Models/VenueForCreation';
import { JsonPatchDocument, PatchOperation } from 'app/Models/JsonPatchDocument';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VenuesService {


  baseUrl = environment.apiUrl + 'venues/';

  constructor(private http:HttpClient) { }

getVenues():Observable<Venue[]>{
     return this.http.get<Venue[]>(this.baseUrl)
}

AddVenue(venue: any): Observable<Venue>{
  return this.http.post<Venue>(this.baseUrl, venue)

}

PartiallyUpdateVenue(venueOpinion: any, userId:number, venueId:number) : Observable<boolean>  {


  let jsonDocument = new JsonPatchDocument();
  jsonDocument.AddOperation(new PatchOperation('add', `/ratings/-`, { value: venueOpinion.rating, userId:userId }))
  jsonDocument.AddOperation(new PatchOperation('add', `/opinions/-`,{ contents: venueOpinion.opinion, userId:userId  }))


  return this.http.patch(`${this.baseUrl}${venueId}`, jsonDocument.operations).pipe(
     map(res =>{
       return true;
     })
   );
   

}

}
