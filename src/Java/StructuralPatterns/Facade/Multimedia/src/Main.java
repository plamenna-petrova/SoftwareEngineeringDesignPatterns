import Facade.MultimediaFacade;

public class Main {
    public static void main(String[] args) {
        MultimediaFacade multimediaFacade = new MultimediaFacade();

        System.out.println("Start watching movie");
        multimediaFacade.watchMovie("Inception", "DTS", "English");

        System.out.println();

        System.out.println("Start listening music");
        multimediaFacade.listenToMusic("Stairway to Heaven");
    }
}