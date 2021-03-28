import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-day-forecast',
  templateUrl: './day-forecast.component.html',
  styleUrls: ['./day-forecast.component.css'],
})
export class DayForecastComponent implements OnInit {
  @Input() weather: any;
  @Input() data: any;
  constructor() {}

  ngOnInit(): void {}
}
