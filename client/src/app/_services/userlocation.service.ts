import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserlocationService {
  country: string;
  apikey = 'd1948667bb6401cbafedf7bc70c07d2b';
  baseUrl = `https://api.positionstack.com/v1/reverse?access_key=${this.apikey}&query=`;
  // http://api.positionstack.com/v1/reverse ? access_key = YOUR_ACCESS_KEY & query = 40.7638435,-73.9729691

  constructor(private httpClient: HttpClient) {}

  getUserCountry(lat: any, long: any) {
    return this.httpClient.get(`${this.baseUrl}${lat},${long}`);
  }
}
