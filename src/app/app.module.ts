import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeatherComponentComponent } from './myComponent/weather-component/weather-component.component';
import { WeatherComponentDetailComponent } from './myComponent/weather-component-detail/weather-component-detail.component';
import { WeatherinfoService } from './myservices/weatherinfo.service';
import { TableModule } from 'primeng/table'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { YouTubeToMp3Component } from './you-tube-to-mp3/you-tube-to-mp3.component';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponentComponent,
    WeatherComponentDetailComponent,
    YouTubeToMp3Component,
      
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    BrowserAnimationsModule,
    InputTextModule,
    ButtonModule,
    FormsModule,
    FieldsetModule
  ],
  providers: [WeatherinfoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
