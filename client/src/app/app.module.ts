import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CountryInfoComponent } from './country-info/country-info.component';
import { WeatherComponent } from './country-info/weather/weather.component';
import { InfoPresentationComponent } from './country-info/info-presentation/info-presentation.component';
import { DayForecastComponent } from './country-info/day-forecast/day-forecast.component';
import { RecomendationsComponent } from './home/recomendations/recomendations.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    CountryInfoComponent,
    WeatherComponent,
    InfoPresentationComponent,
    DayForecastComponent,
    RecomendationsComponent,
    AboutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
