-- 1)
CREATE TABLE [Person_New]
(
	[BusinessEntityID] INT NOT NULL,
	[PersonType] NCHAR(2) NOT NULL,
	[NameStyle] BIT NOT NULL,
	[Title] NVARCHAR(8) NULL CONSTRAINT DF_Person_New DEFAULT 'N/A',
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NULL CONSTRAINT CK_Person_New CHECK (MiddleName = 'J' OR MiddleName = 'L'),
	[LastName] NVARCHAR(50) NOT NULL,
	[Suffix] NVARCHAR(10) NULL,
	[EmailPromotion] INT NOT NULL,
	[ModifiedDate] DATETIME NOT NULL,
	[PersonID] INT IDENTITY(3, 5) CONSTRAINT PK_PersonId_New PRIMARY KEY	
);

-- 2)
ALTER TABLE [Person_New]
ADD [Salutation] NVARCHAR(80);

