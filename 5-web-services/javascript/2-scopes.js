'use strict';

// in old JS, variables have two possible scopes
// - global/document
//     in scope everywhere after the line it's assigned (including in other script files)
// console.log(x);

// - function scope
//     in scope anywhere in the function in which it was declared.
//     (including before it was declared and outside the block ( { ... } ) it was declared)
// before ES5, we had two ways to define a variable:
// x = 5; // global (commented out for strict mode)
var y = 5; // global

// console.log(x);
console.log(y);

function calculate(q) {
    // var temporaryValue = 1234;
    // temporaryVlaue = 1234;
    console.log(a); // even in strict mode, this is undefined -
        // because "var" variables effectively have their declarations
        // "hoisted" to the top of the function

    // z = 6; // global - calling this function has a side effect of altering something in global scope
    // (prevented by strict mode)
    var a = 7; // function scope
}

calculate(3);
// console.log(z); // ReferenceError
// console.log(a); // ReferenceError

// even in pre-ES5 JS, accessing an undeclared variable throws a ReferenceError
//  we can use try-catch with errors in JS (use try catch with anything)

// ES5 added strict mode
// any function or file with the string 'use strict' as the first expression
// opts in to better behavior:
//  - not allowed to assign to variable without explicitly declaring it
//      (therefore, not allowed to assign to global scope from inside a function)
//  - it turns some silent errors into thrown errors
//  - fixed old inconsistent behavior

// ES6 added block scope
//   via new ways to declare variables besides var: "let" and "const"

function scopes(condition) {
    if (condition) {
        let blockScope = 5; // block scope
        var functionScope = 5; // function scope
        const value = 8; // block scope
        // value = 3; // TypeError, can't reassign const.
    }
    console.log(functionScope); // works fine
    console.log(blockScope); // ReferenceError (out of scope)
}

// scopes(true);
