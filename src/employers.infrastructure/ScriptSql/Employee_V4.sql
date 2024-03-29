﻿create database BD03;

GO

USE BD03;

GO

CREATE TABLE Department
(
    ID_DEPARTMENT INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    MANAGER INT NOT NULL,
    NOM_DEPARTMENT VARCHAR(50) NOT NULL,
    DESC_DEPARTMENT VARCHAR(250) NOT NULL
);

GO

CREATE TABLE Occupation
(
    ID_OCCUPATION INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    NOM_OCCUPATION VARCHAR(50) NOT NULL,
    LEVEL_OCCUPATION VARCHAR(50) NOT NULL
);

GO

CREATE TABLE Employee
(
    ID_EMPLOYEE INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    NOM_EMPLOYEE VARCHAR(50),
    GENDER CHAR(1),
    ACTIVE BIT NOT NULL,
    ID_DEPARTMENT INT REFERENCES Department(ID_DEPARTMENT),
    ID_OCCUPATION INT REFERENCES Occupation(ID_OCCUPATION)
);

GO

CREATE TABLE User_Auth
(
    ID_USER INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    NAME_USER VARCHAR(50) NOT NULL,
    FULL_NAME_USER VARCHAR(500) NOT NULL,
    USER_PWD VARCHAR(500) NOT NULL,
    ACESS_TOKEN VARCHAR(1000) NULL,
    REFRESH_TOKEN VARCHAR(1000) NULL,
    REFRESH_TOKEN_EXPIRE DATETIME NULL
);

GO
-- Attention script for educational purposes only. Don't use in your professional project consult your tech lead and GSI
INSERT INTO User_Auth
VALUES ('admin', 'admin@admin', '4F-3B-EF-5F-01-3B-F3-75-B0-50-98-66-42-10-D2-13-7C-82-D7-6F-E5-4F-9C-CF-F7-FE-06-EE-4B-18-99-62','','','');

GO

INSERT INTO Occupation
VALUES ('PO','Junior'),
 ('PO','Middle Level'),
 ('PO','Senior'),
 ('Developer','Junior'),
 ('Developer','Middle Level'),
 ('Developer','Senior'),
 ('Front End','Junior'),
 ('Front End','Middle Level'),
 ('Front End','Senior');
