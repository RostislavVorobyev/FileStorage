USE AdventureWorks2017;

-- 1) ������� �� ����� ������ �������������, ��������������� � ������� �������� �������� ������������.
-- ������� ������ ������ 8 �������.
SELECT TOP 8 * FROM [HumanResources].[Department] ORDER BY [Name] DESC;

-- 2) ������� �� ����� ������ �����������, ������� ���� ��� ���������� 22 � ��� ������ ���������� �� ������.
SELECT * FROM [HumanResources].[Employee] WHERE (YEAR([HireDate]) - YEAR([BirthDate])) = 22;

-- 3) ������� �� ����� ���� �������� �����������, ������� � ������ ���������, ������� �������� ��������� ������� -
SELECT * FROM [HumanResources].[Employee] 
WHERE [MaritalStatus] = 'M' AND [JobTitle] IN ('Design Engineer', 'Tool Designer', 'Engineering Manager', 'Production Control Manager')
ORDER BY [BirthDate];

-- 4) ������� �� ����� �����������, ������� ������� �� ������ 5-�� ����� (������ ����). 
-- ������������� ��������� �� ����������� �������� BusinessEntityID. ������� �� ����� ������ 5 �����, ��������� 1 ��������.
SELECT * FROM [HumanResources].[Employee] 
WHERE DAY([HireDate]) = 5 AND MONTH([HireDate]) = 3
ORDER BY [BusinessEntityID] 
OFFSET 1 ROW
FETCH NEXT 5 ROWS ONLY;

-- 5) ������� �� ����� ������ ����������� �������� ����, �������� �� ������ � ����� (Wednesday).
------ � ���� LoginID �������� ����� adventure-works �� adventure-works2017.
SELECT *, REPLACE ([LoginId], 'adventure-works', 'adventure-works2017') 
FROM [HumanResources].[Employee] 
WHERE [Gender] = 'F' AND DATENAME(WEEKDAY, HireDate) = 'Wednesday'

-- 6) ������� �� ����� ����� ����� ������� � ����� ���������� ����� � ������� ���������� - VacationSumInHours, SicknessSumInHours.
SELECT SUM([emp].[VacationHours]) AS [VacationSumInHours], SUM([emp].[SickLeaveHours]) AS [VacationSumInHours]
FROM [HumanResources].[Employee] AS [emp];

-- 7) ������� �� ����� ������ ��������������� ���������� � ��������� �������, ������ ���������� ������ ������ 8 ��������. 
-- � ���������� ������ ������������ ����� ������� - LastWord, ���������� ��������� ����� �� ���� JobTitle.
SELECT DISTINCT TOP(8) [JobTitle], LTRIM(REVERSE(SUBSTRING(REVERSE(JobTitle), 1, CHARINDEX(' ', REVERSE(JobTitle ) + ' ')))) 'LastWord'
FROM [HumanResources].[Employee]
ORDER BY [JobTitle] DESC;

-- 8) ������� �� ����� �����������, �������� ������� ������� �������� ����� Control.
SELECT * FROM [HumanResources].[Employee]
WHERE [JobTitle] LIKE '%Control%'

