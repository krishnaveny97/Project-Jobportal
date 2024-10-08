import { Component,ElementRef ,ViewChild} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';


@Component({
  selector: 'app-login-sign-up',
  templateUrl: './login-sign-up.component.html',
  styleUrls: ['./login-sign-up.component.css']
})
export class LoginSignUpComponent {
  // password visibility default value

hide:boolean = true;
show:boolean=true;
  constructor(private router:Router,private auth:AuthService){}
  @ViewChild('containerr') containerr!: ElementRef;

toggleSignUpMode(): void {
  this.containerr.nativeElement.classList.add('sign-up-mode');
}

toggleSignInMode(): void {
  this.containerr.nativeElement.classList.remove('sign-up-mode');
}
signUpForm!:FormGroup
loginForm!:FormGroup

/* loginForm!:FormGroup */

ngOnInit():void{
    this.loginForm=new FormGroup({
    email:new FormControl('',[Validators.required,Validators.email]),
    password:new FormControl('',[Validators.required,Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)])

  });

    this.signUpForm=new FormGroup({
    firstName:new FormControl('',[Validators.required,Validators.pattern('^[a-zA-Z]+$')]),
    lastName:new FormControl('',[Validators.required,Validators.pattern('^[a-zA-Z]+$')]),
    userName:new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    phone:new FormControl('',[Validators.required,Validators.pattern('^[0-9]{10}$')])
   });
}

//signup dataretrive from service
signUpSubmit(){
  console.log(this.signUpForm.value)
  if(this.signUpForm.valid){
    this.auth.signup(this.signUpForm.value).subscribe(
      (Response:any)=>{
        console.log('SignUp Successfully',Response);
      },
      (error)=>{
        console.log('Signup failed!', error);
      }
    );
    this.show=!this.show;
    
  }

}

//login data retrive from service
loginSubmit(){
  const email=this.loginForm?.get('email')?.value;
  const password=this.loginForm?.get('password')?.value;
  this.auth.login(this.loginForm.value).subscribe(
    (Response:any)=>{
      console.log('Login Successfully',Response);
      console.log(Response);
      //  this.auth.setToken(response.token);
      localStorage.setItem('token', Response.token);
       sessionStorage.setItem('Email', Response.email);
       sessionStorage.setItem('JobSeekerId', Response.id);
       sessionStorage.setItem('Username', Response.userName);
       this.router.navigate(['/job-seeker/dashboard']);
    },
    (error)=>{
      console.log('Login Failed',error);

    }
    
  );
 

} 


}
