import { Weather } from "../weather";
import { Observable } from "rxjs";

export class HomeModel {
    weather: Observable<Weather>;
}
