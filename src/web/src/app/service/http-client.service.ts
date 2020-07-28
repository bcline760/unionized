import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

    constructor(protected http: HttpClient) { }

    /// Get data from the webserver
    async getAsync<R>(url: string): Promise<R> {
        return await this._executeHttpMethod(url, "GET");
    }

    async putAsync<R, B>(url: string, body: B):Promise<R> {
        return await this._executeHttpMethod(url, "PUT",body);
    }

    async postAsync<R, B>(url: string, body: B): Promise<R> {
        return await this._executeHttpMethod(url,"POST",body);
    }

    ///Delete data from the webserver
    async deleteAsync<R>(url: string): Promise<R> {
        return await this._executeHttpMethod(url, "DELETE");
    }

    private async _executeHttpMethod<R, B>(url: string, method: "GET" | "PUT" | "POST"| "DELETE",  body?: B): Promise<R> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

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
