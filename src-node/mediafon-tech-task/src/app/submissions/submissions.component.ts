import { Component } from '@angular/core';
import { Submission } from '../models/submission';
import { SubmissionsApiService } from '../services/submissions.api.service';

@Component({
  selector: 'app-submissions',
  templateUrl: './submissions.component.html',
  styleUrl: './submissions.component.css'
})
export class SubmissionsComponent {
  title = "Submitted submissions";
  submissions? : Submission[];

  constructor(service: SubmissionsApiService){
    service.getSubmissions((response) => {
      this.submissions = response.submissions;
      console.log('REAL GET =>> ' + JSON.stringify(response));
      console.log('SUBS?? =>> ' + JSON.stringify(response.submissions));
    });
  }
}
