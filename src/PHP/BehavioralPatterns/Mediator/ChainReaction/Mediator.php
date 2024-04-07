<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class Mediator {
    private Button $button;
    private $dropdown;
    private $textBox;
    private $fontEditor;

    public function __construct() {
        $this->dropdown = new Dropdown($this);
        $this->button = new Button($this);
        $this->textBox = new TextBox($this);
        $this->fontEditor = new FontEditor($this);
    }

    public function onStateChanged(Participant $participant) {
        if ($participant == $this->textBox && $this->textBox->isEnabled()) {
            $this->fontEditor->enable();
            return;
        }

        if ($participant == $this->textBox && !$this->textBox->isEnabled()) {
            $this->fontEditor->disable();
            return;
        }

        if ($participant == $this->dropdown && $this->dropdown->getSelectedItem() == "Manual") {
            $this->button->enable();
            $this->textBox->enable();
            return;
        }

        if ($participant == $this->dropdown && $this->dropdown->getSelectedItem() == "Auto") {
            $this->button->disable();
            $this->textBox->disable();
        }
    }
}