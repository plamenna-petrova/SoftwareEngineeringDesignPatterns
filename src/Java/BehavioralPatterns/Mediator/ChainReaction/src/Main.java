public class Main {
    public static void main(String[] args) {
        executeChainReactionExample();
    }

    private static void executeChainReactionExample() {
        Mediator mediator = new Mediator();
        Dropdown dropdown = mediator.getDropdown();

        dropdown.selectValue("Manual");
        dropdown.selectValue("Auto");
    }
}