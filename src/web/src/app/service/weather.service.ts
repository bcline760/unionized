import { Injectable } from '@angular/core';
import { tap, catchError, shareReplay } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Weather, WeatherConditions, CloudConditions } from '../weather';
import { Observable } from 'rxjs';
import { UnionizedService } from './unionized.service';
import { LoadingService } from './loading.service';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherService extends UnionizedService {
    private apiController: string = "session";
    constructor(protected client: HttpService, protected loadingSvc: LoadingService) {
        super(client, loadingSvc);
    }

    public getCurrentConditions(zipCode: number): Observable<Weather> {
        //const url: string = `${this.apiUrl}&zip=${zipCode},us`;
        const url: string = `${environment.apiUrl}/${this.apiController}`;

        const result:Observable<Weather> = this.http.get<Weather>(url).pipe(
            catchError(this.handleError)
        );

        return result;
    }
}
