import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable()
export class HttpService {
    constructor(private client: HttpClient) {
    }

    get<R>(url: string, authToken?: string): Observable<R> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        if (authToken || authToken=='')
            httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);

        let response: Observable<R> = this.client.get<R>(url, httpOptions);

        return response;
    }

    async getAsync<R>(url: string, authToken?: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        if (authToken || authToken=='')
            httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);

        const data = await this.client.get<R>(url, httpOptions).toPromise();
        return data;
    }

    send<R, B>(url: string, body: B, method: "POST" | "PUT", authToken?: string): Observable<R> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        if (authToken || authToken=='')
            httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);

        let response: Observable<R>;

        switch (method) {
            case "POST":
                response = this.client.post<R>(url, body, httpOptions);
                break;
            case "PUT":
                response = this.client.put<R>(url, body, httpOptions);
                break;
        }

        return response;
    }

    async sendAsync<R, B>(url: string, body: B, method: "POST" | "PUT", authToken?: string): Promise<R> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        if (authToken || authToken=='')
            httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);

        let response: R;

        switch (method) {
            case "POST":
                response = await this.client.post<R>(url, body, httpOptions).toPromise();
                break;
            case "PUT":
                response = await this.client.put<R>(url, body, httpOptions).toPromise();
                break;
        }

        return response;
    }
}