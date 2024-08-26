import { Component, EventEmitter, Output } from '@angular/core';
import { SubmissionType } from '../models/submission.type';
import { NewSubmission } from '../models/new.submission'

@Component({
  selector: 'app-new-submission',
  templateUrl: './new-submission.component.html',
  styleUrl: './new-submission.component.css'
})
export class NewSubmissionComponent {
  @Output() submitEvent = new EventEmitter<NewSubmission>();
  @Output() closeEvent = new EventEmitter<void>();
  submissionMessage: string = '';

  submissionTypes = SubmissionType;
  selectedType: SubmissionType = SubmissionType.Undefined;

  onSubmit(){
    if(this.selectedType === SubmissionType.Undefined){
      alert('Please, select a valid submission type.');
      return;

    }

    if (this.submissionMessage.trim() === ''){
      alert('Message cannot be empty.');
      return;
    }

    this.submitEvent.emit(new NewSubmission(this.selectedType, this.submissionMessage));
  }

  onClose(){
    this.closeEvent.emit();
  }

  mapToText(type: SubmissionType) : string {
    switch(type) { 
      case SubmissionType.Request: { 
        return 'Undefined' 
      }
      case SubmissionType.Suggestion: { 
        return 'Suggestion' 
      }
      case SubmissionType.Complaint: { 
        return 'Complaint' 
      }
      default: { 
         return 'Undefined'
      } 
    }
  }



  //TODO: move somewhere else?...
  getEnumKeys(enumObj: any): SubmissionType[] {
    return Object.values(enumObj).filter(value => typeof value === 'number');
  }
}
