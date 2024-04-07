<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class Mediator {
    private Button $button;
    private Dropdown $dropdown;
    private TextBox $textBox;
    private FontEditor $fontEditor;

    public function __construct() {
        $this->dropdown = new Dropdown($this);
        $this->button = new Button($this);
        $this->textBox = new TextBox($this);
        $this->fontEditor = new FontEditor($this);
    }

    /**
     * @return Button
     */
    public function getButton(): Button
    {
        return $this->button;
    }

    /**
     * @return Dropdown
     */
    public function getDropdown(): Dropdown
    {
        return $this->dropdown;
    }

    /**
     * @return TextBox
     */
    public function getTextBox(): TextBox
    {
        return $this->textBox;
    }

    /**
     * @return FontEditor
     */
    public function getFontEditor(): FontEditor
    {
        return $this->fontEditor;
    }

    public function onStateChanged(Participant $participant): void
    {
        if ($participant === $this->textBox && $this->textBox->isEnabled()) {
            $this->fontEditor->enable();
            return;
        }

        if ($participant === $this->textBox && !$this->textBox->isEnabled()) {
            $this->fontEditor->disable();
            return;
        }

        if ($participant === $this->dropdown && $this->dropdown->getSelectedItem() == "Manual") {
            $this->button->enable();
            $this->textBox->enable();
            return;
        }

        if ($participant === $this->dropdown && $this->dropdown->getSelectedItem() == "Auto") {
            $this->button->disable();
            $this->textBox->disable();
        }
    }
}