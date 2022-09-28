import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TemperatureConverterService {
  constructor(private http: HttpClient) {}

  apiUrl = 'https://localhost:7119/TemperatureConverter';

  convert(from: string, to: string, amount: number) {
    return this.http.get<number>(
      `${this.apiUrl}?from=${from}&to=${to}&amount=${amount}`
    );
  }
}
