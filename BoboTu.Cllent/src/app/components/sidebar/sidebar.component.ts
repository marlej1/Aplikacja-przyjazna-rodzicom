import { Component, OnInit } from '@angular/core';
import { CommunicationService } from 'app/Services/communication.service';

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

  constructor(private communicationService: CommunicationService) 
  {
    this.communicationService.displayOpinions().subscribe(
      res=>{
        if(+res != -1){
          this.opinionMode = true;
        }
      }
    )
   }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
