import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Injectable } from "@angular/core";

import { SubmissionsResponse } from "../models/submissions.response";

@Injectable()
export class SubmissionsApiService{ 

    readonly ROOT = 'https://localhost:7156';

    private _httpOptions = {
        headers: new HttpHeaders({
            'Access-Control-Allow-Methods':'DELETE, POST, GET, OPTIONS',
            'Access-Control-Allow-Headers':'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
            'Content-Type':  'application/json'
        })
      };

    constructor(private _client : HttpClient) {
    }

    getSubmissions(callback: (subsResponse: SubmissionsResponse) => void) {
        this._client
                .get<SubmissionsResponse>(this.ROOT + '/api/submissions/123', this._httpOptions)
                    .subscribe(r => callback(r));
    }
}