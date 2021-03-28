import { Component, Input, OnInit } from '@angular/core';
import { Country } from 'src/app/_models/country';
import { CountriesService } from 'src/app/_services/countries.service';
import { PopulationService } from 'src/app/_services/population.service';
import { UserlocationService } from 'src/app/_services/userlocation.service';
import { WeatherService } from 'src/app/_services/weather.service';

@Component({
  selector: 'app-info-presentation',
  templateUrl: './info-presentation.component.html',
  styleUrls: ['./info-presentation.component.css'],
})
export class InfoPresentationComponent implements OnInit {
  @Input() name: string;
  @Input() cityName: string;
  country: Country;
  weather: any;
  population: number;
  flagCountryUrl: string;

  constructor(
    private weatherService: WeatherService,
    private populationService: PopulationService,
    private countriesService: CountriesService
  ) {}

  ngOnInit(): void {
    if (this.name) {
      this.getCountryByNameWithLatestData(this.name);
      this.setCountryFlag(this.name);
      this.getWeatherByCountryName(this.name);
    }
  }

  getWeatherByCountryName(name: string) {
    this.weatherService.getWeatherInfoByName(name).subscribe((data) => {
      this.weather = data;
    });
  }

  setCountryFlag(name: string) {
    this.populationService.getCountryFlag(name).subscribe((data: any) => {
      this.flagCountryUrl = data[0].flag;
    });
  }

  getCountryByNameWithLatestData(name: string) {
    this.countriesService
      .getCountryByNameWithLatestData(name)
      .subscribe((country: Country) => {
        this.country = country;
      });
  }
}
