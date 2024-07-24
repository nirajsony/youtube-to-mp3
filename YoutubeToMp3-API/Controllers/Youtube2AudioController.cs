using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NReco.VideoConverter;
using System.Net;
using System.Net.Http.Headers;
using YoutubeExplode;
using YoutubeToMp3Niraj.Converter;

namespace YoutubeToMp3Niraj.Controllers
{
    /// <summary>
    /// The youtube2 audio controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Youtube2AudioController : ControllerBase
    {

        /// <summary>
        /// Downloads the youtube video then converts to mp3.
        /// </summary>
        /// <param name="videoUrl">Youtube video link</param>
        /// <returns>This api stores mp3 audio of youtube video link.</returns>
        /// <response code="201">Stores the mp3 audio</response>
        /// <response code="400">If the video link is null</response>
        [HttpGet]
        [Route("v1/SaveMp3")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DownloadYoutubeMp3(string videoUrl)
        {
            //await DownloadYouTubeVideo(videoUrl, @"E:\youtube");

            string videoPath = string.Empty;

            try
            {
                var youtube = new YoutubeClient();

                var video = await youtube.Videos.GetAsync(videoUrl);

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

                var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList();

                var z = muxedStreams.First(s => s.VideoQuality.Label == "360p");

                using var httpClient = new HttpClient();
                var memoryStream = await httpClient.GetStreamAsync(z.Url);

                string sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

                using (var ms = new MemoryStream())
                {
                    var fileName = $"{sanitizedTitle}";

                    string tempFilePath = Path.Combine(@"E:\youtube\" + fileName + ".mp4");

                    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fs);
                    }
                    videoPath = tempFilePath;

                }

                // extract first 10 character for file name from tile
                var audioFileName = sanitizedTitle.Substring(0, 15);



                bool isConverted = await ConvertToMp3.ConvertVideoToMp3(videoPath, @"E:\youtube\" + audioFileName, @"E:\youtube\");


                return Ok(isConverted);


            }
            catch (Exception ex)
            {

                var z = ex.Message;
            }

            //if (audioStreamInfo.Size.Bytes > 0)
            //{
            //    using (FileStream fs = new FileStream(System.IO.Directory.GetCurrentDirectory() + "\\" + "zyx.mp4", FileMode.Create, FileAccess.Write, FileShare.Read))
            //    {
            //         //fs.Write(bytes, 0, bytes.Length);
            //    }
            //}
            Console.WriteLine(System.Environment.CurrentDirectory);
            Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());


            // await System.IO.File.WriteAllBytesAsync(System.IO.Directory.GetCurrentDirectory() + "\\" + video.FullName, video.GetBytes());

            return Ok("Ok");
        }



        /// <summary>
        /// Returns a mp3 file from youtube video link.
        /// </summary>
        /// <param name="videoUrl">Youtube video link</param>
        /// <returns>This api returns mp3 file of youtube video link.</returns>
        /// <response code="201">Returns the mp3 audio file</response>
        /// <response code="400">If the video is null</response>
        [HttpGet]
        [Route("v1/DownloadMp3")]
        public async Task<IActionResult> DownloadMp3File(string videoUrl)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(@"E:\youtube\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            string videoPath = string.Empty;

            try
            {
                var youtube = new YoutubeClient();

                var video = await youtube.Videos.GetAsync(videoUrl);

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

                var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList();

                var z = muxedStreams.First(s => s.VideoQuality.Label == "360p");

                using var httpClient = new HttpClient();
                var memoryStream = await httpClient.GetStreamAsync(z.Url);

                string sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

                using (var ms = new MemoryStream())
                {
                    var fileName = $"{sanitizedTitle}";

                    string tempFilePath = Path.Combine(@"E:\youtube\" + fileName + ".mp4");

                    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fs);
                    }
                    videoPath = tempFilePath;

                }

                // extract first 10 character for file name from tile
                var audioFileName = string.Empty;
                if(sanitizedTitle.Length > 10)
                {
                    sanitizedTitle.Substring(0, 15);
                }


                var physicalFilePath = await ConvertToMp3.DownloadToMp3File(videoPath, @"E:\youtube\" + audioFileName);


                if (System.IO.File.Exists(physicalFilePath))
                {
                    var fileStream = new FileStream(physicalFilePath, FileMode.Open, FileAccess.Read);

                    return File(fileStream, "audio/mpeg", audioFileName + ".mp3");
                }
                else
                {
                    return NotFound(); // Return a 204 Not Found response if the file does not exist.
                }

            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

       
    }
}
