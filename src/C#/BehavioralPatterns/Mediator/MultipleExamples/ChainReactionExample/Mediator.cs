using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.ChainReactionExample
{
    public class Mediator
    {
        public Mediator()
        {
            Dropdown = new Dropdown(this);
            Button = new Button(this);
            TextBox = new TextBox(this);
            FontEditor = new FontEditor(this);
        }

        public Button Button { get; set; }

        public Dropdown Dropdown { get; set; }

        public TextBox TextBox { get; set; }

        public FontEditor FontEditor { get; set; }

        public void OnStateChanged(Participant participant)
        {
            if (participant == TextBox && TextBox.IsEnabled)
            {
                FontEditor.Enable();
                return;
            }

            if (participant == TextBox && !TextBox.IsEnabled)
            {
                FontEditor.Disable();
                return;
            }

            if (participant == Dropdown && Dropdown.SelectedItem == "Manual")
            {
                Button.Enable();
                TextBox.Enable();
                return;
            }

            if (participant == Dropdown && Dropdown.SelectedItem == "Auto")
            {
                Button.Disable();
                TextBox.Disable();
                return;
            }
        }
    }
}
