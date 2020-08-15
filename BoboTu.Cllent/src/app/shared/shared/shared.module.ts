import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import {MatSelectModule} from '@angular/material/select';
import { RatingModule } from 'ngx-bootstrap/rating';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    MatSelectModule,
    RatingModule.forRoot()
  ],
  exports:[
    ModalModule,
    MatSelectModule,
    RatingModule
  ]
})
export class SharedModule { }
