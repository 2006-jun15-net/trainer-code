import Message from "./message";
import MessageFormatter from "./message-formatter";
import FancyMessageFormatter from "./fancy-message-formatter";

// typescript adds "type annotations" to javascript
// it will check that you've been using variables properly
// according to their types, but only
// at the stage when typescript is compiled into javascript.

// from then on, it's just javascript, variables have no types.

// (inferred type: array of number-or-null)
let x = [0, 1, null];

function addMessage(message: Message, formatter: MessageFormatter) {
  let result = formatter.format(message);
  document.body.innerHTML = result;
  return result;
}

let myMessage: Message = {
  text: "Hello",
  author: "TypeScript",
};

document.addEventListener("DOMContentLoaded", () => {
  let formatter = new FancyMessageFormatter();
  addMessage(myMessage, formatter);
  // addMessage(1234); // error
});
