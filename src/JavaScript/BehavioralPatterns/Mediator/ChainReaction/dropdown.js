
const Participant = require("./participant");

class Dropdown extends Participant {
    constructor(mediator) {
        super(mediator);

        this.dropdownItems = {
            "Auto": false,
            "Manual": false
        };
    }

    get selectedItem() {
        return Object.keys(this.dropdownItems).find(key => this.dropdownItems[key]);
    }

    selectValue(key) {
        const selectedDropdownItemKey = Object.keys(this.dropdownItems).find(key => this.dropdownItems[key]);

        if (selectedDropdownItemKey !== undefined) {
            this.dropdownItems[selectedDropdownItemKey] = false;
        }

        this.dropdownItems[key] = true;
        console.log("DropDown value changed to: " + key);
        this.mediator.onStateChanged(this);
    }
}

module.exports = Dropdown;