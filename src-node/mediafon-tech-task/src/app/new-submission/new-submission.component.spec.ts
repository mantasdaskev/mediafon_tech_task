import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSubmissionComponent } from './new-submission.component';

describe('NewSubmissionComponent', () => {
  let component: NewSubmissionComponent;
  let fixture: ComponentFixture<NewSubmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewSubmissionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewSubmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
