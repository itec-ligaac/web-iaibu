import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from '../_models/city';
import { Country } from '../_models/country';
import { CountriesService } from '../_services/countries.service';
import { WeatherService } from '../_services/weather.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  formControl: FormControl;
  rangePicker: any;
  countries: string[];
  filteredCountries: string[];
  cities: string[];
  filteredCities: string[];
  time: any;
  degrees: any;

  constructor(
    private countriesService: CountriesService,
    private weatherService: WeatherService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.populateCountries();
    this.setTime();
    this.setDegrees();
  }

  submit(f: NgForm) {
    const name = f.value.country;
    const cityName = f.value.city;
    let from = f.value.from.toDateString();
    let until = f.value.until.toDateString();

    if (name && this.filteredCountries.includes(name) && cityName) {
      this.router.navigate([`/infocountry`], {
        queryParams: { name, cityName, from, until },
      });
    }
  }

  populateCountries() {
    this.countriesService.getCountryNames().subscribe((countries: string[]) => {
      this.countries = countries;
      this.filteredCountries = countries;
    });
  }

  populateCities(event: any) {
    const value: string = event.target.value;
    if (value && this.countries.includes(value)) {
      this.countriesService
        .getCitiesByCountryName(value)
        .subscribe((cities: City[]) => {
          this.cities = cities.map((x) => x.name);
          this.filteredCities = cities.map((x) => x.name);
        });
    }
  }

  filterCountries(event: any) {
    const value: string = event.target.value;
    if (value) {
      this.filteredCountries = this.countries.filter((country: string) =>
        country.toLowerCase().includes(value.toLowerCase())
      );
    } else {
      this.filteredCountries = this.countries;
    }
  }

  filterCities(event: any) {
    const value: string = event.target.value;
    if (value) {
      this.filteredCities = this.cities?.filter((city: string) =>
        city.toLowerCase().includes(value.toLowerCase())
      );
    } else {
      this.filteredCities = this.cities;
    }
  }

  setTime() {
    const date = new Date();
    const minute = (date.getMinutes() < 10 ? '0' : '') + date.getMinutes();
    const hour = (date.getHours() < 10 ? '0' : '') + date.getHours();
    this.time = hour + ':' + minute;
    setTimeout(() => {
      this.time = hour + ':' + minute;
    }, 1000);
  }

  setDegrees() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((x) => {
        const lat = x.coords.latitude;
        const long = x.coords.longitude;

        this.weatherService
          .getCountryNameByCoords(lat, long)
          .subscribe((data: any) => {
            this.degrees = data.current.temp_c;
          });
      });
    }
  }
}
