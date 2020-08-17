import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import {MatSelectModule} from '@angular/material/select';
import { RatingModule } from 'ngx-bootstrap/rating';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    MatSelectModule,
    RatingModule.forRoot(),
    ProgressbarModule.forRoot(),
    CollapseModule.forRoot()
  ],
  exports:[
    ModalModule,
    MatSelectModule,
    RatingModule,
    ProgressbarModule,
    CollapseModule
  ]
})
export class SharedModule { }
