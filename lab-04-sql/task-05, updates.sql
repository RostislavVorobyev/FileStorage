-- 1)
CREATE TABLE [dbo].[Person_New](
	[BusinessEntityID] [INT] NOT NULL,
	[PersonType] [NCHAR](2) NOT NULL,
	[NameStyle] [BIT] NOT NULL,
	[Title] [NVARCHAR](8) NULL,
	[FirstName] [NVARCHAR](50) NOT NULL,
	[MiddleName] [NVARCHAR](50) NULL,
	[LastName] [NVARCHAR](50) NOT NULL,
	[Suffix] [NVARCHAR](10) NULL,
	[EmailPromotion] [INT] NOT NULL,
	[ModifiedDate] [DATETIME] NOT NULL);
	
--2) 
ALTER TABLE [dbo].[Person_New] 
ADD [Salutation] [NVARCHAR](80);

--3) 
INSERT INTO [dbo].[Person_New] (
	[BusinessEntityID],
	[PersonType], [NameStyle], 
	[Title], [FirstName],
	[MiddleName], [LastName],
	[Suffix], [EmailPromotion],
	[ModifiedDate])
SELECT 
	p.BusinessEntityID, 
	p.PersonType, p.NameStyle,
	IIF(emp.Gender = 'M', 'Mr', 'Ms'), [p.FirstName],
	[p.MiddleName], [p.LastName],
	[p.Suffix], [p.EmailPromotion],
	[p.ModifiedDate]
FROM [dbo].[Person] as p
INNER JOIN  [HumanResources].[Employee] AS emp ON p.BusinessEntityID = emp.BusinessEntityID;

--4) 
UPDATE [dbo].[Person_New]
SET [Salutation] = [Title] + ' ' + [FirstName];

--5)
DELETE FROM [dbo].[Person_New]
WHERE LEN(Salutation) > 10;

--6)

--7) 
ALTER TABLE [dbo].[Person] DROP CONSTRAINT PK__Person__AA2FFBE593A4E081;
ALTER TABLE [dbo].[Person] 
DROP COLUMN [PersonId];

--8
DROP TABLE [dbo].[Person], [dbo].[Person_New];