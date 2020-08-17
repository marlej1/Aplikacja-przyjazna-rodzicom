import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import {MatSelectModule} from '@angular/material/select';
import { RatingModule } from 'ngx-bootstrap/rating';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    MatSelectModule,
    RatingModule.forRoot(),
    ProgressbarModule.forRoot()
  ],
  exports:[
    ModalModule,
    MatSelectModule,
    RatingModule,
    ProgressbarModule
  ]
})
export class SharedModule { }
