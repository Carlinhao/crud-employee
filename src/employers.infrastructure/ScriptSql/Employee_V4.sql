create database BD03;

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

GO

INSERT INTO Department
VALUES (0,'Sales','Sales'),
(0,'It','It'),
(0,'Sales','Sales'),
(0,'RH','RH'),
(1,'Manger','Manager'),
(0,'Health','Health')

GO

INSERT INTO Employee (NOM_EMPLOYEE, GENDER, ACTIVE, ID_DEPARTMENT, ID_OCCUPATION)
VALUES
('John Doe', 'M', 1, 1, 1),
('Jane Smith', 'F', 1, 2, 2),
('Bob Johnson', 'M', 1, 3, 3),
('Alice Williams', 'F', 1, 4, 4),
('Mike Brown', 'M', 1, 5, 5),
('Sarah Davis', 'F', 1, 6, 6),
('David Wilson', 'M', 1, 1, 7),
('Emily Martinez', 'F', 1, 2, 8),
('Chris Anderson', 'M', 1, 3, 9),
('Anna Taylor', 'F', 1, 4, 1),
('Tom Clark', 'M', 1, 5, 2),
('Olivia Rodriguez', 'F', 1, 6, 3),
('Daniel Garcia', 'M', 1, 1, 4),
('Sophia Lopez', 'F', 1, 2, 5),
('Matthew Scott', 'M', 1, 3, 6),
('Isabella Hernandez', 'F', 1, 4, 7),
('Alexander Hernandez', 'M', 1, 5, 8),
('Mia Johnson', 'F', 1, 6, 9),
('William Davis', 'M', 1, 1, 1),
('Charlotte Wilson', 'F', 1, 2, 2),
('James Anderson', 'M', 1, 3, 3),
('Ava Taylor', 'F', 1, 4, 4),
('Benjamin Clark', 'M', 1, 5, 5),
('Emma Rodriguez', 'F', 1, 6, 6),
('Ethan Martinez', 'M', 1, 1, 7),
('Liam Scott', 'M', 1, 2, 8),
('Oliver Anderson', 'M', 1, 3, 9),
('Sophia Hernandez', 'F', 1, 4, 1),
('Mason Clark', 'M', 1, 5, 2),
('Logan Taylor', 'M', 1, 6, 3),
('Jackson Wilson', 'M', 1, 1, 4),
('Aiden Johnson', 'M', 1, 2, 5),
('Elijah Davis', 'M', 1, 3, 6),
('Lucas Lopez', 'M', 1, 4, 7),
('Michael Scott', 'M', 1, 5, 8),
('Daniel Hernandez', 'M', 1, 6, 9),
('Gabriel Martinez', 'M', 1, 1, 1),
('Andrew Clark', 'M', 1, 2, 2),
('Joseph Taylor', 'M', 1, 3, 3),
('Matthew Wilson', 'M', 1, 4, 4),
('Christopher Johnson', 'M', 1, 5, 5),
('Joshua Davis', 'M', 1, 6, 6),
('Nicholas Lopez', 'M', 1, 1, 7),
('Samuel Martinez', 'M', 1, 2, 8),
('Isaiah Scott', 'M', 1, 3, 9),
('David Hernandez', 'M', 1, 4, 1),
('Ryan Clark', 'M', 1, 5, 2),
('Ethan Taylor', 'M', 1, 6, 3),
('Caleb Wilson', 'M', 1, 1, 4)