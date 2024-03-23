using Multimedia.SubSystems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multimedia.Facade
{
    public class MultimediaFacade
    {
        private readonly VideoPlayer videoPlayer = new VideoPlayer();

        private readonly AudioPlayer audioPlayer = new AudioPlayer();

        private readonly Display display = new Display();

        private readonly SubtitlesService subtitleService = new SubtitlesService();

        private readonly StreamingService streamingService = new StreamingService();

        public void WatchMovie(string movie, string audioTrack, string subtitlesLanguage)
        {
            streamingService.StreamContent(movie);
            videoPlayer.PlayVideo(movie);
            audioPlayer.PlayAudio(audioTrack);
            subtitleService.DisplaySubtitle(subtitlesLanguage);
            display.Show("Enjoy the movie on the big screen!");
        }

        public void ListenToMusic(string song)
        {
            streamingService.StreamContent(song);
            audioPlayer.PlayAudio(song);
            display.Show("Feel the music with visualizations on the display.");
        }
    }
}
