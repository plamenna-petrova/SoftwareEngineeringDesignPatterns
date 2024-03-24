<?php

namespace StructuralPatterns\Facade\Multimedia\Facade;

use StructuralPatterns\Facade\Multimedia\SubSystems\AudioPlayer;
use StructuralPatterns\Facade\Multimedia\SubSystems\Display;
use StructuralPatterns\Facade\Multimedia\SubSystems\StreamingService;
use StructuralPatterns\Facade\Multimedia\SubSystems\SubtitlesService;
use StructuralPatterns\Facade\Multimedia\SubSystems\VideoPlayer;

class MultimediaFacade {
    private VideoPlayer $videoPlayer;
    private AudioPlayer $audioPlayer;
    private Display $display;
    private SubtitlesService $subtitleService;
    private StreamingService $streamingService;

    public function __construct() {
        $this->videoPlayer = new VideoPlayer();
        $this->audioPlayer = new AudioPlayer();
        $this->display = new Display();
        $this->subtitleService = new SubtitlesService();
        $this->streamingService = new StreamingService();
    }

    public function watchMovie($movie, $audioTrack, $subtitlesLanguage): void
    {
        $this->streamingService->streamContent($movie);
        $this->videoPlayer->playVideo($movie);
        $this->audioPlayer->playAudio($audioTrack);
        $this->subtitleService->displaySubtitle($subtitlesLanguage);
        $this->display->show("Enjoy the movie on the big screen!");
    }

    public function listenToMusic($song): void
    {
        $this->streamingService->streamContent($song);
        $this->audioPlayer->playAudio($song);
        $this->display->show("Feel the music with visualizations on the display.");
    }
}