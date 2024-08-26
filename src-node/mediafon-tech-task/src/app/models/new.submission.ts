import { SubmissionType } from "./submission.type";

export class NewSubmission{
    constructor(private _type: SubmissionType, private _message: string){
    }

    get type() { return this._type; }
    get message() { return this._message; }
}