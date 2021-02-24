-- 4.1
-- 1)
CREATE TABLE [dbo].[Person](
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

-- 2)
ALTER TABLE [dbo].[Person]
ADD [PersonId] [INT] PRIMARY KEY IDENTITY (3,5);

-- 3)
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT CK_Person_Midlename CHECK (MiddleName = 'J' OR MiddleName = 'L')

-- 4) 
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT CK_Person_Title DEFAULT ('N/A') FOR [TITLE];

-- 5) 
INSERT INTO [Person] SELECT [p].[BusinessEntityID], [p].[PersonType], [p].[NameStyle], [p].[Title], [p].[FirstName], [p].[MiddleName], [p].[LastName], [p].[Suffix], [p].[EmailPromotion], [p].[ModifiedDate]
FROM [HumanResources].[Employee] AS [emp]
INNER JOIN [Person].[Person] AS p ON [emp].[BusinessEntityID] = [p].[BusinessEntityID]
INNER JOIN [HumanResources].[Department] AS d ON [p].[BusinessEntityID] = [emp].[BusinessEntityID]
WHERE [d].[Name] NOT LIKE 'Finance';

-- 6)
ALTER TABLE [Person]
ALTER COLUMN [Title] [NVARCHAR](6);

-- 4.2

-- 1)
CREATE TABLE [dbo].[StateProvince](
	[StateProvinceID] [INT] IDENTITY(1,1) NOT NULL,
	[StateProvinceCode] [NCHAR](3) NOT NULL,
	[CountryRegionCode] [NVARCHAR](3) NOT NULL,
	[IsOnlyStateProvinceFlag] [BIT] NOT NULL,
	[Name] [NVARCHAR](50) NOT NULL,
	[TerritoryID] [INT] NOT NULL,
	[ModifiedDate] [DATETIME] NOT NULL);

-- 2)
ALTER TABLE [dbo].[StateProvince]
ADD CONSTRAINT UQ_StateProvince_Name UNIQUE ([Name]);

-- 3)
ALTER TABLE [StateProvince]
ADD CONSTRAINT CK_StateProvince_CountryRegionCode CHECK (CountryRegionCode NOT LIKE '%[0-9]%');

-- 4) 
ALTER TABLE [StateProvince]
ADD CONSTRAINT DF_StateProvince_ModifiedDate DEFAULT (GETDATE()) FOR [ModifiedDate];

-- 5) 
INSERT INTO [StateProvince] SELECT 
	p.StateProvinceID, 
	p.StateProvinceCode, 
	p.CountryRegionCode, 
	p.IsOnlyStateProvinceFlag, 
	p.Name, 
	p.TerritoryID, 
	p.ModifiedDate
FROM [Person].[StateProvince] p INNER JOIN [Person].[CountryRegion] ON [p].[Name] = [Person].[CountryRegion].[Name];

-- 6)
ALTER TABLE [StateProvince]
DROP COLUMN IsOnlyStateProvinceFlag;

ALTER TABLE [StateProvince]
ADD [Population] [INT];