import { SubmissionType } from "./submission.type";
import { SubmissionState } from "./submission.state";

export interface Submission {
    id: string,
    date: string,
    type: SubmissionType,
    state: SubmissionState
}