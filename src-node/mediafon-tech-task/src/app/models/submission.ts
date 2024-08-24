import { SubmissionState } from "./submission.state";
import { SubmissionType } from "./submission.type";

export class Submission {
    constructor(private _id : string, private _date : string, private _type : SubmissionType, private _state : SubmissionState) {
    }

    get id() {
        return this._id; 
    }

    //TODO: check if there is appropriate type for that or add formatting.
    get date() {
        return this._date; 
    }

    get type() : SubmissionType{
        return this._type; 
    }

    get state() { 
        return this._state; 
    }
    set state(value : SubmissionState) { 
        this._state = value; 
    }

}