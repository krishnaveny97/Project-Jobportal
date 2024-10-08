import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private route:Router,private http:HttpClient) { }
  signup(user:any):Observable<any>{
    return this.http.post('/api/v1/Jobseeker/Job-Seeker/Signup',user)

  }
  sendEmail(signupRequestId:any):Observable<any>{
    return this.http.get('/api/v1/Jobseeker/Job-Seeker/SignUp/'+signupRequestId+'/Verfy-Email')

  }
  setNewPassWord(password:string,jobSeekerSignupRequestID:any):Observable<any>{
    const jsonstring=JSON.stringify(password);
    console.log(jsonstring);
    const headers=new HttpHeaders({'Content-Type': 'application/json','Accept': 'application/json'})
    return this.http.post<any>('/api/v1/Jobseeker/Job-Seeker/'+jobSeekerSignupRequestID+'/set-password',jsonstring,{headers:headers})

  }

  login(user:any):Observable<any>{
    return this.http.post<any>('/api/v1/Jobseeker/job-seeker/Login',user)
  }


  isLoggedIn(): boolean {
    // Check if the user is logged in (e.g., check for a token in localStorage)
    console.log("isLoggedin() "+(!!localStorage.getItem('token')))
    return !!localStorage.getItem('token');
  }

  
}
