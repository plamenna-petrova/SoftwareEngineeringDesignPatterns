<?php

namespace StructuralPatterns\Facade\Multimedia\SubSystems;

class Display {
    public function show($content): void
    {
        echo "Displaying: $content\n";
    }
}