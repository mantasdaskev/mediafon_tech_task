import { Injectable } from "@angular/core";
import * as signalR from '@microsoft/signalr';

import { CONFIG } from "./CONFIG";
import { Subject } from "rxjs";
import { Submission } from "../models/submission";

@Injectable()
export class SubmissionsStateHubService{
    private _connection: signalR.HubConnection | null = null;

    connectionEstablished = new Subject<Boolean>();
    stateUpdateReceived = new Subject<Submission>()

    connect(){
        if (!this._connection){
            this._connection = new signalR.HubConnectionBuilder()
            .withUrl(CONFIG.baseUrl +'/submissions-state-hub')
            .build();
        }

        this._connection.start().then(() => {
            console.log('Hub connection started');
            this.connectionEstablished.next(true); 
        }).catch(err => console.log("Connection to hub failed with an error: " + err))

        this._connection.on('ReceiveSubmissionUpdate', (stateUpdate) => {
            console.log('Received', stateUpdate);
            this.stateUpdateReceived.next(stateUpdate);
          });
    }

    disconnect() {
        if (this._connection) {
          this._connection.stop();
          this._connection = null;
        }
      }
}