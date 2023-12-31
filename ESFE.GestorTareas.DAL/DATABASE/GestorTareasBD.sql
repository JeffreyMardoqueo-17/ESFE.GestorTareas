CREATE DATABASE GestorTareasBD
GO
USE GestorTareasBD

----TABLA CARGO
CREATE TABLE Cargo(
Id TINYINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
GO
----TABLA CATEGORIA
CREATE TABLE Categoria(
Id TINYINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
GO
----TABLA PRIORIDAD
CREATE TABLE Prioridad(
Id TINYINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
GO

----Estado De tarea
CREATE TABLE EstadoTarea(
Id TINYINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
GO

----- TABLA EMPLEADO
CREATE TABLE Empleado(
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
Apellido VARCHAR (50) NOT NULL,
Telefono VARCHAR (9) NOT NULL,
IdCargo TINYINT NOT NULL FOREIGN KEY REFERENCES Cargo(Id)
)
GO
----TABLA USUARIO
CREATE TABLE Usuario(
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (25) NOT NULL,
Correo VARCHAR (50) NOT NULL,
Contraseņa VARCHAR (50) NOT NULL,
IdEmpleado INT NOT NULL FOREIGN KEY REFERENCES Empleado(Id)
)
GO
---- TABLA TAREA
CREATE TABLE Tarea(
Id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
Descripcion VARCHAR(MAX) NOT NULL,
Prioridad VARCHAR(20) NOT NULL,
Estado VARCHAR (20) NOT NULL,
FechaVencimiento DATETIME NOT NULL,
IdCategoria TINYINT NOT NULL FOREIGN KEY REFERENCES Categoria(Id),
IdPrioridad TINYINT NOT NULL FOREIGN KEY REFERENCES Prioridad(Id),
IdEstadoTarea TINYINT NOT NULL FOREIGN KEY REFERENCES EstadoTarea(Id),
)
GO
----TABLA ASIGNACION DE TAREAS

CREATE TABLE AsignacionTareas(
Id Bigint NOT NULL PRIMARY KEY IDENTITY (1,1),
FechaAsignada Date NOT NULL,
FechaFinalizacion Datetime NOT NULL,
IdTarea BIGINT NOT NULL FOREIGN KEY REFERENCES Tarea(Id),
IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id),
IdEmpleado INT NOT NULL FOREIGN KEY REFERENCES Empleado(Id),
)