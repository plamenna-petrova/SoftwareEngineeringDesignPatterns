<?php

use StructuralPatterns\Facade\Multimedia\Facade\MultimediaFacade;

require_once 'vendor/autoload.php';

$multimediaFacade = new MultimediaFacade();

echo "Start watching movie\n";
$multimediaFacade->watchMovie("Inception", "DTS", "English");
echo "\n";

echo "Start listening music\n";
$multimediaFacade->listenToMusic("Stairway to Heaven");