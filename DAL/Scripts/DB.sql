CREATE DATABASE Gastronomia
go

USE Gastronomia

-- Table RECETAS

CREATE TABLE [RECETAS]
(
    [ID_RECETA]          Bigint IDENTITY NOT NULL,
    [NOMBRE_RECETA]      Varchar(30)     NOT NULL,
    [DESCRIPCION]        Varchar(250)    NOT NULL,
    [TIEMPO_PREPARACION] Varchar(10)     NOT NULL,
    [TIEMPO_COCCION]     Varchar(10)     NOT NULL,
    [PORCIONES]          Tinyint         NOT NULL,
    [DIFICULTAD]         Tinyint         NOT NULL,
    [ID_CATEGORIA]       Bigint          NOT NULL,
    [ID_PERSONA]         Bigint          NOT NULL
)
go

-- Add keys for table RECETAS

ALTER TABLE [RECETAS]
    ADD CONSTRAINT [Unique_Identifier1] PRIMARY KEY ([ID_RECETA])
go

-- Table CATEGORIAS

CREATE TABLE [CATEGORIAS]
(
    [ID_CATEGORIA]     Bigint IDENTITY NOT NULL,
    [NOMBRE_CATEGORIA] Varchar(15)     NOT NULL,
    [DESCRIPCION]      Varchar(250)    NOT NULL
)
go

-- Add keys for table CATEGORIAS

ALTER TABLE [CATEGORIAS]
    ADD CONSTRAINT [Unique_Identifier2] PRIMARY KEY ([ID_CATEGORIA])
go

-- Table PERSONAS

CREATE TABLE [PERSONAS]
(
    [ID_PERSONA]       Bigint IDENTITY NOT NULL,
    [NOMBRES]          Varchar(30)     NOT NULL,
    [APELLIDO_PATERNO] Varchar(15)     NOT NULL,
    [APELLIDO_MATERNO] Varchar(15)     NOT NULL,
    [SEXO]             Char(1)         NOT NULL,
    [FECHA_NACIMIENTO] Date            NOT NULL,
    [DIRECCION]        Varchar(100)    NOT NULL,
    [TELEFONO]         Char(9)         NOT NULL,
    [CORREO]           Varchar(50)     NOT NULL,
    [USERNAME]         VARCHAR(15)     NOT NULL,
    [CONTRASENA]       VARCHAR(15)     NOT NULL
)
go

-- Add keys for table PERSONAS

ALTER TABLE [PERSONAS]
    ADD CONSTRAINT [Unique_Identifier3] PRIMARY KEY ([ID_PERSONA])
go

-- Table CARGOS

CREATE TABLE [CARGOS]
(
    [ID_CARGO]    Bigint IDENTITY NOT NULL,
    [TITULO]      Varchar(15)     NOT NULL,
    [DESCRIPCION] Varchar(250)    NOT NULL
)
go

-- Add keys for table CARGOS

ALTER TABLE [CARGOS]
    ADD CONSTRAINT [Unique_Identifier4] PRIMARY KEY ([ID_CARGO])
go

-- Table CURSOS

CREATE TABLE [CURSOS]
(
    [ID_CURSO]     Bigint IDENTITY NOT NULL,
    [NOMBRE]       Varchar(30)     NOT NULL,
    [DESCRIPCION]  Varchar(250)    NULL,
    [FECHA_INICIO] Varchar(15)     NOT NULL,
    [FECHA_FIN]    Varchar(15)     NOT NULL,
    [CUPOS]        Smallint        NOT NULL,
    [HORARIO]      Varchar(250)    NOT NULL,
    [COSTO]        Money           NOT NULL
)
go

-- Add keys for table CURSOS

ALTER TABLE [CURSOS]
    ADD CONSTRAINT [Unique_Identifier5] PRIMARY KEY ([ID_CURSO])
go

-- Table PRODUCTOS

CREATE TABLE [PRODUCTOS]
(
    [ID_PRODUCTO] Bigint IDENTITY NOT NULL,
    [NOMBRE]      Varchar(15)     NOT NULL,
    [DESCRIPCION] Varchar(250)    NOT NULL,
    [STOCK]       Smallint        NOT NULL
)
go

