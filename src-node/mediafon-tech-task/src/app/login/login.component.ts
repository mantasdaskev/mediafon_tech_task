import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SubmissionsApiService } from '../services/submissions.api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private readonly _apiService : SubmissionsApiService;
  private readonly _router : Router;
  
  private _userName : string = '';

  constructor(service: SubmissionsApiService, router: Router){
    this._apiService = service;
    this._router = router;
  }

  get userName() { return this._userName; }
  set userName(value : string) { this._userName = value; }

  onSubmit() {
    if(this.userName.trim() === ''){
      //TODO: validation on the tag would be more appropriate. 
      alert("Please, provide the user name.")
      return;
    }

    this._apiService.tryGetUserContext(this.userName, (isSuccess : boolean) => {
      if (!isSuccess){
        alert("Failed to get user!");
        return;
      }
      this._router.navigate(['/submissions']);
    });
  }
}
