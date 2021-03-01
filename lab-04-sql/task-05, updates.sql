-- 1)
SELECT TOP 0 *
INTO [dbo].[Person_New]
FROM [dbo].[Person];

--2) 
ALTER TABLE [dbo].[Person_New] 
ADD [Salutation] [NVARCHAR](80);

--3) 
SET IDENTITY_INSERT [Person_New] ON;
INSERT INTO [Person_New] (BusinessEntityID, PersonType, NameStyle, Title, FirstName, MiddleName, LastName, Suffix, EmailPromotion, ModifiedDate, PersonID)
SELECT 
	p.BusinessEntityID, p.PersonType,
	p.NameStyle, IIF(emp.Gender = 'M', 'Mr', 'Ms'),
	p.FirstName, p.MiddleName,
	p.LastName, p.Suffix,
	p.EmailPromotion, p.ModifiedDate,
	p.PersonID
FROM [Person] AS p
INNER JOIN  HumanResources.Employee AS emp ON p.BusinessEntityID = emp.BusinessEntityID

--4) 
UPDATE [dbo].[Person_New]
SET [Salutation] = [Title] + ' ' + [FirstName];

--5)
DELETE FROM [dbo].[Person_New]
WHERE LEN(Salutation) > 10;

--6)
ALTER TABLE [Person]
DROP CONSTRAINT CK_Person_Midlename;
ALTER TABLE [Person]
DROP CONSTRAINT CK_Person_Title;

--7) 
ALTER TABLE [dbo].[Person] DROP CONSTRAINT PK__Person__AA2FFBE593A4E081;
ALTER TABLE [dbo].[Person] 
DROP COLUMN [PersonId];

--8
DROP TABLE [dbo].[Person], [dbo].[Person_New];