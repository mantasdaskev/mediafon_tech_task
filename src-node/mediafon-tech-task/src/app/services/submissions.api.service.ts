import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Injectable } from "@angular/core";

import { Submission } from "../models/submission";
import { LoginResponse } from "../models/login.response";
import { NewSubmission } from "../models/new.submission";
import { catchError, of } from "rxjs";

import { CONFIG } from "./CONFIG";

@Injectable()
export class SubmissionsApiService{ 
    private readonly USERID_KEY = 'userId';

    private _httpOptions = {
        headers: new HttpHeaders({
            'Access-Control-Allow-Methods':'DELETE, POST, GET, OPTIONS',
            'Access-Control-Allow-Headers':'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
            'Content-Type':  'application/json'
        })
      };

    constructor(private _client: HttpClient) {
    }

    getSubmissions(callback: (subsResponse: Submission[]) => void) {
        this._client
                .get<Submission[]>(CONFIG.baseUrl + '/api/submissions/' + localStorage.getItem(this.USERID_KEY), this._httpOptions)
                    .subscribe(r => callback(r));
    }

    tryGetUserContext(userName: string, callback: (isSuccess: boolean) => void) {
        let body = {
            "username": userName
        }

        this._client
            .post<LoginResponse>(CONFIG.baseUrl + '/api/login', body, this._httpOptions)
            .pipe(
                catchError((error) => {
                    console.error("Failed to get user", error);
                    callback(false);
                    return of(null);
                })
            )    
            .subscribe((response) =>
            {
                if (response === null){
                    console.warn("Getting user was successful but response was received empty.");
                    callback(false);
                    return;
                }
                console.log("Received user. Id: " + response.userId);
                //TODO: would be good to clear at some point...
                localStorage.setItem(this.USERID_KEY, response.userId)
                
                callback(true);
            });
    }

    postNewSubmission(newSubmission: NewSubmission, callback: (isSuccess: boolean) => void){
        let body = {
            "userid": localStorage.getItem(this.USERID_KEY),
            "type": newSubmission.type,
            "message": newSubmission.message
        }

        console.log(JSON.stringify(body));

        this._client
            .post(CONFIG.baseUrl + '/api/submissions/new', body, this._httpOptions)
            .pipe(
                catchError((error) => {
                    console.error("Failed to get user", error);
                    callback(false);
                    return of(null);
                })
            )    
            .subscribe(() =>
            {
                callback(true);
            });
        }
}