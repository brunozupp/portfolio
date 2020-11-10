CREATE DATABASE Portifolio
USE Portifolio

SELECT D.* FROM Details D
SELECT S.* FROM Skills S -- 4
SELECT A.* FROM AcademicTrainings A --1
SELECT E.* FROM Experiences E -- 1
SELECT P.* FROM Projects P -- 2

CREATE TABLE Details(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(150) NOT NULL,
	Email NVARCHAR(100),
	Phone NVARCHAR(20),
	BirthDate DATE,
	Linkedin NVARCHAR(150),
	Instagram NVARCHAR(150),
	Facebook NVARCHAR(150),
	Nationality NVARCHAR(50),
	About TEXT NOT NULL,
	Goals TEXT NOT NULL,
)

ALTER TABLE Details ADD Photo NVARCHAR(255)

SELECT * FROM Details

-- Formações Acadêmcias
CREATE TABLE AcademicTrainings(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(150) NOT NULL,
	Institution NVARCHAR(150) NOT NULL,
	[Begin] DATE,
	[End] DATE
)
SELECT GetDATE()
SELECT * FROM AcademicTrainings

CREATE TABLE Experiences(
	ID INT PRIMARY KEY IDENTITY,
	Company NVARCHAR(150),
	Description TEXT NOT NULL,
	[Begin] DATE,
	[End] DATE
)

CREATE TABLE Skills(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50)  NOT NULL,
	Aptitude FLOAT NOT NULL -- pontuação de 0 á 5
)

CREATE TABLE Projects(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(150) NOT NULL,
	Description TEXT NOT NULL,
)

SELECT * FROM Projects

-- Depois de pronto, criar uma tabela Images para conter as fotos dos projetos