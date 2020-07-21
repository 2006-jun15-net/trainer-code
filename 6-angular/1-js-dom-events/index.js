'use strict';

//  serialization

//  JSON <====> CLR objects
//  HTML <====> DOM

// accessing the DOM typically is done via the "document" object
// (in global scope, on that global window object)

// every DOM object has a bunch of properties like
//    onclick, onload, onhover etc.

// the load event fires on an element when it and all of its children
//   are fully loaded (including images downloaded etc.)

window.onload = function () {
  const para = document.getElementById("intro-paragraph");
  console.log(para);
  para.onclick = function () {
    para.innerHTML += "!";
    console.log("this runs third (each time clicked)");
  };
  console.log("this runs second");
};

console.log("this runs first");

window.addEventListener("load", () => {
  // do it more this way to let many event handlers coexist on the same element/event type.
});

document.addEventListener("DOMContentLoaded", () => {
  // this event fires as soon as the whole DOM is created, but not necessarily
  // filled in with downloaded images etc. faster
  const addButton = document.getElementById("add-button");
  const list = document.getElementsByClassName("list")[0];

  list.addEventListener("click", event => {
    // printEventDetails(event);
    // event.target will be the specific li element i clicked on
    // event.currentTarget will be the list
    if (event.target.tagName === "li") {
      event.currentTarget.removeChild(event.target);
    }
  });

  let index = 0;

  addButton.addEventListener("click", () => {
    const newItem = document.createElement("li");
    newItem.innerHTML = (index++).toString();
    list.appendChild(newItem);

    // newItem.addEventListener("click", event => event.stopPropagation());

    // newItem.addEventListener("click", printEventDetails);
    // newItem.addEventListener("click", () => {
    //   list.removeChild(newItem);
    // });
  });

  document.body.addEventListener("click", event => {
    if (event.target.tagName === "A") {
      event.preventDefault(); // stops whatever the browser's default behavior is
    }
    // the #1 time i might do that is
    // to stop forms from submitting normally
    // if i want to process / validate the form data manually in JS
  });
});


window.addEventListener("click", printEventDetails);

function printEventDetails(event) {
  // console.log(event);
  // console.log(event.type);
  // the specific element that is targetted by the event
  console.log(event.target);
  // the element that this event listener was attached to.
  // console.log(event.currentTarget);
  // console.log("----------");
}
