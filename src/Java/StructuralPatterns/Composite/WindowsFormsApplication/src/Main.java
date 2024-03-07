import Component.Control;
import Composites.Form;
import Composites.GroupBox;
import Composites.Panel;
import Leaves.Button;
import Leaves.CheckBox;
import Leaves.RadioButton;
import Leaves.TextBox;

import java.awt.Color;

public class Main {
    public static void main(String[] args) {
        Control mainForm = new Form("MainForm", 1200, 1000, new Color(0, 0, 0), new Color(255, 255, 255));

        Control contentWrapperPanel = new Panel("contentWrapperPanel", 900, 900, new Color(0, 0, 0), new Color(255, 255, 255));

        Control employeesCRUDOperationsGroupBox = new GroupBox("employeesCRUDOperationsGroupBox", 300, 300, new Color(0, 0, 0), new Color(255, 255, 255));

        Control employeeNameTextBox = new TextBox("employeeNameTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
        Control employeePositionRadioButton = new RadioButton("employeePositionRadioButton", 50, 20, new Color(0, 0, 0), new Color(31, 71, 136));
        Control employeeSalaryTextBox = new TextBox("employeeSalaryTextBox", 50, 20, new Color(0, 0, 0), new Color(255, 255, 255));
        Control isEmployeePromotedCheckBox = new CheckBox("isEmployeePromotedCheckBox", 10, 10, new Color(0, 0, 0), new Color(31, 71, 136));
        Control createEmployeeButton = new Button("createEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
        Control editEmployeeButton = new Button("editEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));
        Control deleteEmployeeButton = new Button("deleteEmployeeButton", 32, 32, new Color(255, 255, 255), new Color(31, 71, 136));

        employeesCRUDOperationsGroupBox.getControls().add(employeeNameTextBox);
        employeesCRUDOperationsGroupBox.getControls().add(employeePositionRadioButton);
        employeesCRUDOperationsGroupBox.getControls().add(employeeSalaryTextBox);
        employeesCRUDOperationsGroupBox.getControls().add(isEmployeePromotedCheckBox);
        employeesCRUDOperationsGroupBox.getControls().add(createEmployeeButton);
        employeesCRUDOperationsGroupBox.getControls().add(editEmployeeButton);
        employeesCRUDOperationsGroupBox.getControls().add(deleteEmployeeButton);

        contentWrapperPanel.getControls().add(employeesCRUDOperationsGroupBox);

        mainForm.getControls().add(contentWrapperPanel);

        System.out.println(mainForm.getHierarchicalLevel(1));
    }
}