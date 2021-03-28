import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PopulationService {
  baseUrl = 'https://restcountries.eu/rest/v2/name/';
  constructor(private http: HttpClient) {}

  getCountryPopulation(name: string) {
    return this.http.get(this.baseUrl);
  }

  getCountryFlag(name: string) {
    return this.http.get(this.baseUrl + name);
  }
}
