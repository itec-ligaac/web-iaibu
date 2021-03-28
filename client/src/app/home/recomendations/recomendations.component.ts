import { Component, OnInit } from '@angular/core';
import { CountriesService } from 'src/app/_services/countries.service';

@Component({
  selector: 'app-recomendations',
  templateUrl: './recomendations.component.html',
  styleUrls: ['./recomendations.component.css'],
})
export class RecomendationsComponent implements OnInit {
  countries: any;
  constructor(private countryService: CountriesService) {}

  ngOnInit(): void {
    this.countryService.getRecomendations().subscribe((data) => {
      const filtered = data.filter(
        (x) => x.data[x.data.length - 1].total_vaccinations_per_hundred > 18.0
      );
      this.countries = filtered;
    });
  }
}
