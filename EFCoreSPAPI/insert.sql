 CREATE PROCEDURE [dbo].[InsertProduct]
		@Id int OUT,
		@ProductId varchar(10),
		@ProductName varchar(50),
		@CategoryName varchar(50),
		@Price int
        AS
        BEGIN
            SET NOCOUNT ON;
            Insert into ProductMaster values (@ProductId,@ProductName,@CategoryName,@Price)
			SET @Id = SCOPE_IDENTITY()
        END



