using FFmpeg.AutoGen;
using Microsoft.AspNetCore.Hosting.Server;
using NReco.VideoConverter;
using System;
using System.Net;
using TagLib;
using TagLib.Id3v2;
using TagLib.Mpeg;

namespace YoutubeToMp3Niraj.Converter
{
    /// <summary>
    /// The convert to mp3.
    /// </summary>
    public class ConvertToMp3
    {
        /// <summary>
        /// Converts the video to mp3.
        /// </summary>
        /// <param name="inputVideoPath">The input video path.</param>
        /// <param name="outputAudioPath">The output audio path.</param>
        /// <param name="thumbnailJPEGpath"></param>
        /// <returns>A Task.</returns>
        public static async Task<bool> ConvertVideoToMp3(string inputVideoPath, string outputAudioPath, string thumbnailJPEGpath)
        {
            try
            {
                var task = await Task.Run(() =>
                {
                    var convertVideo = new NReco.VideoConverter.FFMpegConverter();
                    convertVideo.ConvertMedia(inputVideoPath, outputAudioPath + ".mp3", "mp3");

                    //convertVideo.GetVideoThumbnail(inputVideoPath, thumbnailJPEGpath + "videoThumb.jpg");

                    //await AddAlbumArtToAudioFile(outputAudioPath + ".mp3", thumbnailJPEGpath + "videoThumb.jpg");

                    return true;
                });
                return task;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public static async Task<bool> AddAlbumArtToAudioFile(string inputAudioMp3Path, string thumbnailJPEGpath)
        {
            try
            {
                var task = await Task.Run(() =>
                {
                    byte[] imgdata = System.IO.File.ReadAllBytes(thumbnailJPEGpath);

                    using (var file = TagLib.File.Create(inputAudioMp3Path))
                    {
                        // Create a new ID3v2 tag
                        var id3v2Tag = new TagLib.Id3v2.Tag();

                        // Create an IPicture object from the cover art image
                        IPicture picture = new Picture(thumbnailJPEGpath);

                        // Set the picture as the cover art
                        id3v2Tag.Pictures = new IPicture[] { picture };

                        // Remove any existing ID3v2 tag
                        file.RemoveTags(TagTypes.Id3v2);


                        AttachmentFrame cover = new AttachmentFrame
                        {
                            Type = TagLib.PictureType.FrontCover,
                            Description = "Cover",
                            MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                            Data = imgdata,
                            TextEncoding = TagLib.StringType.UTF16

                        };

                        file.Tag.Pictures = new TagLib.IPicture[] { cover };
                     

                        // Save the changes
                        file.Save();
                    }






                    /*// Load the MP3 file
                    var file = TagLib.File.Create(inputAudioMp3Path);

                    // Create an IPicture object from the cover art image
                    IPicture picture = new Picture(thumbnailJPEGpath);

                    // Create an ID3v2 tag if it doesn't exist
                    if (file.Tag is null || !(file.Tag is TagLib.Id3v2.Tag id3v2Tag))
                    {
                        id3v2Tag = new TagLib.Id3v2.Tag();
                        file.Tag. = id3v2Tag;

                    }
                    // Create a Tag object (ID3v2 tag)
                    TagLib.Tag tag = file.GetTag(TagTypes.Id3v2, true);


                    // Set the picture as the cover art
                    tag.Pictures = new IPicture[] { picture };

                    // Save the changes
                    file.Save();*/

                    return true;
                });
                return task;
            }
            catch (Exception)
            {

                return false;
            }

        }


        /// <summary>
        /// Downloads the to mp3.
        /// </summary>
        /// <param name="inputVideoPath">The input video path.</param>
        /// <param name="outputAudioPath">The output audio path.</param>
        /// <returns>A Task.</returns>
        public static async Task<string> DownloadToMp3File(string inputVideoPath, string outputAudioPath)
        {
            try
            {
                var task = await Task.Run(async () =>
                {
                    var convertVideo = new NReco.VideoConverter.FFMpegConverter();
                    convertVideo.ConvertMedia(inputVideoPath, outputAudioPath + ".mp3", "mp3");
                    

                    var filePath = outputAudioPath + ".mp3";
                    
                    return filePath;
                   
                });
                return task;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }





    }
}
