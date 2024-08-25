import { Submission } from "./submission";

export class SubmissionsResponse{
    private _submissions : Submission[];

    constructor(submissions : Submission[]) {
        this._submissions = submissions;
    }

    get submissions() { return this._submissions; }
}