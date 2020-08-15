import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  constructor() { }

  private subject = new Subject<any>();

  initiateMainPageRefresh() {
      this.subject.next("refresh page");
  }

  clearMessages() {
      this.subject.next();
  }

  refreshPage(): Observable<any> {
      return this.subject.asObservable();
  }
}
