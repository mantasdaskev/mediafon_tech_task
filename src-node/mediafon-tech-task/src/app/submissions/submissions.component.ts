import { Component } from '@angular/core';
import { Submission } from '../models/submission';
import { SubmissionsApiService } from '../services/submissions.api.service';
import { NewSubmission } from '../models/new.submission';

@Component({
  selector: 'app-submissions',
  templateUrl: './submissions.component.html',
  styleUrl: './submissions.component.css'
})
export class SubmissionsComponent {
private readonly _submissionsService : SubmissionsApiService;

  title = "Submitted submissions";
  submissions?: Submission[];
  isNewSubFormShown: boolean = false;

  constructor(submissionsService: SubmissionsApiService){
    this._submissionsService = submissionsService;

    this.loadSubmissions();
  }

  onShowNewForm(){
    this.isNewSubFormShown = true;
  }

  onHideNewForm(){
    this.isNewSubFormShown = false;
  }

  onSubmit(newSubmission: NewSubmission){
    this._submissionsService.postNewSubmission(newSubmission, (isSuccess: boolean) =>{
      this.onHideNewForm();
      if (!isSuccess){
        alert("Failed to post new submission.");
        return;
      }
      this.loadSubmissions();
    })
  }

  private loadSubmissions(){
    this._submissionsService.getSubmissions((response) => {
      if (response.length <= 0 ){
        alert("User has no submissions.");
        return;
      }
      this.submissions = response;
    });
  }
}
