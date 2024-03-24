<?php

namespace StructuralPatterns\Facade\Multimedia\SubSystems;

class StreamingService {
    public function streamContent($content): void
    {
        echo "Streaming content: $content\n";
    }
}