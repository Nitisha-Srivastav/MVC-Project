-- Creating databse
Create database INVENTORY

--Create table using databse
Create table PRODUCT (Id int identity(1,1) primary key,
						ProductName varchar(30) not null,
						ProductDescription varchar(100) not null,
						ProductImg varchar(MAX),
						ProductPrice numeric(10,2) not null,
)

--Viewing table details
SELECT [Id]
      ,[ProductName]
      ,[ProductDescription]
      ,[ProductImg]
      ,[ProductPrice]
  FROM [INVENTORY].[dbo].[PRODUCT]