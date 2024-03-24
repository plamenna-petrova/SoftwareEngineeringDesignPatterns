
const VideoPlayer = require("../SubSystems/videoPlayer");
const AudioPlayer = require("../SubSystems/audioPlayer");
const Display = require("../SubSystems/display");
const SubtitlesService = require("../SubSystems/subtitlesService");
const StreamingService = require("../SubSystems/streamingService");

class MultimediaFacade {
    constructor() {
        this.videoPlayer = new VideoPlayer();
        this.audioPlayer = new AudioPlayer();
        this.display = new Display();
        this.subtitleService = new SubtitlesService();
        this.streamingService = new StreamingService();
    }

    watchMovie(movie, audioTrack, subtitlesLanguage) {
        this.streamingService.streamContent(movie);
        this.videoPlayer.playVideo(movie);
        this.audioPlayer.playAudio(audioTrack);
        this.subtitleService.displaySubtitle(subtitlesLanguage);
        this.display.show("Enjoy the movie on the big screen!");
    }

    listenToMusic(song) {
        this.streamingService.streamContent(song);
        this.audioPlayer.playAudio(song);
        this.display.show("Feel the music with visualizations on the display.");
    }
}

module.exports = MultimediaFacade;