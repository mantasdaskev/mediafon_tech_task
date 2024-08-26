import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubmissionsComponent } from './submissions/submissions.component';
import { SubmissionComponent } from './submission/submission.component';
import { SubmissionsApiService } from './services/submissions.api.service';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { NewSubmissionComponent } from './new-submission/new-submission.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SubmissionsComponent,
    SubmissionComponent,
    NewSubmissionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    provideHttpClient( withFetch() ),
    SubmissionsApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
