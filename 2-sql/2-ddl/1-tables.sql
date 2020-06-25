-- DDL for tables

--CREATE DATABASE Chinook2

-- the whole SQL Server instance can have many databases
--    each database can have many schemas (namespaces to keep things organized)
--       each schema can have many tables etc

-- schema is a namespace for tables and similar objects outside tables
-- the default one in SQL Server is "dbo" - otherwise, you need to refer to
--    the table like "schemaname.tablename"
CREATE SCHEMA School;
GO

-- why do we often have an extra ID column introduced to the data
-- 1. it's sort of a pain to modify the primary key value (because of the FK copies of it)
-- 2. composite keys mean your foreign keys would also have to be multiple columns
-- what kinds of ID columns do we introduce?
--  1. incrementing integer starting at 1 (IDENTITY)
--  2. GUID (random really long number)
--  3. hi-lo sequence, some of the advantages of both 

CREATE TABLE School.Student (
	-- columns
	-- name, type, constraints
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(200) NULL
);

--DROP TABLE School.Course;
CREATE TABLE School.Course (
	Id INT NOT NULL,
	CourseNumber NVARCHAR(10) NOT NULL,
	SectionNumber NVARCHAR(10) NULL,
	-- constraints
	UNIQUE (CourseNumber, SectionNumber)
);

CREATE TABLE School.Enrollment (
	StudentId INT NOT NULL,
	CourseId INT NOT NULL,
	CONSTRAINT PK_Enrollment_StudentId_CourseId PRIMARY KEY (StudentId, CourseId)
);

ALTER TABLE School.Enrollment
	ADD CONSTRAINT FK_Enrollment_Student_StudentId FOREIGN KEY (StudentId)
		REFERENCES School.Student (Id) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE School.Enrollment
	ADD CONSTRAINT FK_Enrollment_Course_CourseId FOREIGN KEY (CourseId)
		REFERENCES School.Course (Id) ON DELETE CASCADE ON UPDATE CASCADE;

-- foreign keys dont do anything but throw errors when you would be violating
-- referential integrity: meaning, a reference form one thing to another
--   should point to something that exists.

-- FKs allow "cascade" behavior

-- you can create constraints after the fact on an existing table
-- with ALTER TABLE
-- this is sometimes done on purpose with the PK and especially with the FK
ALTER TABLE School.Student
	ADD CONSTRAINT PK_Student_Id PRIMARY KEY (Id);
	--            constraint name        list of columns in PK

ALTER TABLE School.Course
	ALTER COLUMN Id INT NOT NULL;

ALTER TABLE School.Course
	ADD CONSTRAINT PK_Course_Id PRIMARY KEY (Id);

-- constraints
--  IDENTITY (autoincrement an integer - does not allow manual inserts)
--  NULL (explicitly mark the default allowing of nulls in that column)
--  NOT NULL
--  PRIMARY KEY
--  FOREIGN KEY
--  UNIQUE
--  CHECK - allows checking any expression to be true for a row.
--  DEFAULT


-- when modelling data, an aspect of their relationships is
-- called multiplicity.
-- between X and Y, the multiplicity might be...
--   one-to-one - (ex. Person and PersonDetails)
--         technically impossible in SQL between two tables - can do one-to-(zero-or-one)
--             with a UNIQUE NOT NULL FOREIGN KEY on one of the tables
--         or just put "both" parts of data in the same table.
--   many-to-one - (one customer places many orders, each order is placed by one customer)
--        need two tables.
--        with a FOREIGN KEY on the table for the "many" side (e.g. order)
--   many-to-many - (one student is in many courses, one course has many students)
--         have a third table for the relationship itself.
--            having two NOT NULL FOREIGN KEYS pointing to the main two tables.
--            (taken together they should be UNIQUE)
--          we call this third table a "join table" or a "junction table"


-- whenever you put a foreign key on a table,
-- you're saying that row can have at most ONE corresponding row in the OTHER table.

ALTER TABLE School.Course
	ADD DateModified DATETIME2 DEFAULT SYSUTCDATETIME();

INSERT INTO School.Student (Name) VALUES ('Ray'), ('Nick'), ('Alfred');

INSERT INTO School.Course (Id, CourseNumber) VALUES (1, 'CS101'), (2, 'CS102'), (3, 'CS103');

INSERT INTO School.Enrollment (StudentId, CourseId) VALUES
	((SELECT Id FROM School.Student WHERE Name = 'Nick'),
		(SELECT Id FROM School.Course WHERE CourseNumber = 'CS101')),
	((SELECT Id FROM School.Student WHERE Name = 'Nick'),
		(SELECT Id FROM School.Course WHERE CourseNumber = 'CS102')),
	((SELECT Id FROM School.Student WHERE Name = 'Alfred'),
		(SELECT Id FROM School.Course WHERE CourseNumber = 'CS103')),
	((SELECT Id FROM School.Student WHERE Name = 'Alfred'),
		(SELECT Id FROM School.Course WHERE CourseNumber = 'CS101'));
		
ALTER TABLE School.Enrollment
	DROP CONSTRAINT UQ__Enrollme__32C52B98F6DE463C;
ALTER TABLE School.Enrollment
	DROP CONSTRAINT UQ__Enrollme__C92D71A6F165D408;

--DROP TABLE

--DROP SCHEMA

--DROP DATABASE