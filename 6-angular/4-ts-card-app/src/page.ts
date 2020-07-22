import CardService from "./card-service";
import Card from "./card";

export default class Page {
    cardContainer: HTMLDivElement;
    newDeck: HTMLButtonElement;
    drawCard: HTMLButtonElement;
    cardService: CardService;

    constructor(cardService: CardService) {
        this.cardService = cardService;

        this.cardContainer = document.getElementById('card-container') as HTMLDivElement;
        this.newDeck = document.getElementById('new-deck') as HTMLButtonElement;
        this.drawCard = document.getElementById('draw-card') as HTMLButtonElement;
    }

    run() {
        // set up new deck action
        this.newDeck.addEventListener('click', () => {
            // empty the card container of any existing cards
            while (this.cardContainer?.firstElementChild) {
                this.cardContainer?.firstElementChild.remove();
            }

            this.cardService.newDeck().catch((error: Error) => {
                // TODO: display error
            });
        });

        // set up draw card action
        this.drawCard.addEventListener('click', () => {
            this.cardService.drawCard().then(card => {
                // add the card to the card container
                const image = document.createElement('img');
                image.src = card.image;
                image.alt = card.code;
                this.cardContainer?.appendChild(image);
            }, (error: Error) => {
                // TODO: display error
            });
        });
    }
}
