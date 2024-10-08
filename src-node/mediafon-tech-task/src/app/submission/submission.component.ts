import { Component, Input } from '@angular/core';
import { SubmissionType } from '../models/submission.type';
import { SubmissionState } from '../models/submission.state';

@Component({
  selector: 'app-submission',
  templateUrl: './submission.component.html',
  styleUrl: './submission.component.css'
})


export class SubmissionComponent {
  private _type: SubmissionType = SubmissionType.Undefined;
  private _state: SubmissionState = SubmissionState.Unknown;
  private _submissionId: string = '';

  @Input() date: string = ''; 

  @Input() get submissionId(){
    return this._submissionId.split('-')[0];
  }
  set submissionId(value: string){
    this._submissionId = value;
  }

  @Input() get type(): string {
    return SubmissionType[this._type];
  }
  set type(value: SubmissionType){
    this._type = value;
  }

  @Input() get state(): string {
    return SubmissionState[this._state];
  }
  set state(value: SubmissionState){
    this._state = value;
  }
}
