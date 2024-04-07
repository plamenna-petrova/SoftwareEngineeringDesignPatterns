<?php

use BehavioralPatterns\Mediator\ChainReaction\Mediator;

require_once 'vendor/autoload.php';

executeChainReactionExample();

function executeChainReactionExample(): void
{
    $mediator = new Mediator();
    $dropdown = $mediator->getDropdown();

    $dropdown->selectValue("Manual");
    $dropdown->selectValue("Auto");
}