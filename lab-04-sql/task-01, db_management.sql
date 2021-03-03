--1) �������� ���� ������ � ������ Something.
CREATE DATABASE [Something];

--2) ��������� � ���, ��� ���� ������ ���� ������� �������. ��� ���� ����� �������� ���������� SELECT, ������� ������� �� ����� ��� ���� ������ � ���� � ��������.
SELECT [name], [crdate] FROM sys.sysdatabases;

--3) � ���� Something �������� ������� Wicked � ����� �������� Id ���� INT. ������� Id �� ������ ������������ NULL ��������.
USE [Something];
CREATE TABLE [Wicked] ([ID] [int] NOT NULL);

--4) �������� ����� ���� ������ Something ��� ������ ���������� BACKUP DATABASE.
BACKUP DATABASE [Something] TO DISK = 'C:\Something.bak';

--5) ������� ���� ������ ��� ������ ���������� DROP DATABASE
DROP DATABASE [Something];

--6) ������������ ���� ������ ��� ������ ���������� RESTORE DATABASE.
RESTORE DATABASE [Something] FROM DISK = 'C:\Something.bak';

