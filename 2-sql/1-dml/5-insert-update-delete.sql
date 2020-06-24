-- rest of DML besides SELECT is for adding/changing/removing rows

-- INSERT

SELECT * FROM Genre;

INSERT INTO Genre VALUES (100, 'Miscellaneous');

INSERT INTO Genre (GenreId) VALUES (101);

INSERT INTO Genre (GenreId, Name) VALUES (102, 'Misc 2');

SELECT * FROM Genre WHERE GenreId >= 100;

INSERT INTO Genre (GenreId, Name) VALUES
	(103, 'Misc 3'),
	(104, 'Misc 4');

INSERT INTO Genre (GenreId, Name)
	SELECT GenreId + 10, Name + '!'
	FROM Genre
	WHERE GenreId = 104;

-- INSERT can also do things like read CSV files etc

-- UPDATE

-- without a WHERE, would modify every row
UPDATE Genre
SET Name = 'Misc 1'  -- , otherthing = value
WHERE GenreId = 101;

-- without a WHERE, would delete every row (one by one)
DELETE FROM Genre
WHERE GenreId >= 100;

-- this command deletes all rows all at once
--TRUNCATE TABLE Genre;

-- exercise
-- delete robert walter
DELETE FROM InvoiceLine WHERE InvoiceId IN (
    SELECT InvoiceId FROM Invoice WHERE CustomerId = (
        SELECT CustomerId FROM Customer
        WHERE FirstName = 'Robert' AND LastName = 'Walter'
    )
);
DELETE FROM Invoice WHERE CustomerId = (
    SELECT CustomerId FROM Customer
    WHERE FirstName = 'Robert' AND LastName = 'Walter'
);
DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter';