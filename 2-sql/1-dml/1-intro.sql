-- SQL
-- DML (Data Manipulation Language)
--   these operate on individual rows of tables at a time
--   SELECT (querying / read-only access)
--   INSERT
--   UPDATE
--   DELETE

-- DDL (Data Definition Language)
--   these create or modify objects in the database like tables
--   CREATE TABLE, CREATE FUNCTION, etc.
--   ALTER TABLE, ALTER VIEW, etc.
--   DROP TABLE, DROP PROCEDURE, etc.
--   TRUNCATE TABLE (remove all rows from a table)

-- DCL (Data Control Language)
--   these have to do with users, user permissions
--   database admins care about this

-------------------------

-- SELECT

-- conceptually, SELECT statement runs with these clauses in this order
-- 1. FROM: what tables should be accessed, and possibly joined with others
-- 2. WHERE: filtering rows from those tables based on a condition
-- 3. GROUP BY: grouping sets of rows into one based on having some values in common
-- 4. HAVING: another stage of filtering that can run after the aggregation of GROUP BY
-- 5. SELECT: list the columns we want in the output, and maybe transform the values
-- 6. ORDER BY: sorting the result rows

-- semicolons, not required
-- numbers like 123, text like 'abc'

SELECT 'Hello World!';

SELECT '9' + CONVERT(VARCHAR, 4 + 5);

SELECT *
FROM Employee;

SELECT FirstName, LastName
FROM Employee;

-- all employees with last name first letter of P
SELECT FirstName, LastName
FROM Employee
--WHERE SUBSTRING(LastName, 1, 1) = 'p';
--WHERE LastName >= 'p' AND LastName < 'q';
--WHERE LastName BETWEEN 'p' AND 'q'; -- not exactly right - inclusive of both ends
WHERE LastName LIKE 'p%';

-- in SQL, indexes start at 1
-- text comparison is case-insensitive by default (controlled by COLLATION)
-- the LIKE operator takes a special template string to compare with
--    _ means any one character
--    % means any characters
--    [abc] means one of a, b, or c.

-- exercise set 1 problem 5
-- How many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)

SELECT COUNT(*) AS InvoiceCount, SUM(Total) AS SalesTotal
FROM Invoice
--WHERE InvoiceDate >= '2009' AND InvoiceDate < '2010';
WHERE YEAR(InvoiceDate) = 2009; -- built-in functions to extract parts of a date

SELECT YEAR(InvoiceDate) AS InvoiceYear,
	COUNT(*) AS InvoiceCount, SUM(Total) AS SalesTotal
FROM Invoice
GROUP BY YEAR(InvoiceDate)
ORDER BY InvoiceYear DESC,  SalesTotal DESC;

-- SQL has aggregate functions
--   these are the ones which accept many values and return one
--   there are: COUNT, SUM, AVG, MIN, MAX.
-- if you use one of these in the SELECT list,
--    all rows will be reduced to one
-- but that's only if you have no GROUP BY clause...
--   if you have one of those, it will instead reduce the rows in sets
--   defined by the columns listed in the GROUP BY

-- how many customers are there?
SELECT COUNT(*) FROM Customer;
-- total number of letters in customer first names
SELECT SUM(LEN(FirstName)) FROM Customer;

-- any duplicate first names across customers
SELECT COUNT(*), FirstName
FROM Customer
GROUP BY FirstName
HAVING COUNT(*) > 1;