'use strict';

// JSON=JavaScript Object Notation
let nick = {
    name: 'Nick'
};

// nick.sayName = function () {
//     // console.log('Nick');
//     // console.log(nick.name);
//     console.log(this.name);
// };
nick.sayName = () => {
    // console.log('Nick');
    // console.log(nick.name);
    console.log(this.name);
};
// "this" behaves differently in arrow functions
// regular functions get it from whatever was to the left of
//      the "." when the function was actually called.
// arrow functions use whatever it was where the arrow function was defined.
// in practice: this means arrow functions are not good as "methods"
//      but they are good for stuff similar to LINQ in C#.


// out here, "this" is the global window object
// technically, "global scope" stuff is really just properties
// of a special global object.
console.log(this.name);

let oldNick = nick;
nick = { name: 'Mark' };

console.log(nick);
console.log(oldNick);
oldNick.sayName();

// "this" in JS inside a function refers to whatever was to the left of
//   the "." when the function was actually called.
let theFunction = oldNick.sayName;

// theFunction(); // "this" is undefined here, because there was nothing to the left of .

let group = {
    title: "Our Group",
    students: ["John", "Pete", "Alice"],

    showList() { // ES6 added "method syntax" - another way to define a function (on an object)
        // this.students.forEach(function (student) {
        //   // Error: Cannot read property 'title' of undefined
        //     console.log(this.title + ": " + student);
        // });
        this.students.forEach((student) => {
            // Error: Cannot read property 'title' of undefined
            console.log(this.title + ": " + student);
        });
        // (for..of, new in ES6)
        for (let student of this.students) { // in C# it's foreach
            // Error: Cannot read property 'title' of undefined
            console.log(this.title + ": " + student);
        }
        // there's also a for..in loop, which is not usually useful,
        // bceause it loops through all the properties of an object
    },
};

group.showList();

// ----------

// pre-ES6:

// there are no classes, but there are constructors.
// any function can be used as a constructor if you put "new" before it when you call it.
//   the behavior of "new" is basically: create a new empty object, and provide it
//   as "this" to the function.

// by convention, constructors are named in TitleCase.
function Person(name, location) {
    if (typeof name !== 'string' || name.length === 0) {
        // could also throw just a string
        throw new Error('invalid name');
    }
    this.name = name;

    this.location = location;

    this.sayName = function () {
        console.log(this.name);
    };
}

let mark = new Person('Mark', 'TX');
mark.sayName();
console.log(mark.location);

// another way in pre-ES6 to give objects similar behavior
// is using prototypal inheritance
// JS does not have class-based inheritance
let nick2 = { name: 'nick' };
nick2.__proto__ = mark;

// nick2 inherits mark's data and behavior, but anything nick2 defines by himself
// overrides what mark defines.
nick2.sayName();

// this works because of how JS does property access (not property assignment):
//     (property assignment always modifies the actual object, never any prototype)
// if the accessed property is undefined on the object, JS will recursively look
//    for it on the object's prototype, then that object's prototype, until there are no more.

console.log(nick2);

function Student(name, location, grade) {
    this.__proto__ = new Person(name, location);

    this.grade = grade;
}

let mohamed = new Student('Mohamed', 'USA', 'D');

// -----------

// ES6 adds classes (including class-based inheritance)
//  as syntactic sugar over prototypal inheritance


class Guy {
    constructor(name, location) {
        if (typeof name !== 'string' || name.length === 0) {
            // could also throw just a string
            throw new Error('invalid name');
        }
        this.name = name;

        this.location = location;
    }

    sayName() {
        console.log(this.name);
    };
}

class SchoolGuy extends Guy {
    constructor(name, location, grade) {
        super(name, location);

        this.grade = grade;
    }
}


let fred = new Guy("Fred", "TX");
fred.sayName();
console.log(fred.location);

let jacob = new SchoolGuy('Jacob', 'FL', 'B');
console.log(jacob);

// the common denominator of browsers drives what companies can put in their JS
// that they actually send to the browsers

// in order to use new JS features, we have transpilers
//    transpilation is compilation to a language with a similar level of abstraction
// there are transpilers like Babel which can transpile new JS into old JS

// half of the work of transpiling to old JS is converting new syntax into old syntax
//  e.g. classes, let/var
// the other half is new functions on built-in objects like arrays, strings, etc.
//  for that we use "polyfills" which means, an extra js file that manually implements
//  those functions and assigns them where the browser would put them if it supported new JS

// there are languages that have been written just to transpile to JavaScript
// - TypeScript, CoffeeScript, Elm, Flow, lots
