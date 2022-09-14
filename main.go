package main

import (
	"fmt"
	"io"
	"os"
	"strings"

	"github.com/kkdai/youtube/v2"
)

func Download(url string, format string) (result int) {

	// url := "https://www.youtube.com/watch?v=ty1IeUz_YcA"
	if !strings.Contains(url, "watch?v=") {
		return 0
	}

	videoID := strings.Split(url, "watch?v=")[1]
	client := youtube.Client{}

	video, err := client.GetVideo(videoID)
	if err != nil {
		return 0
	}

	fmt.Print("\n: Title :  " + video.Title)
	fmt.Print("\n: Author : " + video.Author)

	if format == ".mp4" {
		fmt.Print("\n\n* Downloading Video *")
	} else {
		fmt.Print("\n\n* Downloading Audio *")
	}

	fmt.Print("\n!! Don't open downloaded file until confirmation message !!\n")

	formats := video.Formats.WithAudioChannels() // only get videos with audio
	stream, _, err := client.GetStream(video, &formats[0])
	if err != nil {
		return 0
	}

	videoTitle := strings.Split(video.Title, " ")[0]
	randKey := videoTitle + "_" + video.ID + format

	file, err := os.Create(randKey)
	if err != nil {
		return 0
	}
	defer file.Close()

	_, err = io.Copy(file, stream)
	if err != nil {
		return 0
	}

	return 1
}

func main() {
	fmt.Print("\nProject at https://github.com/thiagowaib/ytgo\n")
	fmt.Print("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")
	fmt.Print("\n~~    YTGO - The Go Youtube Downloader     ~~\n\n")
	for i := 0; true; i++ {

		if i > 0 {
			fmt.Print("________________________________\n")
		}
		fmt.Print("Video URL:\n>> ")

		var videoURL string
		fmt.Scan(&videoURL)

		fmt.Print("\nChoose format:\n(1) • MP4\n(2) • MP3\n>> ")
		var format string
		fmt.Scan(&format)
		if format == "1" {
			result := Download(videoURL, ".mp4")
			if result == 1 {
				fmt.Print("\n* Download complete *\n~It is now safe to open the file\n\n")
			} else {
				fmt.Print("\n\nx-x Error during download, please check your URL and try again x-x\n\n")
			}
		} else {
			result := Download(videoURL, ".mp3")
			if result == 1 {
				fmt.Print("\n* Download complete *\n~It is now safe to open the file\n\n")
			} else {
				fmt.Print("\n\nx-x Error during download, please check your URL and try again x-x\n\n")
			}
		}
	}
}
