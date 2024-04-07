<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class Dropdown extends Participant
{
    private array $dropdownItems;

    public function __construct(Mediator $mediator)
    {
        parent::__construct($mediator);
        $this->dropdownItems = array(
            "Auto" => false,
            "Manual" => false
        );
    }

    public function getSelectedItem(): ?string
    {
        foreach ($this->dropdownItems as $key => $value) {
            if ($value) {
                return $key;
            }
        }
        return null;
    }

    public function selectValue($key): void
    {
        $selectedDropdownItemKey = $this->getSelectedItem();

        if ($selectedDropdownItemKey !== null) {
            $this->dropdownItems[$selectedDropdownItemKey] = false;
        }

        $this->dropdownItems[$key] = true;
        echo "DropDown value changed to: " . $key . PHP_EOL;
        $this->mediator->onStateChanged($this);
    }
}