public class Mediator {
    private Button button;
    private Dropdown dropdown;
    private TextBox textBox;
    private FontEditor fontEditor;

    public Mediator() {
        dropdown = new Dropdown(this);
        button = new Button(this);
        textBox = new TextBox(this);
        fontEditor = new FontEditor(this);
    }

    public void onStateChanged(Participant participant) {
        if (participant == textBox && textBox.isEnabled()) {
            fontEditor.enable();
            return;
        }

        if (participant == textBox && !textBox.isEnabled()) {
            fontEditor.disable();
            return;
        }

        if (participant == dropdown && dropdown.getSelectedItem().equals("Manual")) {
            button.enable();
            textBox.enable();
            return;
        }

        if (participant == dropdown && dropdown.getSelectedItem().equals("Auto")) {
            button.disable();
            textBox.disable();
        }
    }

    public void setButton(Button button) {
        this.button = button;
    }

    public void setDropdown(Dropdown dropdown) {
        this.dropdown = dropdown;
    }

    public void setTextBox(TextBox textBox) {
        this.textBox = textBox;
    }

    public void setFontEditor(FontEditor fontEditor) {
        this.fontEditor = fontEditor;
    }

    public Button getButton() {
        return button;
    }

    public Dropdown getDropdown() {
        return dropdown;
    }

    public TextBox getTextBox() {
        return textBox;
    }

    public FontEditor getFontEditor() {
        return fontEditor;
    }
}
