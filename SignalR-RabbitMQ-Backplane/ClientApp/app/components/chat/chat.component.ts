import { Component, OnInit } from '@angular/core';
import { HubConnection, LogLevel } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: "chat",
    templateUrl: "./chat.component.html"
})

export class ChatComponent {
    private _hubConnection: HubConnection | undefined;
    public async: any;
    message = '';
    messages: string[] = [];

    constructor(private http: HttpClient) {

    }

    public sendMessage(): void {
        const data = `Sent: ${this.message}`;
        this.message = "";
;        //if (this._hubConnection) {
        //    this._hubConnection.invoke('Send', data);
        //}
        //this.messages.push(data);
        this.http.post("/api/chat/send", data, ).subscribe(res => {
            this.messages.push(data);
        }, err => console.error(err));
    }

    ngOnInit() {
        this._hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('http://localhost:58288/loopy')
            .configureLogging(signalR.LogLevel.Information)
            .build();

        this._hubConnection.start().catch(err => console.error(err.toString()));

        this._hubConnection.on('Send', (data: any) => {
            const received = `Received: ${data}`;
            this.messages.push(received);
        });
    }
}
