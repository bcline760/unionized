import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

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

        const requestUrl=`https://${environment.domain}/api${url}`;
        let data:R;
        switch (method) {
            case "GET":
                data = await this.http.get<R>(requestUrl, httpOptions).toPromise();
                break;
            case "PUT":
                data = await this.http.put<R>(requestUrl, body, httpOptions).toPromise();
                break;
            case "POST":
                data = await this.http.post<R>(requestUrl, body, httpOptions).toPromise();
                break;
            case "DELETE":
                data = await this.http.delete<R>(requestUrl,httpOptions).toPromise();
                break;
        }

        return data;
    }
}
