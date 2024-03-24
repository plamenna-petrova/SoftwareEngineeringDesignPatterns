<?php

namespace StructuralPatterns\Facade\Multimedia\SubSystems;

class AudioPlayer {
    public function playAudio($audio): void
    {
        echo "Playing audio: $audio\n";
    }
}