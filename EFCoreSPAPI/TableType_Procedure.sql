CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [varchar](10) NOT NULL,
	[PersonName] [varchar](100) NOT NULL,
	[ResidenceNo] [varchar](10) NOT NULL,
	[ResidenceName] [varchar](30) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

 CREATE TYPE PersonTableType AS TABLE
(
PersonId varchar(10),
	PersonName varchar(100),
 ResidenceNo varchar(10),
 ResidenceName varchar(30),
  Street varchar(50),
   City varchar(50)
)
Go

Create Procedure InsertPerson 
@PersonAddress PersonTableType READONLY,
@Id int OUT
As
Begin
 
	Insert into [dbo].[Person]  
		select * from @PersonAddress
		SET @Id = SCOPE_IDENTITY()
End
GO


-- Execution SP with Custom Table Type

DECLARE @Person PersonTableType;
Declare @Idres int;
Insert into @Person Values('Per001','Mahesh','B604','Prestene Fontana','LMD Chowk','Bavdhan Pune')

Exec InsertPerson @PersonAddress = @Person, @Id=@Idres