import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

    constructor(private http: HttpClient) { }

    /// Get data from the webserver
    async getAsync<R>(url: string, authToken?: string): Promise<R> {
        return await this._executeHttpMethod(url, "GET", authToken);
    }

    async putAsync<R, B>(url: string, body: B, authToken?: string):Promise<R> {
        return await this._executeHttpMethod(url, "PUT", authToken, body);
    }

    async postAsync<R, B>(url: string, body: B, authToken?: string): Promise<R> {
        return await this._executeHttpMethod(url,"POST", authToken, body);
    }

    ///Delete data from the webserver
    async deleteAsync<R>(url: string, authToken?: string): Promise<R> {
        return await this._executeHttpMethod(url, "DELETE", authToken);
    }

    private async _executeHttpMethod<R, B>(url: string, method: "GET" | "PUT" | "POST"| "DELETE", authToken?: string, body?: B): Promise<R> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        if (authToken) {
            httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);
        }
        
        let data:R;
        switch (method) {
            case "GET":
                data = await this.http.get<R>(url, httpOptions).toPromise();
                break;
            case "PUT":
                data = await this.http.put<R>(url, body, httpOptions).toPromise();
                break;
            case "POST":
                data = await this.http.post<R>(url, body, httpOptions).toPromise();
                break;
            case "DELETE":
                data = await this.http.delete<R>(url,httpOptions).toPromise();
                break;
        }

        return data;
    }
}
