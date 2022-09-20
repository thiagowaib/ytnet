using VideoLibrary;

namespace ytNet
{
    class Program
    {
        // ;)
        // Test URL: https://www.youtube.com/watch?v=r5dtl9Uq9V0
        static void Main()
        {

            Console.WriteLine();
            Console.WriteLine("Project at https://github.com/thiagowaib/ytnet");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~   YtNet - The .NET Youtube Downloader    ~~");
            Console.WriteLine();
            while(true)
            {
                Console.WriteLine("Enter your video's URL: ");
                Console.Write(">> ");
                string? url = Console.ReadLine();

                if(url != null && url.Contains("watch?v=")) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose the format:");
                    Console.WriteLine("(1) • Mp4 - Video");
                    Console.WriteLine("(2) • Mp3 - Audio");
                    Console.Write(">> ");
                    string? format = Console.ReadLine();

                    try{
                        if(format != null && format == "2") {
                            DownloadVideo(url, ".mp3");
                        } else {
                            DownloadVideo(url, ".mp4");
                        }
                    }catch(Exception ex) when (ex is System.IO.DirectoryNotFoundException){
                        Console.WriteLine();
                        Console.WriteLine("!! Could Not found default Download folder !!");
                        Console.WriteLine();
                        Console.WriteLine("Enter the folder's path manually: ");
                        Console.Write(">> ");
                        string? path = Console.ReadLine();
                        try{
                            if(path != null &&format != null && format == "2") {
                                DownloadVideo(url, ".mp3", path);
                            } else if(path != null) {
                                DownloadVideo(url, ".mp4", path);
                            }
                        }catch(Exception){
                            Console.WriteLine();
                            Console.WriteLine("**          Oops, something went wrong...           **");
                            Console.WriteLine("** please, check the path you entered and try again **");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine();
                        }
                    }
                    
                } else {
                    Console.WriteLine();
                    Console.WriteLine("**          Oops, something went wrong...           **");
                    Console.WriteLine("** please, check your video's URL and try again ^-^ **");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine();
                }
            }
        }
        static string GetDefaultFolder()
        {
            var home = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);

            return Path.Combine(home, "Downloads");
        }

        static void DownloadVideo(string url, string format)
        {
            // Starting point for YouTube Actions
            var youtube = YouTube.Default;

            // Gets a Video Object with Info about the video
            var video = youtube.GetVideo(url);

            // Download Information
            Console.WriteLine();
            Console.WriteLine("~Title: " + video.FullName);
            Console.WriteLine("~Author: " + video.Info.Author);
            Console.WriteLine("~Duration: " + video.Info.LengthSeconds/60 +":" + video.Info.LengthSeconds%60);
            Console.WriteLine("~Format: " + format);
            Console.WriteLine();

            // Configures downloadPath and downloads video
            string randKey = new Random().Next(1, 200).ToString();
            string fileName = video.FullName.Split(" ")[0] + "_" + randKey + format;
            string filePath = Path.Combine(GetDefaultFolder(), fileName);

            Console.WriteLine("Downloading video at "+filePath);
            File.WriteAllBytes(filePath, video.GetBytes());
            Console.WriteLine("Download Complete!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
        }

        static void DownloadVideo(string url, string format, string customPath)
        {
            // Starting point for YouTube Actions
            var youtube = YouTube.Default;

            // Gets a Video Object with Info about the video
            var video = youtube.GetVideo(url);

            // Download Information
            Console.WriteLine();
            Console.WriteLine("~Title: " + video.FullName);
            Console.WriteLine("~Author: " + video.Info.Author);
            Console.WriteLine("~Duration: " + video.Info.LengthSeconds/60 +":" + video.Info.LengthSeconds%60);
            Console.WriteLine("~Format: " + format);
            Console.WriteLine();

            // Configures downloadPath and downloads video
            string randKey = new Random().Next(1, 200).ToString();
            string fileName = video.FullName.Split(" ")[0] + "_" + randKey + format;
            string filePath = Path.Combine(customPath, fileName);

            Console.WriteLine("Downloading video at "+filePath);
            File.WriteAllBytes(filePath, video.GetBytes());
            Console.WriteLine("Download Complete!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
        }
    }
}