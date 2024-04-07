using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainReaction
{
    public class Dropdown : Participant
    {
        private readonly Dictionary<string, bool> dropdownItems;

        public Dropdown(Mediator mediator) : base(mediator)
        {
            dropdownItems = new Dictionary<string, bool>()
            {
                { "Auto", false },
                { "Manual", false }
            };
        }

        public string SelectedItem => dropdownItems.FirstOrDefault(x => x.Value).Key;

        public void SelectValue(string key)
        {
            var selectedDropdownItemKey = dropdownItems.FirstOrDefault(x => x.Value).Key;

            if (selectedDropdownItemKey != null)
            {
                dropdownItems[selectedDropdownItemKey] = false;
            }

            dropdownItems[key] = true;
            Console.WriteLine("DropDown value changed to: " + key);
            Mediator.OnStateChanged(this);
        }
    }
}
