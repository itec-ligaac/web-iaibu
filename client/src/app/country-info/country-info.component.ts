import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherService } from '../_services/weather.service';

@Component({
  selector: 'app-country-info',
  templateUrl: './country-info.component.html',
  styleUrls: ['./country-info.component.css'],
})
export class CountryInfoComponent implements OnInit {
  name: string;
  localName: string;
  cityName: string;
  localCityName: string;
  days: number;
  arrayOfDates: any = [];
  forecasts: any = [];

  constructor(
    private route: ActivatedRoute,
    private weatherService: WeatherService
  ) {}

  ngOnInit(): void {
    const name = this.route.snapshot.queryParams.name;
    const cityName = this.route.snapshot.queryParams.cityName;
    const from = this.route.snapshot.queryParams.from;
    const until = this.route.snapshot.queryParams.until;
    if (name) {
      this.name = name;
      this.cityName = cityName;
    }
    this.getCurrentUserLocation();
    this.getForecastForDays(from, until);
  }

  getCurrentUserLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((x) => {
        const lat = x.coords.latitude;
        const long = x.coords.longitude;

        this.weatherService
          .getCountryNameByCoords(lat, long)
          .subscribe((data: any) => {
            this.localName = data.location.country;
            this.localCityName = data.location.region;
          });
      });
    }
  }

  getForecastForDays(from: any, until: any) {
    this.weatherService
      .getWeatherForecastForCity(10, this.name)
      .subscribe((data: any) => {
        this.forecasts = data.forecast.forecastday;
        this.composeRangeOfArrays(from, until);
      });
  }

  getForecast() {
    let random = 0;
    if (this.forecasts) {
      random = Math.floor(Math.random() * this.forecasts.length);
      return this.forecasts[random].day;
    }
  }

  composeRangeOfArrays(from: any, until: any) {
    from = new Date(from);
    until = new Date(until);
    var getDaysArray = function (start, end) {
      for (
        var arr = [], dt = new Date(start);
        dt <= end;
        dt.setDate(dt.getDate() + 1)
      ) {
        arr.push(new Date(dt));
      }
      return arr;
    };

    getDaysArray(from, until).forEach((date: Date) => {
      const day = date.getDate();
      const month = date.getMonth() + 1;
      const year = date.getFullYear();
      const newDate = `${day}/${month}/${year}`;
      this.arrayOfDates.push(newDate);
    });
  }
}
