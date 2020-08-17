import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { Venue } from 'app/Models/Venue';
import { VenueForCreation } from 'app/Models/VenueForCreation';
import { JsonPatchDocument, PatchOperation } from 'app/Models/JsonPatchDocument';
import { map, catchError } from 'rxjs/operators';
import { Opinion } from 'app/Models/Opinion';

@Injectable({
  providedIn: 'root'
})
export class VenuesService {


  baseUrl = environment.apiUrl + 'venues/';

  constructor(private http:HttpClient) { }

getVenues(filter:any):Observable<Venue[]>{
  let params = new HttpParams()
  .append('facilityIds', filter.facilityIds)
  .append('venueTypeIds', filter.venueTypeIds)

     return this.http.get<Venue[]>(this.baseUrl, {params: params})
}

getOpinionsForVenue(venueId: number):Observable<Opinion[]>{
  return this.http.get<Opinion[]>(`${this.baseUrl}${venueId}/opinions`)
}

AddVenue(venue: any): Observable<Venue>{
  return this.http.post<Venue>(this.baseUrl, venue)

}

PartiallyUpdateVenue(venueOpinion: any, userId:number, userName:string, venueId:number) : Observable<boolean>  {


  let jsonDocument = new JsonPatchDocument();
  jsonDocument.AddOperation(new PatchOperation('add', `/ratings/-`, { value: venueOpinion.rating, userId:userId, userName: userName }))
  jsonDocument.AddOperation(new PatchOperation('add', `/opinions/-`,{ contents: venueOpinion.opinion, userId:userId, userName:userName  }))


  return this.http.patch(`${this.baseUrl}${venueId}`, jsonDocument.operations).pipe(
     map(res =>{
       return true;
     })
   );
   

}

}
