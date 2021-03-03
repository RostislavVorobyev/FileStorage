USE AdventureWorks2017;

-- 1) Вывести на экран список департаментов, отсортированных в порядке убывания названия департамента.
-- Вывести только первые 8 записей.
SELECT TOP 8 * FROM [HumanResources].[Department] ORDER BY [Name] DESC;

-- 2) Вывести на экран список сотрудников, которым было или исполнится 22 в год взятия сотрудника на работу.
SELECT * FROM [HumanResources].[Employee] WHERE (YEAR([HireDate]) - YEAR([BirthDate])) = 22;

-- 3) Вывести на экран всех семейных сотрудников, начиная с самого взрослого, которые занимают следующие позиции -
SELECT * FROM [HumanResources].[Employee] 
WHERE [MaritalStatus] = 'M' AND [JobTitle] IN ('Design Engineer', 'Tool Designer', 'Engineering Manager', 'Production Control Manager')
ORDER BY [BirthDate];

-- 4) Вывести на экран сотрудников, которых приняли на работу 5-го марта (любого года). 
-- Отсортировать результат по возрастанию значения BusinessEntityID. Вывести на экран только 5 строк, пропустив 1 значение.
SELECT * FROM [HumanResources].[Employee] 
WHERE DAY([HireDate]) = 5 AND MONTH([HireDate]) = 3
ORDER BY [BusinessEntityID] 
OFFSET 1 ROW
FETCH NEXT 5 ROWS ONLY;

-- 5) Вывести на экран список сотрудников женского пола, принятых на работу в среду (Wednesday).
------ В поле LoginID заменить домен adventure-works на adventure-works2017.
SELECT *, REPLACE ([LoginId], 'adventure-works', 'adventure-works2017') 
FROM [HumanResources].[Employee] 
WHERE [Gender] = 'F' AND DATENAME(WEEKDAY, HireDate) = 'Wednesday'

-- 6) Вывести на экран сумму часов отпуска и сумму больничных часов у каждого сотрудника - VacationSumInHours, SicknessSumInHours.
SELECT SUM([emp].[VacationHours]) AS [VacationSumInHours], SUM([emp].[SickLeaveHours]) AS [VacationSumInHours]
FROM [HumanResources].[Employee] AS [emp];

-- 7) Вывести на экран список неповторяющихся должностей в убывающем порядке, причём отобразить только первые 8 названий. 
-- В результате должен фигурировать новый столбец - LastWord, содержащий последнее слово из поля JobTitle.
SELECT DISTINCT TOP(8) [JobTitle], LTRIM(REVERSE(SUBSTRING(REVERSE(JobTitle), 1, CHARINDEX(' ', REVERSE(JobTitle ) + ' ')))) 'LastWord'
FROM [HumanResources].[Employee]
ORDER BY [JobTitle] DESC;

-- 8) Вывести на экран сотрудников, название позиции которых включает слово Control.
SELECT * FROM [HumanResources].[Employee]
WHERE [JobTitle] LIKE '%Control%'

