import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AuthService } from './auth.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

declare var $: any;


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  showError:boolean = false;


  constructor(public bsModalRef: BsModalRef,
     private authService:AuthService,
     private formBuilder: FormBuilder) { }


  
  ngOnInit(): void {


    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
         
  });
  }

  login(){
    this.authService.login(this.loginForm.value).subscribe(
      res=>{
      this.bsModalRef.hide();
      this.loginForm.reset();
      this.showNotification('top','center', res.userName);
      this.showError = false;


    },err=>{
      this.showError = true;

      console.log(err)
     

      
    } )

  }
   showNotification(from, align, userName:string){

    $.notify({
    icon: "add_alert",
    message: `Witaj ${userName}`
    
    },{
    type: 'success',
    timer: 4000,
    placement: {
    from: from,
    align: align
    }
    });
    }



}
