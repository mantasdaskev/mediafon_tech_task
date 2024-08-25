import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubmissionsComponent } from './submissions/submissions.component';
import { SubmissionComponent } from './submission/submission.component';
import { SubmissionsApiService } from './services/submissions.api.service';
import { provideHttpClient, withFetch } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    SubmissionsComponent,
    SubmissionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient( withFetch() ),
    SubmissionsApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
