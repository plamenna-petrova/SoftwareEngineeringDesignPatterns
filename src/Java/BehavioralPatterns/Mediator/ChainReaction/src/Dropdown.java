import java.util.HashMap;
import java.util.Map;

public class Dropdown extends Participant {
    private final Map<String, Boolean> dropdownItems;

    public Dropdown(Mediator mediator) {
        super(mediator);
        dropdownItems = new HashMap<>();
        dropdownItems.put("Auto", false);
        dropdownItems.put("Manual", false);
    }

    public String getSelectedItem() {
        for (Map.Entry<String, Boolean> entry : dropdownItems.entrySet()) {
            if (entry.getValue()) {
                return entry.getKey();
            }
        }
        return null;
    }

    public void selectValue(String key) {
        String selectedDropdownItemKey = getSelectedItem();
        if (selectedDropdownItemKey != null) {
            dropdownItems.put(selectedDropdownItemKey, false);
        }
        dropdownItems.put(key, true);
        System.out.println("DropDown value changed to: " + key);
        getMediator().onStateChanged(this);
    }
}
