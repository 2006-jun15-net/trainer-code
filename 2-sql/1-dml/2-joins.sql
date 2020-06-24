-- cross join, each row with each row in the other table
-- 360 degree performance review?
SELECT *
FROM Employee AS e1
	CROSS JOIN Employee AS e2;

-- if it's not a cross join, you join ON as condition filtering the rows.

-- display every track name with its genre
SELECT Track.Name, Genre.Name AS Genre
FROM Track LEFT JOIN Genre ON Track.GenreId = Genre.GenreId;

-- in SQL, all comparisons with NULL are false. so we use IS NULL and IS NOT NULL.
SELECT * FROM Track WHERE GenreId IS NULL;

-- what if there's a track with no assigned genre

SELECT * FROM Track;
SELECT * FROM Genre;

----------------------

-- all rock songs, shown in the format "artist - song"

SELECT COALESCE(ar.Name, 'N/A') + ' - ' + t.Name
FROM Track AS t
	LEFT JOIN Genre AS g ON t.GenreId = g.GenreId
	LEFT JOIN Album AS al ON t.AlbumId = al.AlbumId
	LEFT JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
WHERE g.Name = 'rock';

-- COALESCE function will provide an alternate value in case of NULL