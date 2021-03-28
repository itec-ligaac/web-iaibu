import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { City } from '../_models/city';
import { Country } from '../_models/country';

@Injectable({
  providedIn: 'root',
})
export class CountriesService {
  baseUrl = environment.apiUrl + 'countries/';

  constructor(private http: HttpClient) {
    this.getCountryNames();
  }

  getCountryNames() {
    return this.http.get(this.baseUrl + 'countryNames');
  }

  getCountryByNameWithLatestData(name: string) {
    return this.http.get<Country>(this.baseUrl + `filter?name=${name}`);
  }

  getCountryByNameAndDate(name: string, from: string, until: string) {
    const objToSend = { name, from, until };
    return this.http.post<Country>(this.baseUrl + `filter`, objToSend);
  }

  getCitiesByCountryName(name: string) {
    return this.http.get<City[]>(this.baseUrl + 'city/' + name);
  }

  getRecomendations() {
    return this.http.get<any>(this.baseUrl);
  }
}
