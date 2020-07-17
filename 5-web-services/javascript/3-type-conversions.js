'use strict';

// JS does "implicit conversions" very freely
console.log('asdf' + 3);

console.log(3 + []); // prints the string '3'
console.log(3 + true); // prints the number 4

// there's rules for how and when all these conversions happen

// we should know the rules for conerting anything to boolean, because
//   it's common to put anything as the condition for an if statement

if (3) {
    console.log('3 is truthy');
}

// any value that converts to true in a boolean context is "truthy"
// the others are "falsy"

// these values are falsy, all others are truthy:
// - 0, -0
// - NaN
// - undefined
// - null
// - false
// - '' (empty string)
// everything else, including the string 'false', empty array, all objects, are all truthy

// ----------------

// comparisons with equals operators in JS
// double equals aka loose equality ==
//    attempt to compare value while ignoring type
// triple equals aka strict equality ===
//    compares both value and type

function checkEquality(a, b) {
    console.log(`${a} == ${b}: ${a == b}`);
    console.log(`${a} === ${b}: ${a === b}`);
}

if ([1]) {
    console.log('it\'s truthy'); // prints
}
[1] == true; //

checkEquality(3, '3');
checkEquality(false, []);
checkEquality(0, [[]]);
checkEquality(0, [[1]]);
// https://dorey.github.io/JavaScript-Equality-Table/
