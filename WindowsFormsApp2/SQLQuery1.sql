create database D_BASE_1
use D_BASE_1
go


CREATE TABLE Products
(
    [Id]				INT            IDENTITY (1, 1)	NOT NULL,
    [Article]			NVARCHAR (50)					NOT NULL,
    [Name]				NVARCHAR (250)					NOT NULL,
    [Price]				NUMERIC (15,2)					NOT NULL,
	[Quantity]			INT								NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
)

select * from Products
SELECT * FROM Products

Truncate table [Products]
INSERT INTO Products( id, Article, [Name], price, Quantity) VALUES (1,'effefefef','wfwf1',434,34)

SET IDENTITY_INSERT [dbo].[Products] off