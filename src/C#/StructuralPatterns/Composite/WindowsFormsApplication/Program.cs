using System;
using System.Drawing;
using WindowsFormsApplication.Component;
using WindowsFormsApplication.Composites;
using WindowsFormsApplication.Leaves;

namespace WindowsFormsApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Control mainForm = new Form("MainForm", 1200, 1000, Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));

            Control contentWrapperPanel = new Panel("contentWrapperPanel", 900, 900, Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));

            Control employeesCRUDOperationsGroupBox = new GroupBox("employeesCRUDOperationsGroupBox", 300, 300, new Color(), new Color());

            Control employeeNameTextBox = new TextBox("employeeNameTextBox", 50, 20, Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));
            Control employeePositionRadioButton = new RadioButton("employeePositionRadioButton", 50, 20, Color.FromArgb(0, 0, 0), Color.FromArgb(31, 71, 136));
            Control employeeSalaryTextBox = new TextBox("employeeSalaryTextBox", 50, 20, Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));
            Control isEmployeePromotedCheckBox = new CheckBox("isEmployeePromotedCheckBox", 10, 10, Color.FromArgb(0, 0, 0), Color.FromArgb(31, 71, 136));
            Control createEmployeeButton = new Button("createmployeesButton", 32, 32, Color.FromArgb(255, 255, 255), Color.FromArgb(31, 71, 136));
            Control editEmployeeButton = new Button("editEmployeesButton", 32, 32, Color.FromArgb(255, 255, 255), Color.FromArgb(31, 71, 136));
            Control deleteEmployeeButton = new Button("deleteEmployeesButton", 32, 32, Color.FromArgb(255, 255, 255), Color.FromArgb(31, 71, 136));

            employeesCRUDOperationsGroupBox.Controls.Add(employeeNameTextBox);
            employeesCRUDOperationsGroupBox.Controls.Add(employeePositionRadioButton);
            employeesCRUDOperationsGroupBox.Controls.Add(employeeSalaryTextBox);
            employeesCRUDOperationsGroupBox.Controls.Add(isEmployeePromotedCheckBox);
            employeesCRUDOperationsGroupBox.Controls.Add(createEmployeeButton);
            employeesCRUDOperationsGroupBox.Controls.Add(editEmployeeButton);
            employeesCRUDOperationsGroupBox.Controls.Add(deleteEmployeeButton);

            contentWrapperPanel.Controls.Add(employeesCRUDOperationsGroupBox);

            mainForm.Controls.Add(contentWrapperPanel);

            Console.WriteLine(mainForm.GetHierarchicalLevel(1));
        }
    }
}
