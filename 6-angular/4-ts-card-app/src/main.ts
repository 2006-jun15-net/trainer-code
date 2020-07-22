// single-page application
// it'll still just have one view pretty much, but

import Page from "./page";
import CardService from "./card-service";

const cardService = new CardService();

document.addEventListener('DOMContentLoaded', () => {
    const page = new Page(cardService);
    page.run();
});
