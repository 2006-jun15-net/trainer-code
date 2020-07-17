"strict mode";

console.log("Hello world");

// JavaScript
// not truly OO language
//   "object-based"
// has a lot of support for functional programming

// weakly/loosely typed
// in JS, variables do not have a type
//   values do have types, but any variable can contain any type
//   objects in JS can have properties on them added or removed at runtime

// JS is interpreted, not compiled
//   individual JS runtimes might internally compile it to something else
//   but there is logically no "compile-time" part.
//   JS is just executed as it is read by the browser/runtime.

// JS historically
//   meant for the browser
//   there's also server-side javascript running in environments
//   detached from a browser/webpage, especially Node.js.

// versions of JavaScript:
// netscape: JavaScript, IE: JScript
// standardized as ECMAScript (ES for short)

// pre-ES5: some weird legacy behavior
// ES5: added strict mode, opt-in to disabling legacy behavior
//   the baseline for 99.9% of current browser usage
// ES2015 aka ES6: added LOTS of things, including classes (92% adoption)
// yearly releases: we're up to ES2020

// -------------------

// data types in JS

//   number
//   same data type for whole numbers and fractional
//   (basically a double-precision IEEE floating-point number)
let x = 5;
// x = 4.5;
x = 1 / 0; // Infinity
x = Infinity;
x = 5 / 'asdf'; // NaN (not a number - but it is a number)
x = NaN + 3;

//   boolean
x = (x == NaN); // NaN always compares false, isNaN function for this instead
x = true;
x = false;
x = true || false;
x = 4 < 5;
x = isNaN(NaN);

//   string
x = 'a"sd"f';
x = "a'sd'f";
x = `my templated ${typeof x}`; // an ES6 feature

// null
//  a data type with one possible value
x = null;
x = x == null; // true

// undefined
//  a data type with one possible value
x = undefined;
let y;
console.log(y); // undefined
// it's also the return value of functions that don't return anything;
//   JS doesn't have "void return"

// object
x = {}; // object literal
x = console; // object
// debugger;
x = { name: 'abc' };
x.id = 1;
delete x.name;
// objects have properties
//   ("properties" in JS are like fields in C# (but you can create them/delete them))

x = [1, 2, 5, 'adsf', undefined]; // object
// arrays have methods

// function expression way to define a function
x = function () {
    return 3;
};
console.log(x());
// function statement way to define a function
function add(a, b) {
    // debugger; // breakpoint
    return a + b;
}
console.log(add(1, 2));
// JS has arrow functions since ES6 (aka lambda expression)
let multiply = (a, b) => a * b; // slightly different behavior to other functions
                                // when it comes to the "this" value
console.log(multiply(2, 6));

console.log(add(3)); // NaN because 3 + undefined is NaN
console.log(add(3, 3, 3)); // 6 because extra parameters are discarded

console.log(x);
console.log(typeof x); // typeof returns a string representing the type
// typeof says typeof null is object for historical reasons
// typeof says typeof function is function, but it's really object type
