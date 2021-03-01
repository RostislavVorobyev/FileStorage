-- 1) ������� �� ����� ������ ����������� � ��������� ������������ ������, �� ������� �� ����������� �������� ��������.
SELECT [emp].[BusinessEntityID], [emp].[JobTitle], MAX([ph].[Rate]) AS [MaxRate] 
FROM [HumanResources].[Employee] AS [emp]
JOIN [HumanResources].[EmployeePayHistory] AS [ph] ON [emp].[BusinessEntityID] = [ph].[BusinessEntityID]
GROUP BY [emp].[BusinessEntityID], [emp].[JobTitle];

-- 2) ������� ��� ��������� ������ �� ������ ����� �������, ����� ���������� ������ ������� � ���� ������. 
-- ������ ����� ������ ���� ������������ �� ����������� ������. �������� ������� RateRank
SELECT [Employee].[BusinessEntityID], [Employee].[JobTitle], [EmployeePayHistory].[Rate],
DENSE_RANK() OVER (ORDER BY [EmployeePayHistory].[Rate] ASC) AS [RateRank]
FROM [HumanResources].[Employee]
INNER JOIN [HumanResources].[EmployeePayHistory] ON ([Employee].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]);

-- 3) ������� �� ����� ������ �����������, � ������� ��������� ������ ���������� ���� �� ���� ���. �� ��������� �����������, ������� ������ �� �������� � ������.
SELECT [Employee].[BusinessEntityID] ,[Employee].[JobTitle]
FROM [HumanResources].[Employee] 
JOIN [HumanResources].[EmployeePayHistory] ON [Employee].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]
JOIN [HumanResources].[EmployeeDepartmentHistory] ON [EmployeePayHistory].[BusinessEntityID] = [EmployeeDepartmentHistory].[BusinessEntityID]
WHERE [EmployeeDepartmentHistory].[EndDate] IS NULL
GROUP BY [Employee].[BusinessEntityID], [Employee].[JobTitle]
HAVING COUNT(*) > 1;

--4) ������� �� ����� ���������� ����������� � ������ ������. �������� �������, ���������� ��������� - EmployeeCount.
SELECT [EmployeeDepartmentHistory].[DepartmentID], [Department].[Name], COUNT(EmployeeDepartmentHistory.BusinessEntityID) AS [EmployeeCount]
FROM [HumanResources].[Department] 
INNER JOIN [HumanResources].[EmployeeDepartmentHistory] ON [Department].[DepartmentID] = [EmployeeDepartmentHistory].[DepartmentID]
GROUP BY [EmployeeDepartmentHistory].[DepartmentID], [Department].[Name];

-- 5) ������� �� ����� ��� ��������� ������ �����������. ��������� ������ ��������� ������� � ����������� � ���������� ��������� ������ ��� ������� ���������� -
-- PrevRate � ������� � ��������� ������� ����� ������� ������� � ���������� ������� ��� ������� ���������� - DiffRate. 
SELECT [emp].[BusinessEntityID], [emp].[JobTitle], [p].[Rate],
LAG([p].[Rate],1,0) OVER(PARTITION BY [p].[BusinessEntityID] ORDER BY [p].[BusinessEntityID]) AS [PrevRate],
[p].[Rate] - LAG([p].[Rate],1,0) OVER(PARTITION BY [p].[BusinessEntityID] ORDER BY [p].[BusinessEntityID]) AS [DiffRate]
FROM [HumanResources].[Employee] AS [emp]
INNER JOIN [HumanResources].[EmployeePayHistory] AS p ON [p].[BusinessEntityID] = [emp].[BusinessEntityID];

-- 6) ������� �� ����� ��������� ������ �����������, � ��������� ������������ ������ ��� ������� ������ � ������� MaxInDepartment. 
-- � ������ ������� ������ �������� ��� ������ �� ������ ����� �������, ����� ������ � ����������� ���������� ������� � ������ ����� ������. 
SELECT [Department].[Name], [EmployeeDepartmentHistory].[BusinessEntityID], [EmployeePayHistory].[Rate], 
MAX([EmployeePayHistory].[Rate]) OVER (PARTITION BY [Department].[Name]) AS [MaxInDepartment],
DENSE_RANK() OVER (PARTITION BY [Department].[Name] ORDER BY [EmployeePayHistory].[Rate] ASC) AS [RateGroup]
FROM [HumanResources].[EmployeeDepartmentHistory]
INNER JOIN [HumanResources].[Department] ON ([EmployeeDepartmentHistory].[DepartmentID] = [Department].[DepartmentID])
INNER JOIN [HumanResources].[EmployeePayHistory] ON ([EmployeeDepartmentHistory].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]);

-- 7) ������� �� ����� ������ �����������, ������� �������� � �������� �����.
SELECT [Employee].[BusinessEntityID]
FROM [HumanResources].[Employee] 
INNER JOIN [HumanResources].[EmployeeDepartmentHistory]  ON [EmployeeDepartmentHistory].[BusinessEntityID] = [Employee].[BusinessEntityID]
INNER JOIN [HumanResources].[Shift] ON [EmployeeDepartmentHistory].[ShiftID] = [Shift].[ShiftID]
WHERE [Shift].[Name] ='Evening';

-- 8) ������� �� ����� ���������� ���, ������� ������ ��������� ���������� � ������ ������ - ������� Experience. 
-- ���� ��������� �������� � ������ �� ��������� �����, ���������� ��� �������� �� ������������ ���.

SELECT [Employee].[BusinessEntityID], [Employee].[JobTitle], [HumanResources].[Department].[Name], 
		(SELECT (YEAR(ISNULL(dh2.EndDate, GETDATE())) - YEAR(dh2.StartDate)) 
		FROM [HumanResources].[EmployeeDepartmentHistory] dh2
		WHERE [dh].[BusinessEntityID] = [dh2].[BusinessEntityID] AND [dh].[DepartmentID] = [dh2].[DepartmentID]) AS 'Expirience'
FROM [HumanResources].[Employee] 
JOIN [HumanResources].[EmployeeDepartmentHistory] dh ON [Employee].[BusinessEntityID] = [dh].[BusinessEntityID]
JOIN [HumanResources].[Department] ON [Department].[DepartmentID] = [dh].[DepartmentID]