-- Add keys for table PRODUCTOS

ALTER TABLE [PRODUCTOS]
    ADD CONSTRAINT [Unique_Identifier6] PRIMARY KEY ([ID_PRODUCTO])
go

-- Table INGREDIENTES

CREATE TABLE [INGREDIENTES]
(
    [ID_INGREDIENTE]   Bigint         NOT NULL,
    [CANTIDAD]         DECIMAL(10, 2) NOT NULL,
    [ID_UNIDAD_MEDIDA] Bigint         NOT NULL,
    [ID_RECETA]        Bigint         NOT NULL
)
go

-- Add keys for table INGREDIENTES

ALTER TABLE [INGREDIENTES]
    ADD CONSTRAINT [Unique_Identifier7] PRIMARY KEY ([ID_INGREDIENTE], [ID_RECETA])
go

-- Table UNIDAD_MEDIDA

CREATE TABLE [UNIDAD_MEDIDA]
(
    [ID_UNIDAD_MEDIDA] Bigint IDENTITY NOT NULL,
    [NOMBRE]           Varchar(10)     NOT NULL,
    [ABREVIATURA]      Varchar(5)      NOT NULL
)
go

-- Add keys for table UNIDAD_MEDIDA

ALTER TABLE [UNIDAD_MEDIDA]
    ADD CONSTRAINT [Unique_Identifier8] PRIMARY KEY ([ID_UNIDAD_MEDIDA])
go

-- Table PROVEEDOR

CREATE TABLE [PROVEEDOR]
(
    [ID_PROVEEDOR] Bigint IDENTITY NOT NULL,
    [NOMBRE]       Varchar(30)     NOT NULL,
    [CONTACTO]     Varchar(50)     NOT NULL,
    [TELEFONO]     Char(9)         NOT NULL
)
go

-- Add keys for table PROVEEDOR

ALTER TABLE [PROVEEDOR]
    ADD CONSTRAINT [Unique_Identifier9] PRIMARY KEY ([ID_PROVEEDOR])
go

-- Table PROVEEDOR_PRODUCTO

CREATE TABLE [PROVEEDOR_PRODUCTO]
(
    [ID_PROVEEDOR] Bigint NOT NULL,
    [ID_PRODUCTO]  Bigint NOT NULL,
    [PRECIO]       Money  NOT NULL
)
go

-- Add keys for table PROVEEDOR_PRODUCTO

ALTER TABLE [PROVEEDOR_PRODUCTO]
    ADD CONSTRAINT [Unique_Identifier10] PRIMARY KEY ([ID_PROVEEDOR], [ID_PRODUCTO])
go

-- Table GRUPO

CREATE TABLE [GRUPO]
(
    [ID_GRUPO]    Bigint IDENTITY NOT NULL,
    [CODIGO]      Varchar(10)     NOT NULL,
    [ID_PROFESOR] Bigint          NOT NULL,
    [ID_CURSO]    Bigint          NOT NULL
)
go

-- Add keys for table GRUPO

ALTER TABLE [GRUPO]
    ADD CONSTRAINT [Unique_Identifier11] PRIMARY KEY ([ID_GRUPO])
go

-- Table CARGO_PERSONA

CREATE TABLE [CARGO_PERSONA]
(
    [ID_CARGO]   Bigint NOT NULL,
    [ID_PERSONA] Bigint NOT NULL
)
go

-- Add keys for table CARGO_PERSONA

ALTER TABLE [CARGO_PERSONA]
    ADD CONSTRAINT [Unique_Identifier12] PRIMARY KEY ([ID_CARGO], [ID_PERSONA])
go

-- Table PREPARACION

CREATE TABLE [PREPARACION]
(
    [ID_RECETA]   Bigint       NOT NULL,
    [ID_PASO]     Bigint       NOT NULL,
    [DESCRIPCION] VARCHAR(250) NOT NULL
)
go

-- Add keys for table PREPARACION

ALTER TABLE [PREPARACION]
    ADD CONSTRAINT [Unique_Identifier13] PRIMARY KEY ([ID_RECETA], [ID_PASO])
