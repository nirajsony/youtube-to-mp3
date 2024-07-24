import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class YoutubeApiServiceService {

  youtubeApiUrl = "https://localhost:7203/api/Youtube2Audio/v1/DownloadMp3?videoUrl="
  constructor(private http: HttpClient) {

   }

   getmp3File(videoUrl: string): Observable<any>{

    console.log('api has been callled: ' + this.youtubeApiUrl + videoUrl);
    return this.http.get(this.youtubeApiUrl + videoUrl, {responseType : 'blob'});
  }

}
