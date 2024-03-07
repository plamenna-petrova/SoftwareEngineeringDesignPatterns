
const Form = require("./composites/form");
const Panel = require("./composites/panel");
const GroupBox = require("./composites/groupBox");
const TextBox = require("./leaves/textBox");
const Button = require("./leaves/button");
const RadioButton = require("./leaves/radioButton");
const CheckBox = require("./leaves/checkBox");
const Color = require("./component/color");

const mainForm = new Form("MainForm", 1200, 1000, new Color(0, 0, 0), new Color(255, 255, 255));
const contentWrapperPanel = new Panel("contentWrapperPanel", 900, 900, new Color(0, 0, 0), new Color(255, 255, 255));
const employeesCRUDOperationsGroupBox = new GroupBox("employeesCRUDOperationsGroupBox", 300, 300, new Color(0, 0, 0), new Color(255, 255, 255));
const employeeNameTextBox = new TextBox("employeeNameTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
const employeePositionRadioButton = new RadioButton("employeePositionRadioButton", 50, 20, new Color(0, 0, 0), new Color(31, 71, 136));
const employeeSalaryTextBox = new TextBox("employeeSalaryTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
const isEmployeePromotedCheckBox = new CheckBox("isEmployeePromotedCheckBox", 10, 10, new Color(0, 0, 0), new Color(31, 71, 136));
const createEmployeeButton = new Button("createEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
const editEmployeeButton = new Button("editEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
const deleteEmployeeButton = new Button("deleteEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));

employeesCRUDOperationsGroupBox.add(employeeNameTextBox);
employeesCRUDOperationsGroupBox.add(employeePositionRadioButton);
employeesCRUDOperationsGroupBox.add(employeeSalaryTextBox);
employeesCRUDOperationsGroupBox.add(isEmployeePromotedCheckBox);
employeesCRUDOperationsGroupBox.add(createEmployeeButton);
employeesCRUDOperationsGroupBox.add(editEmployeeButton);
employeesCRUDOperationsGroupBox.add(deleteEmployeeButton);

contentWrapperPanel.add(employeesCRUDOperationsGroupBox);
mainForm.add(contentWrapperPanel);

console.log(mainForm.getHierarchicalLevel(1));