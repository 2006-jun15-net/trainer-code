// typescript adds "type annotations" to javascript
// it will check that uyou've been using variables properly
// according to their types, but only
// at the stage when typescript is compiled into javascript.

// from then on, it's just javascript, variables have no types.

function addMessage(message: string): void {
    document.body.innerHTML = message;
}

document.addEventListener("DOMContentLoaded", () => {
    addMessage("Hello from TypeScript");
    // addMessage(1234); // error
});
