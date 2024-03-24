<?php

namespace StructuralPatterns\Facade\Multimedia\SubSystems;

class VideoPlayer {
    public function playVideo($video): void
    {
        echo "Playing video: $video\n";
    }
}