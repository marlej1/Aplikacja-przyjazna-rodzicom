import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  constructor() { }

  private subject = new Subject<any>();
  private displayOpinionssubject = new Subject<number>();
  private geoCoderSubject = new Subject<string>();



  initiateMainPageRefresh() {
      this.subject.next("refresh page");
  }

  clearMessages() {
      this.subject.next();
  }

  refreshPage(): Observable<any> {
      return this.subject.asObservable();
  }

  initiateDisplayOpinions(venueId:number) {
    this.displayOpinionssubject.next(venueId);
}

initiateDisplayMenuOptions() {
  this.displayOpinionssubject.next(-1);
}
displayOpinions(): Observable<any> {
  return this.displayOpinionssubject.asObservable();
}

sendAddressForNewMarker(address:string){
  this.geoCoderSubject.next(address);
}

addMarker(){
  return this.geoCoderSubject.asObservable();
}

}
