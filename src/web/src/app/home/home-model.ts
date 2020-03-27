import { Weather } from "../../interfaces/weather";
import { Observable } from "rxjs";

export class HomeModel {
    weather: Observable<Weather>;
}
