import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { JobseekerServiceService } from '../../services/jobseeker-service.service';

@UntilDestroy()
@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {
  seekerProfile!: FormGroup;
  jobSeekerId: any;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private service: JobseekerServiceService
  ) {}

  ngOnInit() {
    this.jobSeekerId = this.service.getJobSeekerId();
    console.log('JobSeekerId:', this.jobSeekerId); // Check if ID is being retrieved correctly
    this.seekerProfile = this.fb.group({
      profileName: ['', Validators.required],
      profileSummary: ['', Validators.required],
    });
  }

  onFileSelected(event: any) {
    // Logic for file selection
  }

  getindustry() {
    // Logic for getting industry
  }

  onsubmit() {
    if (this.seekerProfile.valid) {
      const profileData = {
        ...this.seekerProfile.value,
        jobSeekerId: this.jobSeekerId // Include JobSeekerId in the payload
      };

      this.service.addProfile(profileData)
        .pipe(untilDestroyed(this))
        .subscribe(
          (response: any) => {
            console.log('Profile Added Successfully', response);
            // Optionally, navigate or show a success message
          },
          (error) => {
            console.log('Profile Addition Failed', error);
          }
        );
    }
  }
}
