export interface datatype {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
export class WeatherModal implements datatype {
   date: string;
   temperatureC: number;
   temperatureF: number;
   summary: string;

  constructor(weatherData: any){

    this.date = weatherData.date;
    this.temperatureC = weatherData.temperatureC;
    this.temperatureF = weatherData.temperatureF;
    this.summary = weatherData.summary;

  }

}
