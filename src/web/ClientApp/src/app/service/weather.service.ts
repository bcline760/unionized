import { Injectable, Inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { Weather, WeatherConditions, CloudConditions } from '../weather';
import { UnionizedService } from './unionized.service';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherService extends UnionizedService {
    private apiController: string = "session";
    constructor(
        protected client: HttpService,
        @Inject(LOCAL_STORAGE) protected storage: StorageService) {
        super(client, storage);
    }

    public async getCurrentConditions(zipCode: number): Promise<Weather> {
        //const url: string = `${this.apiUrl}&zip=${zipCode},us`;
        const url: string = `${environment.apiUrl}/${this.apiController}`;
        const result = await this.http.getAsync<Weather>(url,this.authenticationToken.loginToken);

        return result;
    }
}
