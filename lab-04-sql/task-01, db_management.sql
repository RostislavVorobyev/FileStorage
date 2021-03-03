--1) Создайте базу данных с именем Something.
CREATE DATABASE [Something];

--2) Убедитесь в том, что база данных была успешно создана. Для этих целей напишите простейший SELECT, который выводит на экран имя базы данных и дату её создания.
SELECT [name], [crdate] FROM sys.sysdatabases;

--3) В базе Something создайте таблицу Wicked с одной колонкой Id типа INT. Колонка Id не должна поддерживать NULL значения.
USE [Something];
CREATE TABLE [Wicked] ([ID] [int] NOT NULL);

--4) Создайте бэкап базы данных Something при помощи инструкции BACKUP DATABASE.
BACKUP DATABASE [Something] TO DISK = 'C:\Something.bak';

--5) Удалите базу данных при помощи инструкции DROP DATABASE
DROP DATABASE [Something];

--6) Восстановите базу данных при помощи инструкции RESTORE DATABASE.
RESTORE DATABASE [Something] FROM DISK = 'C:\Something.bak';

