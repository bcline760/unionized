import { Injectable } from '@angular/core';
import { tap, catchError, shareReplay } from 'rxjs/operators';

import { Weather, WeatherConditions, CloudConditions } from '../interfaces/weather';
import { Observable } from 'rxjs';
import { UnionizedService } from './unionized.service';
import { LoadingService } from './loading.service';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherService extends UnionizedService {
    private apiUrl: string = "https://api.openweathermap.org/data/2.5/weather?apiKey=1b73449d5ecefc1bc0a830ed86e4e495";
    constructor(protected client: HttpService, protected loadingSvc: LoadingService) {
        super(client, loadingSvc);
    }

    public getCurrentConditions(zipCode: number): Observable<Weather> {
        const url: string = `${this.apiUrl}&zip=${zipCode},us`;

        const result:Observable<Weather> = this.http.get<Weather>(url).pipe(
            catchError(this.handleError)
        );

        return result;
    }
}
