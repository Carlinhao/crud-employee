CREATE TABLE Departamento(

    ID_DPTO INT PRIMARY KEY NOT NULL IDENTITY(1, 1),

    NOM_DPTO VARCHAR(50)

);


CREATE TABLE Empregado (

    ID_EMP INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    NOM_EMP VARCHAR(50),

    ID_DPTO INT REFERENCES Departamento(ID_DPTO)

);


INSERT INTO Departamento

VALUES ('Venda'),

       ('Engenharia'),

       ('Administração'),

       ('Marketing');


INSERT INTO Empregado

VALUES ('Paul Stone', 1),

       ('Bruno Oliveira', 2),

       ('Paula Ull', 1),

       ('Camila Rest', 4),

       ('Maria Joaquina', 4),

       ('Lisa Simpson', 3);