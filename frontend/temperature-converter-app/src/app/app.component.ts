import { Component } from '@angular/core';
import { TemperatureConverterService } from './temperature-converter.service';
import { TemperatureConversion } from './TemperatureConversion';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'temperature-converter-app';
  units = ['Celcius', 'Kelvin', 'Fahrenheit'];
  model = new TemperatureConversion('Celcius', 'Kelvin', 0);
  result: number | null = null;

  constructor(private service: TemperatureConverterService) {}

  convert() {
    this.service
      .convert(this.model.from, this.model.to, this.model.amount)
      .subscribe((result) => (this.result = result));
  }
}
