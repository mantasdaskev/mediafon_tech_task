import { Component, OnInit } from '@angular/core';
import { Submission } from '../models/submission';
import { SubmissionsApiService } from '../services/submissions.api.service';
import { NewSubmission } from '../models/new.submission';
import { SubmissionsStateHubService } from '../services/submissions.state.hub.service';

@Component({
  selector: 'app-submissions',
  templateUrl: './submissions.component.html',
  styleUrl: './submissions.component.css'
})
export class SubmissionsComponent implements OnInit {
  private readonly _submissionsService : SubmissionsApiService;
  private readonly _hubService : SubmissionsStateHubService;

  title = "Submitted submissions";
  submissions?: Submission[];
  isNewSubFormShown: boolean = false;

  constructor(submissionsService: SubmissionsApiService, hubService: SubmissionsStateHubService){
    this._submissionsService = submissionsService;
    this._hubService = hubService;
  }

  ngOnInit(): void {
    this.loadSubmissions();

    this._hubService.connect();
    this._hubService.stateUpdateReceived.subscribe((update) =>{
      console.log("=====>>> HUB: " + JSON.stringify(update));
      this.submissions?.forEach((item) => {
        if (item.id === update.id){
          item.state = update.state;
        }
      });
    });
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
