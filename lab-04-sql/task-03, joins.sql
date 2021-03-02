-- 1) Вывести на экран список сотрудников с указанием максимальной ставки, по которой им выплачивали денежные средства.
SELECT [emp].[BusinessEntityID], [emp].[JobTitle], MAX([ph].[Rate]) AS [MaxRate] 
FROM [HumanResources].[Employee] AS [emp]
JOIN [HumanResources].[EmployeePayHistory] AS [ph] ON [emp].[BusinessEntityID] = [ph].[BusinessEntityID]
GROUP BY [emp].[BusinessEntityID], [emp].[JobTitle];

-- 2) Разбить все почасовые ставки на группы таким образом, чтобы одинаковые ставки входили в одну группу. 
-- Номера групп должны быть распределены по возрастанию ставок. Назовите столбец RateRank
SELECT [Employee].[BusinessEntityID], [Employee].[JobTitle], [EmployeePayHistory].[Rate],
DENSE_RANK() OVER (ORDER BY [EmployeePayHistory].[Rate] ASC) AS [RateRank]
FROM [HumanResources].[Employee]
INNER JOIN [HumanResources].[EmployeePayHistory] ON ([Employee].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]);

-- 3) Вывести на экран список сотрудников, у которых почасовая ставка изменялась хотя бы один раз. Не учитывать сотрудников, которые больше не работают в отделе.
SELECT [Employee].[BusinessEntityID] ,[Employee].[JobTitle]
FROM [HumanResources].[Employee] 
JOIN [HumanResources].[EmployeePayHistory] ON [Employee].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]
JOIN [HumanResources].[EmployeeDepartmentHistory] ON [EmployeePayHistory].[BusinessEntityID] = [EmployeeDepartmentHistory].[BusinessEntityID]
WHERE [EmployeeDepartmentHistory].[EndDate] IS NULL
GROUP BY [Employee].[BusinessEntityID], [Employee].[JobTitle]
HAVING COUNT(*) > 1;

--4) Вывести на экран количество сотрудников в каждом отделе. Назовите столбец, содержащий результат - EmployeeCount.
SELECT [EmployeeDepartmentHistory].[DepartmentID], [Department].[Name], COUNT(EmployeeDepartmentHistory.BusinessEntityID) AS [EmployeeCount]
FROM [HumanResources].[Department] 
INNER JOIN [HumanResources].[EmployeeDepartmentHistory] ON [Department].[DepartmentID] = [EmployeeDepartmentHistory].[DepartmentID]
GROUP BY [EmployeeDepartmentHistory].[DepartmentID], [Department].[Name];

-- 5) Вывести на экран все почасовые ставки сотрудников. Результат должен содержать столбец с информацией о предыдущей почасовой ставке для каждого сотрудника -
-- PrevRate и столбец с указанием разницы между текущей ставкой и предыдущей ставкой для каждого сотрудника - DiffRate. 
SELECT [emp].[BusinessEntityID], [emp].[JobTitle], [p].[Rate],
LAG([p].[Rate],1,0) OVER(PARTITION BY [p].[BusinessEntityID] ORDER BY [p].[BusinessEntityID]) AS [PrevRate],
[p].[Rate] - LAG([p].[Rate],1,0) OVER(PARTITION BY [p].[BusinessEntityID] ORDER BY [p].[BusinessEntityID]) AS [DiffRate]
FROM [HumanResources].[Employee] AS [emp]
INNER JOIN [HumanResources].[EmployeePayHistory] AS p ON [p].[BusinessEntityID] = [emp].[BusinessEntityID];

-- 6) Вывести на экран почасовые ставки сотрудников, с указанием максимальной ставки для каждого отдела в столбце MaxInDepartment. 
-- В рамках каждого отдела разбейте все ставки на группы таким образом, чтобы ставки с одинаковыми значениями входили в состав одной группы. 
SELECT [Department].[Name], [EmployeeDepartmentHistory].[BusinessEntityID], [EmployeePayHistory].[Rate], 
MAX([EmployeePayHistory].[Rate]) OVER (PARTITION BY [Department].[Name]) AS [MaxInDepartment],
DENSE_RANK() OVER (PARTITION BY [Department].[Name] ORDER BY [EmployeePayHistory].[Rate] ASC) AS [RateGroup]
FROM [HumanResources].[EmployeeDepartmentHistory]
INNER JOIN [HumanResources].[Department] ON ([EmployeeDepartmentHistory].[DepartmentID] = [Department].[DepartmentID])
INNER JOIN [HumanResources].[EmployeePayHistory] ON ([EmployeeDepartmentHistory].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]);

-- 7) Вывести на экран список сотрудников, которые работают в вечернюю смену.
SELECT [Employee].[BusinessEntityID]
FROM [HumanResources].[Employee] 
INNER JOIN [HumanResources].[EmployeeDepartmentHistory]  ON [EmployeeDepartmentHistory].[BusinessEntityID] = [Employee].[BusinessEntityID]
INNER JOIN [HumanResources].[Shift] ON [EmployeeDepartmentHistory].[ShiftID] = [Shift].[ShiftID]
WHERE [Shift].[Name] ='Evening';

-- 8) Вывести на экран количество лет, которые каждый сотрудник проработал в каждом отделе - столбец Experience. 
-- Если сотрудник работает в отделе по настоящее время, количество лет считайте до сегодняшнего дня.

SELECT [Employee].[BusinessEntityID], [Employee].[JobTitle], [HumanResources].[Department].[Name], 
		(SELECT (YEAR(ISNULL(dh2.EndDate, GETDATE())) - YEAR(dh2.StartDate)) 
		FROM [HumanResources].[EmployeeDepartmentHistory] dh2
		WHERE [dh].[BusinessEntityID] = [dh2].[BusinessEntityID] AND [dh].[DepartmentID] = [dh2].[DepartmentID]) AS 'Expirience'
FROM [HumanResources].[Employee] 
JOIN [HumanResources].[EmployeeDepartmentHistory] dh ON [Employee].[BusinessEntityID] = [dh].[BusinessEntityID]
JOIN [HumanResources].[Department] ON [Department].[DepartmentID] = [dh].[DepartmentID]
