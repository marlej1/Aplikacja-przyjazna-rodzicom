import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AuthService } from '../auth.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ConfirmPasswordValidator } from 'app/Validators/ConfirmPasswordValidator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user: any;
  showError:boolean = false;;
  errorMessage:string;

  constructor(
    public bsModalRef: BsModalRef,
     private authService:AuthService,
     private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {

    
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],

  },
  {
    validator: ConfirmPasswordValidator("password", "confirmPassword")
  }
  )

}

register(){

  this.user = Object.assign({}, this.registerForm.value);

  this.authService.register(this.registerForm.value).subscribe(
    res=>{
    console.log("regiter success", res)
    this.bsModalRef.hide();
    this.registerForm.reset();
    this.showError = false;
    this.authService.login(this.user).subscribe(() => {    
    },err=>{
      console.log(err)
    })

  },err=>{
    console.log(err);
    this.showError = true;
    this.errorMessage = err[0].description;
    if(!this.errorMessage){
      this.errorMessage = err;
    }
    
  })

}
}
