import { Component, OnInit } from '@angular/core';
import { WeatherModal } from 'src/app/model/weather-modal';
import { WeatherinfoService } from 'src/app/myservices/weatherinfo.service';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-weather-component',
  templateUrl: './weather-component.component.html',
  styleUrls: ['./weather-component.component.css']
})
export class WeatherComponentComponent  implements OnInit{
[x: string]: any;

  weatherDataList: WeatherModal[] = [];

  constructor (private weatherService: WeatherinfoService){

  }

  ngOnInit(): void {
    this.getAllWeather();
  }

  getAllWeather(){
   return this.weatherService.getWeather().subscribe(
      ( data: any) => {

        this.weatherDataList =  data;
        console.log(data);

      }
    )
  }

}
