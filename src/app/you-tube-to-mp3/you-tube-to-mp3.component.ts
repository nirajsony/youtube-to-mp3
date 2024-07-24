import { HttpResponse } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { YoutubeApiServiceService } from 'src/app/youtubeService/youtube-api-service.service';

@Component({
  selector: 'app-you-tube-to-mp3',
  templateUrl: './you-tube-to-mp3.component.html',
  styleUrls: ['./you-tube-to-mp3.component.css']
})
export class YouTubeToMp3Component implements OnInit, AfterViewInit {
  
   styleDictionary = {
    'background': 'yellow',
    'color': 'red'
  };


  constructor (private ytservice :YoutubeApiServiceService){
    
  }

 
  @ViewChild('spinner') spinner!: ElementRef;


  ngAfterViewInit(): void {
    
    this.spinner.nativeElement.style.display = 'none';
  }

  
  
 
  
  
  youtubeVideoUrl: any;
  isDisabled = true;
  
  ngOnInit(): void {

    //document.getElementById('loading')!.style.display = 'none';
    this
    //this.myBgcolor.style.se
    
    this.isDisabled = false;
  }


  

  getAllWeather(){

    //document.getElementById('loading')!.style.display = '';
    this.spinner.nativeElement.style.display = '';
    this.isDisabled = true;
    

    return this.ytservice.getmp3File(this.youtubeVideoUrl).subscribe(
       ( data: HttpResponse<Blob>) => {

        console.log(this.youtubeVideoUrl);

        
        this.downloadFile(data);
        
 
       }
     )
   }

   getFileNameWithName(){

    return this.ytservice.getmp3File(this.youtubeVideoUrl).subscribe((response: HttpResponse<Blob>) => {
      // Extract content disposition header

    console.log(response.headers.keys());

      const contentDisposition = response.headers.get('content-disposition');
    
      // Extract the file name
      const filename = contentDisposition?.toString();
      console.log(filename);
      //.split(';')[1].split('filename')[1].split('=')[1].trim().match(/"([^"]+)"/)[1];
    });

   }

   downloadFile(data: any) {
    

    const blob = new Blob([data], { type: 'audio/mpeg' });

    
    const url= window.URL.createObjectURL(blob);
    var anchor = document.createElement("a");
    anchor.download = "result.mp3";
    anchor.href = url;
    anchor.click();
    document.getElementById('loading')!.style.display = 'none';
    this.isDisabled = false;
    //window.open(url);
  }

  

}
