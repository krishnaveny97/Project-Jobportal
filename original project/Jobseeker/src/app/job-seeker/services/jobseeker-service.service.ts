import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobseekerServiceService {
  constructor(private router: Router, private http: HttpClient) {}

  logout() {
    localStorage.removeItem('token');
    sessionStorage.removeItem('Email');
    sessionStorage.removeItem('JobSeekerId');
    sessionStorage.removeItem('Username');
    console.log("token removed ");
    this.router.navigate(['/Login-Signup']);
  }

  getJobSeekerId() {
    return sessionStorage.getItem('JobSeekerId');
  }

  addProfile(profileData: any): Observable<any> {
    const jobSeekerId = this.getJobSeekerId();
    const url = `/api/v1/JobSeekerProfile/${jobSeekerId}/AddProfile`;
    /* const url='https://localhost:7183/api/v1/JobSeekerProfile/{jobseekerId}/AddProfile' */
    return this.http.post(url, profileData, { responseType: 'text' });
  }
}
