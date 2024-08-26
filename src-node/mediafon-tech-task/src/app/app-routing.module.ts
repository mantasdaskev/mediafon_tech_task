import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SubmissionsComponent } from './submissions/submissions.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'submissions',
    component: SubmissionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
