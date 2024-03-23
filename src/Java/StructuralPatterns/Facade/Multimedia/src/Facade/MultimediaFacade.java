package Facade;

import SubSystems.*;

public class MultimediaFacade {
    private final VideoPlayer videoPlayer = new VideoPlayer();
    private final AudioPlayer audioPlayer = new AudioPlayer();
    private final Display display = new Display();
    private final SubtitlesService subtitlesService = new SubtitlesService();
    private final StreamingService streamingService = new StreamingService();

    public void watchMovie(String movie, String audioTrack, String subtitlesLanguage) {
        streamingService.streamContent(movie);
        videoPlayer.playVideo(movie);
        audioPlayer.playAudio(audioTrack);
        subtitlesService.displaySubtitle(subtitlesLanguage);
        display.show("Enjoy the movie on the big screen!");
    }

    public void listenToMusic(String song) {
        streamingService.streamContent(song);
        audioPlayer.playAudio(song);
        display.show("Feel the music with visualizations on the display.");
    }
}