
const Mediator = require("./mediator");

 const mediator = new Mediator();
 const dropdown = mediator.dropdown;

 dropdown.selectValue("Manual");
 dropdown.selectValue("Auto");