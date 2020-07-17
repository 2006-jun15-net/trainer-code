'use strict';

// in javascript we do "callbacks" a lot
// a callback function is a function (A) passed as a parameter to another function (B),
// with the intention that, in the course of B executing, it will (maybe) "call back" to your function A.

// forEach is "B", and x => console.log(x) is my A
[1, 2, 3].forEach(x => console.log(x));

//                                             (milliseconds)
setTimeout(() => console.log('runs second'), 1000); // one second timer
console.log('runs first');

let slowAdderService = {
    add(a, b, onSuccess, onError) {
        // pretend to do a long-running operation like connecting to a server
        setTimeout(() => {
            if (isNaN(a + b)) {
                onError();
            } else {
                onSuccess(a + b);
            }
        }, 1000);
    }
}

slowAdderService.add(5, 5, result => console.log(result), () => console.log('oops'));
slowAdderService.add(5, NaN, result => console.log(result), () => console.log('oops'));

// we'll see next week, ES6 added an object called Promise, that can simplify
// callback-type code
// and ES8/ES2019 added async/await as syntactic sugar for Promises

// function newCounter() {
//     let count = 0;
//     return () => ++count;
// }

let count = 5;

function newCounter() {
    let count = 0;

    return function () {
        count += 1; // JS could have made it so this line sees the global count rather than
                    // the one in the newCounter function. why? because by the time this
                    // code executes, the local variables of newCounter should be long gone
        return count;
    }
}

// JS functions have a behavior called closure.
//   a function "closes over" all the variables it references.
//   so the returned function will keep the count variable alive.

// often we call functions that do this "closures" as well.

// in JS, obj.name and obj["name"] are the same thing.

// function newCounter() {
//     slowAdderService.data = new Map();
//     for (let i = 0; ; i++) {
//         data[i] = 0;
//     }
// }

let counter1 = newCounter();
console.log(counter1()); // 1
console.log(counter1()); // 2
console.log(counter1()); // 3

let counter2 = newCounter();
console.log(counter2()); // 1
console.log(counter2()); // 2

console.log(counter1()); // 4


// ES6 added modules, which let us separate the global scope of each file from each other file
// but we didnt use to have that.
// when we want to run some logic and use a "temporary global scope",
// we have a technique called IIFE, immediately-invoked function expression.

(function () {
    let sharedVariable = 'adsf';
    count++;

    let localCopy = count;
    localCopy++;

    console.log(sharedVariable);

    function localFunction() {

    }
})();

// we can do some cool stuff by combining closure and IIFE

let library = (function () {
    let privateData = 1;

    let privateFunction = function (increment) {
        return privateData += increment;
    }

    return {
        publicData: 0,

        publicFunction(multiplier) {
            this.publicData += privateFunction(privateData) * multiplier;
            console.log(this.publicData);
        }
    };
})();

library.publicFunction(2);
library.publicFunction(5);
library.publicFunction(0.33);

console.log(library);

// most of the new stuff in ES6
// http://es6-features.org/

// block scope (let, const)
// arrow functions
//     this
// method syntax for function properties
// default parameters
// string interpolation `-- ${x} --`
// classes with constructors, inheritance
// symbol type
// various useful built-in functions like string searching
// Promises
// es6 modules (import, export)
// Set and Map data structures
// for of
// getters/setters
// internationalization features (number/date/currency format)
// spread, destructuring
