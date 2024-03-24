
const MultimediaFacade = require("./Facade/multimediaFacade");

const multimediaFacade = new MultimediaFacade();

console.log("Start watching movie");
multimediaFacade.watchMovie("Inception", "DTS", "English");

console.log();

console.log("Start listening music");
multimediaFacade.listenToMusic("Stairway to Heaven");