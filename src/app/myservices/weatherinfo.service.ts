import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherModal } from '../model/weather-modal';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherinfoService {
  

  webAPiUrl: string = 'https://localhost:7177/WeatherForecast';

  constructor(private http: HttpClient) { 

  }

  getWeather(): Observable<any>{

    return this.http.get(this.webAPiUrl);
  }

  
}
