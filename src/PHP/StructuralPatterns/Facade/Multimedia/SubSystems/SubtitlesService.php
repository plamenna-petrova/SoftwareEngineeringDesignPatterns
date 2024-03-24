<?php

namespace StructuralPatterns\Facade\Multimedia\SubSystems;

class SubtitlesService {
    public function displaySubtitle($subtitlesLanguage): void
    {
        echo "Displaying subtitle: $subtitlesLanguage\n";
    }
}