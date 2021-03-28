import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  // https://api.weatherapi.com/v1/current.json?key=297c639e2e5640f88dd160828212703&q=London&aqi=no
  apiKey = environment.weatherApiKey;
  baseUrl = `https://api.weatherapi.com/v1/current.json?key=${this.apiKey}`;
  constructor(private http: HttpClient) {}
  // https://api.weatherapi.com/v1/forecast.json?key=297c639e2e5640f88dd160828212703&q=Romania&days=10&aqi=no&alerts=no
  getWeatherInfoByName(name: string) {
    return this.http.get(this.baseUrl + `&q=${name}&aqi=no`);
  }

  getCountryNameByCoords(lat: number, long: number) {
    return this.http.get(this.baseUrl + `&q=${lat},${long}&aqi=no`);
  }

  getWeatherInfoByCoords(lat: string, long: string) {
    return this.http.get(this.baseUrl + `&q=${lat},${long}&aqi=no`);
  }

  getWeatherForecastForCity(days: number, cityName: string) {
    return this.http.get(
      `https://api.weatherapi.com/v1/forecast.json?key=${this.apiKey}&q=${cityName}&days=${days}&aqi=no&alerts=no`
    );
  }
}
