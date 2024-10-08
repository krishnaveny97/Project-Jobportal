import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { SetPasswordDialogueComponent } from '../set-password-dialogue/set-password-dialogue.component';


@Component({
 
  selector: 'app-set-password',
  templateUrl: './set-password.component.html',
  styleUrls: ['./set-password.component.css']
})
export class SetPasswordComponent {
  SetPassword!:FormGroup
  hide=true;
  signupId!:string;
  constructor(private activatedroute:ActivatedRoute,private auth:AuthService,private dialog:MatDialog)
  { }


  ngOnInit():void{
    this.SetPassword=new FormGroup({
      password:new FormControl('',[
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}$/)])
    });


    this.activatedroute.queryParams.subscribe(params =>{
      this.signupId=params['signupid'];
      console.log(params['signupid']);
      this.auth.sendEmail(this.signupId).subscribe(
        (Response:any)=>{
          console.log('Email verified response ');
          console.log(Response)
        },
        (error)=>{
          console.log('error in email verification',error); 
        }
      );
    })


  }

  


  setPassword(){
    
    if(this.SetPassword.valid){
      console.log('form submitted successfully');
      const password:string=this.SetPassword.value.password;
      console.log(password)
      this.auth.setNewPassWord(password,this.signupId).subscribe(
        (Response:any)=>{
          console.log('Password set successfully', Response)
        },
        (error)=>{
          console.log('Error in setting the Password',error);
        }
      )
      
     const dialogref=this.dialog.open(SetPasswordDialogueComponent)

    }
    else {
      console.log("form not submitted")
    }


  }

}
