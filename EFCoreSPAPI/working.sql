Create Table Cars
(
    Id int primary key,
    Name nvarchar(50),
    company nvarchar(50)
)
Go

CREATE TYPE CarTableType AS TABLE
(
     Id int primary key,
    Name nvarchar(50),
    company nvarchar(50)
)
Go

CREATE PROCEDURE spInsertCars
@CarType CarTableType READONLY
AS
BEGIN
    INSERT INTO Cars
    SELECT * FROM @CarType
END