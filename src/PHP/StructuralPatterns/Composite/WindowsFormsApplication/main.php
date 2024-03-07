<?php

use StructuralPatterns\Composite\WindowsFormsApplication\Component\Color;
use StructuralPatterns\Composite\WindowsFormsApplication\Composites\Form;
use StructuralPatterns\Composite\WindowsFormsApplication\Composites\GroupBox;
use StructuralPatterns\Composite\WindowsFormsApplication\Composites\Panel;
use StructuralPatterns\Composite\WindowsFormsApplication\Leaves\Button;
use StructuralPatterns\Composite\WindowsFormsApplication\Leaves\CheckBox;
use StructuralPatterns\Composite\WindowsFormsApplication\Leaves\RadioButton;
use StructuralPatterns\Composite\WindowsFormsApplication\Leaves\TextBox;

require_once 'vendor/autoload.php';

$mainForm = new Form("MainForm", 1200, 1000, new Color(0, 0, 0), new Color(255, 255, 255));

$contentWrapperPanel = new Panel("contentWrapperPanel", 900, 900, new Color(0, 0, 0), new Color(255, 255, 255));

$employeesCRUDOperationsGroupBox = new GroupBox("employeesCRUDOperationsGroupBox", 300, 300, new Color(0, 0, 0), new Color(255, 255, 255));

$employeeNameTextBox = new TextBox("employeeNameTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
$employeePositionRadioButton = new RadioButton("employeePositionRadioButton", 50, 20, new Color(0, 0, 0), new Color(31, 71, 136));
$employeeSalaryTextBox = new TextBox("employeeSalaryTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
$isEmployeePromotedCheckBox = new CheckBox("isEmployeePromotedCheckBox", 10, 10, new Color(0, 0, 0), new Color(31, 71, 136));
$createEmployeeButton = new Button("createEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
$editEmployeeButton = new Button("editEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
$deleteEmployeeButton = new Button("deleteEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));

$employeesCRUDOperationsGroupBox->add($employeeNameTextBox);
$employeesCRUDOperationsGroupBox->add($employeePositionRadioButton);
$employeesCRUDOperationsGroupBox->add($employeeSalaryTextBox);
$employeesCRUDOperationsGroupBox->add($isEmployeePromotedCheckBox);
$employeesCRUDOperationsGroupBox->add($createEmployeeButton);
$employeesCRUDOperationsGroupBox->add($editEmployeeButton);
$employeesCRUDOperationsGroupBox->add($deleteEmployeeButton);

$contentWrapperPanel->add($employeesCRUDOperationsGroupBox);

$mainForm->add($contentWrapperPanel);

echo $mainForm->getHierarchicalLevel(1);