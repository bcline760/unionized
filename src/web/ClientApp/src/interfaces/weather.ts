import { Coordinate } from "./coordinate";

export interface WeatherConditions {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export interface CurrentConditions {
    temp: number;
    pressure: number;
    humidity: number;
    temp_min: number;
    temp_max: number;
}

export interface WindConditions {
    speed: number;
    deg: number;
}

export interface CloudConditions {
    all: number;
}

export interface StationInfo {
    type: number;
    id: number;
    message: number;
    country: string;
    sunrise: number;
    sunset: number;
}

export interface Weather {
    coord: Coordinate;
    weather: WeatherConditions;
    base: string;
    main: CurrentConditions;
    wind: WindConditions;
    visibility: number;
    clouds: CloudConditions;
    dt: number;
    sys: StationInfo;
    timezone: number;
    id: number;
    name: string;
    cod: number;
}
