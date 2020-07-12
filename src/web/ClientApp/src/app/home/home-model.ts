import { Weather } from "../weather";
import { Observable } from "rxjs";
import { MonitoredServer } from '../model/monitored-server';

export class HomeModel {
    weather: Weather;
    servers: MonitoredServer[];
}