go

-- Table RECETAS_CURSOS

CREATE TABLE [RECETAS_CURSOS]
(
    [ID_RECETA] Bigint NOT NULL,
    [ID_CURSO]  Bigint NOT NULL
)
go

-- Table GRUPO_PERSONAS

CREATE TABLE [GRUPO_PERSONAS]
(
    [ID_GRUPO]   Bigint NOT NULL,
    [ID_PERSONA] Bigint NOT NULL
)
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [RECETAS]
    ADD CONSTRAINT [CATEGORIA_RECETA] FOREIGN KEY ([ID_CATEGORIA]) REFERENCES [CATEGORIAS] ([ID_CATEGORIA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [RECETAS]
    ADD CONSTRAINT [AUTOR_RECETA] FOREIGN KEY ([ID_PERSONA]) REFERENCES [PERSONAS] ([ID_PERSONA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [INGREDIENTES]
    ADD CONSTRAINT [INGREDIENTE_UNIDAD_MEDIDA] FOREIGN KEY ([ID_UNIDAD_MEDIDA]) REFERENCES [UNIDAD_MEDIDA] ([ID_UNIDAD_MEDIDA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [INGREDIENTES]
    ADD CONSTRAINT [PRODUCTO_INGREDIENTE] FOREIGN KEY ([ID_INGREDIENTE]) REFERENCES [PRODUCTOS] ([ID_PRODUCTO]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [INGREDIENTES]
    ADD CONSTRAINT [RECETA_INGREDIENTES] FOREIGN KEY ([ID_RECETA]) REFERENCES [RECETAS] ([ID_RECETA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PROVEEDOR_PRODUCTO]
    ADD CONSTRAINT [PROVEEDOR_PRECIO] FOREIGN KEY ([ID_PROVEEDOR]) REFERENCES [PROVEEDOR] ([ID_PROVEEDOR]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PROVEEDOR_PRODUCTO]
    ADD CONSTRAINT [PRODUCTO_PRECIO] FOREIGN KEY ([ID_PRODUCTO]) REFERENCES [PRODUCTOS] ([ID_PRODUCTO]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [GRUPO]
    ADD CONSTRAINT [CURSO_GRUPO] FOREIGN KEY ([ID_CURSO]) REFERENCES [CURSOS] ([ID_CURSO]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [GRUPO]
    ADD CONSTRAINT [GRUPO_PROFESOR] FOREIGN KEY ([ID_PROFESOR]) REFERENCES [PERSONAS] ([ID_PERSONA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [CARGO_PERSONA]
    ADD CONSTRAINT [CARGO_PERSONAS] FOREIGN KEY ([ID_CARGO]) REFERENCES [CARGOS] ([ID_CARGO]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [CARGO_PERSONA]
    ADD CONSTRAINT [PERSONAS_CARGO] FOREIGN KEY ([ID_PERSONA]) REFERENCES [PERSONAS] ([ID_PERSONA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PREPARACION]
    ADD CONSTRAINT [RECETA_PREPARACION] FOREIGN KEY ([ID_RECETA]) REFERENCES [RECETAS] ([ID_RECETA]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

-----------------------------------------------------------
--Procedimiento para obtener password a traves del username e iniciar sesion
CREATE PROCEDURE usp_GetByUsername @userName VARCHAR(15)
AS
BEGIN
    SELECT P.USERNAME, P.CONTRASENA
    FROM PERSONAS AS P
    WHERE P.USERNAME = @userName
END
GO

--Procedimiento para obtener todos los datos de la persona despues de iniciar sesion
CREATE PROCEDURE usp_GetPerson @username VARCHAR(15),
                               @contrasena VARCHAR(15)
AS
BEGIN
    SELECT ID_PERSONA,
           NOMBRES,
           APELLIDO_PATERNO,
           APELLIDO_MATERNO
    FROM PERSONAS AS P
    WHERE P.USERNAME = @username
      AND P.CONTRASENA = @contrasena
END
GO

--Procedimiento para obtener todas las recetas
CREATE PROCEDURE usp_GetRecipes
AS
BEGIN
    SELECT R.ID_RECETA, R.NOMBRE_RECETA, P.NOMBRES
    FROM RECETAS AS R
             JOIN PERSONAS AS P on R.ID_PERSONA = P.ID_PERSONA
END
GO

--Buscar recetas
CREATE PROCEDURE GetRecipeByLike @like Varchar(15) AS
BEGIN
    SELECT ID_RECETA, NOMBRE_RECETA
    FROM RECETAS
    WHERE NOMBRE_RECETA LIKE @like
END
GO

--buscar ingredientes
CREATE PROCEDURE GetIngredientByLike @like VARCHAR(15) AS
BEGIN
    SELECT ID_PRODUCTO, NOMBRE
    FROM PRODUCTOS
    WHERE NOMBRE LIKE @like
END
GO

--Procedimiento para agregar receta
CREATE PROCEDURE AddRecipe @nombre Varchar(30),
                           @descripcion Varchar(250),
                           @tiempo_preparacion Varchar(10),
                           @tiempo_coccion Varchar(10),
                           @porciones Smallint,
                           @dificultad Smallint,
                           @id_categoria Bigint,
                           @id_persona Bigint,
                           @ingredientes XML,
                           @preparacion XML
AS
BEGIN
    DECLARE @ID_Receta BIGINT;

    INSERT INTO RECETAS (NOMBRE_RECETA, DESCRIPCION, TIEMPO_PREPARACION, TIEMPO_COCCION, PORCIONES, DIFICULTAD,
                         ID_CATEGORIA, ID_PERSONA)
    VALUES (@nombre, @descripcion, @tiempo_preparacion, @tiempo_coccion, @porciones, @dificultad, @id_categoria,
            @id_persona);

    SET @ID_Receta = SCOPE_IDENTITY();

    INSERT INTO INGREDIENTES (ID_INGREDIENTE, CANTIDAD, ID_UNIDAD_MEDIDA, ID_RECETA)
    SELECT Tbl.Col.value('(ID)[1]', 'BIGINT'),
           Tbl.Col.value('(Cantidad)[1]', 'DECIMAL(10,2)'),
           Tbl.Col.value('(ID_UnidadMedida)[1]', 'BIGINT'),
           @ID_Receta
    FROM @ingredientes.nodes('/Ingredientes/Ingredientes') AS Tbl(Col);

    INSERT INTO PREPARACION (ID_RECETA, ID_PASO, DESCRIPCION)
    SELECT @ID_Receta,
           Tbl.Col.value('(ID)[1]', 'BIGINT'),
           Tbl.Col.value('(Descripcion)[1]', 'VARCHAR(250)')
    FROM @preparacion.nodes('/Preparacion/Paso') AS Tbl(Col);
END
GO

--Procedimiento para obtener una receta
CREATE PROCEDURE GetRecipe @IDReceta INT
AS
BEGIN
    SELECT ID_RECETA,
           NOMBRE_RECETA,
           Descripcion,
           Tiempo_Preparacion,
           Tiempo_Coccion,
           Porciones,
           Dificultad,
           ID_CATEGORIA,
           ID_PERSONA
    FROM RECETAS
    WHERE ID_RECETA = @IDReceta;

    SELECT i.ID_Ingrediente, i.Cantidad, u.Nombre AS Unidad_Medida
    FROM Ingredientes i
             INNER JOIN UNIDAD_MEDIDA u ON i.ID_Unidad_Medida = u.ID_UNIDAD_MEDIDA
    WHERE i.ID_Receta = @IDReceta;

    SELECT ID_PASO, Descripcion
    FROM PREPARACION
    WHERE ID_Receta = @IDReceta;
END
GO

--Procedimiento para actualizar la receta
CREATE PROCEDURE UpdateRecipe @idReceta INT,
                              @nombre Varchar(30),
                              @descripcion Varchar(250),
                              @tiempo_preparacion Varchar(10),
                              @tiempo_coccion Varchar(10),
                              @porciones Smallint,
                              @dificultad Smallint,
                              @id_categoria Bigint,
                              @id_persona Bigint,
                              @ingredientes XML,
                              @preparacion XML
AS
BEGIN
    UPDATE RECETAS
    SET NOMBRE_RECETA      = @nombre,
        descripcion        = @descripcion,
        tiempo_preparacion = @tiempo_preparacion,
        tiempo_coccion     = @tiempo_coccion,
        porciones          = @porciones,
        dificultad         = @dificultad,
        ID_CATEGORIA       = @id_categoria,
        ID_PERSONA         = @id_persona
    WHERE ID_RECETA = @idReceta;

    DELETE FROM Ingredientes WHERE ID_RECETA = @idReceta;

    INSERT INTO INGREDIENTES (ID_INGREDIENTE, CANTIDAD, ID_UNIDAD_MEDIDA, ID_RECETA)
    SELECT Tbl.Col.value('(ID)[1]', 'BIGINT'),
           Tbl.Col.value('(Cantidad)[1]', 'DECIMAL(10,2)'),
           Tbl.Col.value('(ID_UnidadMedida)[1]', 'BIGINT'),
           @idReceta
    FROM @ingredientes.nodes('/Ingredientes/Ingredientes') AS Tbl(Col);

    DELETE FROM Preparacion WHERE id_receta = @idReceta;

    INSERT INTO PREPARACION (ID_RECETA, ID_PASO, DESCRIPCION)
    SELECT @idReceta,
           Tbl.Col.value('(ID)[1]', 'BIGINT'),
           Tbl.Col.value('(Descripcion)[1]', 'VARCHAR(250)')
    FROM @preparacion.nodes('/Preparacion/Paso') AS Tbl(Col);
END
GO

--eliminar receta
CREATE PROCEDURE DeleteRecipe @idReceta INT
AS
BEGIN
    DELETE FROM INGREDIENTES WHERE id_receta = @idReceta;

    DELETE FROM PREPARACION WHERE id_receta = @idReceta;

    DELETE FROM RECETAS WHERE ID_RECETA = @idReceta;
END
GO

--Buscar chefs
CREATE PROCEDURE GetChefByLike @like Varchar(15) AS
BEGIN
    SELECT P.ID_PERSONA, P.NOMBRES, P.APELLIDO_PATERNO, p.APELLIDO_MATERNO
    FROM PERSONAS P
             JOIN CARGO_PERSONA CP on P.ID_PERSONA = CP.ID_PERSONA
    WHERE P.NOMBRES LIKE @like
      AND CP.ID_CARGO = 1
END
GO

--Buscar teacher
CREATE PROCEDURE GetTeacherByLike @like Varchar(15) AS
BEGIN
    SELECT P.ID_PERSONA, P.NOMBRES, P.APELLIDO_PATERNO, p.APELLIDO_MATERNO
    FROM PERSONAS P
             JOIN CARGO_PERSONA CP on P.ID_PERSONA = CP.ID_PERSONA
    WHERE P.NOMBRES LIKE @like
      AND CP.ID_CARGO = 2
END
GO

--Buscar alumno
CREATE PROCEDURE GetStudentByLike @like Varchar(15) AS
BEGIN
    SELECT P.ID_PERSONA, P.NOMBRES, P.APELLIDO_PATERNO, p.APELLIDO_MATERNO
    FROM PERSONAS P
             JOIN CARGO_PERSONA CP on P.ID_PERSONA = CP.ID_PERSONA
    WHERE P.NOMBRES LIKE @like
      AND CP.ID_CARGO = 3
END
GO

--seleccionar chef
CREATE PROCEDURE GetChefs AS
BEGIN
    SELECT CONCAT(P.NOMBRES, ' ', P.APELLIDO_PATERNO, ' ', P.APELLIDO_MATERNO)
    FROM PERSONAS P
             JOIN CARGO_PERSONA CP on P.ID_PERSONA = CP.ID_PERSONA
    WHERE CP.ID_CARGO = 1
END
GO

--añadir persona
CREATE PROCEDURE AddPerson @Nombre Varchar(30),
                           @ape_paterno Varchar(15),
                           @ap_materno Varchar(15),
                           @sexo Char(1),
                           @fecha_nacimiento Date,
                           @direccion Varchar(50),
                           @telefono Char(9),
                           @correo Varchar(50),
                           @username VARCHAR(15),
                           @contrasena VARCHAR(15),
                           @idCargo BIGINT
AS
BEGIN
    DECLARE @PersonaID BIGINT;

    INSERT INTO PERSONAS (NOMBRES, APELLIDO_PATERNO, APELLIDO_MATERNO, SEXO, FECHA_NACIMIENTO, DIRECCION, TELEFONO,
                          CORREO, USERNAME, CONTRASENA)
    VALUES (@Nombre, @ape_paterno, @ap_materno, @sexo, @fecha_nacimiento, @direccion, @telefono, @correo, @username,
            @contrasena);

    SET @PersonaID = SCOPE_IDENTITY();

    INSERT INTO CARGO_PERSONA (ID_CARGO, ID_PERSONA)
    VALUES (@idCargo, @PersonaID);
END
GO

--eliminar persona
CREATE PROCEDURE DeletePerson @idPersona BIGINT
AS
BEGIN
    DELETE FROM CARGO_PERSONA WHERE ID_PERSONA = @idPersona;
    DELETE FROM PERSONAS WHERE ID_PERSONA = @idPersona;
END
GO

--Obtener todos los cursos
CREATE PROCEDURE GetCourse AS
BEGIN
    SELECT NOMBRE
    FROM CURSOS
END
GO

--Añadir curso
CREATE PROCEDURE AddCourse @nombre Varchar(30),
                           @descripcion Varchar(250),
                           @inicio Varchar(15),
                           @fin Varchar(15),
                           @cupos Smallint,
                           @horario Varchar(150),
                           @costo Money,
                           @recetas XML
AS
BEGIN
    DECLARE @cursoID BIGINT;

    INSERT INTO CURSOS (NOMBRE, DESCRIPCION, FECHA_INICIO, FECHA_FIN, CUPOS, HORARIO, COSTO)
    VALUES (@nombre, @descripcion, @inicio, @fin, @cupos, @horario, @costo);

    INSERT INTO RECETAS_CURSOS (ID_RECETA, ID_CURSO)
    SELECT Tbl.Col.value('(ID)[1]', 'BIGINT'),
           @cursoID
    FROM @recetas.nodes('/Recetas/Recetas') AS Tbl(Col);
END
GO

--actualizar curso
CREATE PROCEDURE UpdateCourse @idCurso BIGINT,
                              @nombre Varchar(30),
                              @descripcion Varchar(250),
                              @inicio Varchar(15),
                              @fin Varchar(15),
                              @cupos Smallint,
                              @horario Varchar(150),
                              @costo Money,
                              @recetas XML
AS
BEGIN
    UPDATE CURSOS
    SET NOMBRE       = @nombre,
        DESCRIPCION  = @descripcion,
        FECHA_INICIO = @inicio,
        FECHA_FIN    = @fin,
        CUPOS        = @cupos,
        HORARIO      = @horario,
        COSTO        = @costo
    WHERE ID_CURSO = @idCurso;

    DELETE FROM RECETAS_CURSOS WHERE ID_CURSO = @idCurso;

    INSERT INTO RECETAS_CURSOS (ID_RECETA, ID_CURSO)
    SELECT Tbl.Col.value('(ID)[1]', 'BIGINT'),
           @idCurso
    FROM @recetas.nodes('/Recetas/Recetas') AS Tbl(Col);
END
GO

--Eliminar curso
CREATE PROCEDURE DeleteCourse @idCurso BIGINT
AS
BEGIN
    DELETE FROM RECETAS_CURSOS WHERE ID_CURSO = @idCurso;

    DELETE FROM CURSOS WHERE ID_CURSO = @idCurso;
END
go

insert into cargos (titulo, descripcion)
values ('Chef', 'Todos los chefs que crean recetas')
exec AddPerson 'Roberto', 'Apaza', 'Cornejo', 'M', '09/09/1997', 'suCasa 123', '987654321', 'sucorreo@email.com',
     'robap', '12345', 1
select *
from PERSONAS