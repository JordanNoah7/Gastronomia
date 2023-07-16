--Procedimiento para obtener password a traves del username e iniciar sesion
CREATE PROCEDURE usp_GetByUsername @userName VARCHAR(15)
AS
BEGIN
    SELECT P.USERNAME, P.CONTRASENA
    FROM PERSONAS AS P
    WHERE P.USERNAME = @userName
END
GO
----------------------------------------------------------------------------------------------------Listo
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
----------------------------------------------------------------------------------------------------Listo
--Procedimiento para obtener todas las recetas
CREATE PROCEDURE usp_GetRecipes
AS
BEGIN
    SELECT R.ID_RECETA     Nro,
           R.NOMBRE_RECETA Receta,
           P.NOMBRES       Autor
    FROM RECETAS AS R
             JOIN PERSONAS AS P on R.ID_PERSONA = P.ID_PERSONA
END
GO
----------------------------------------------------------------------------------------------------Listo
--Buscar chefs por like
ALTER PROCEDURE usp_GetChefByLike @like Varchar(15) AS
BEGIN
    SELECT P.ID_PERSONA,
           P.NOMBRES,
           P.APELLIDO_PATERNO,
           P.APELLIDO_MATERNO
    FROM PERSONAS P
             JOIN CARGO_PERSONA CP on P.ID_PERSONA = CP.ID_PERSONA
    WHERE CP.ID_CARGO = 1
      AND (P.NOMBRES LIKE '%' + @like + '%'
        OR P.APELLIDO_PATERNO LIKE '%' + @like + '%'
        OR P.APELLIDO_MATERNO LIKE '%' + @like + '%');
END
GO
----------------------------------------------------------------------------------------------------Listo
--obtener una lista de categorias para el combobox
CREATE PROCEDURE usp_GetCategories
AS
BEGIN
    SELECT C.ID_CATEGORIA,
           C.NOMBRE_CATEGORIA
    FROM CATEGORIAS C
END
GO
----------------------------------------------------------------------------------------------------Listo
--obtener una lista de unidades de medida para el combobox
alter PROCEDURE usp_GetUnitMeasure
AS
BEGIN
    SELECT UM.ID_UNIDAD_MEDIDA,
           UM.ABREVIATURA
    FROM UNIDAD_MEDIDA UM
END
GO
----------------------------------------------------------------------------------------------------Listo
--obtener una lista de productos para el datagridview
CREATE PROCEDURE usp_GetProducts
AS
BEGIN
    SELECT P.ID_PRODUCTO,
           P.NOMBRE
    FROM PRODUCTOS P
    WHERE P.STOCK > 0
END
GO
----------------------------------------------------------------------------------------------------Listo
--Creacion de tipo de dato para ingredientes
CREATE TYPE IngredientesTableType AS TABLE
(
    ID_INGREDIENTE   BIGINT,
    CANTIDAD         DECIMAL(10, 2),
    ID_UNIDAD_MEDIDA BIGINT
);
GO
----------------------------------------------------------------------------------------------------Listo
--Creacion de tipo de dato para pasos de preparacion
CREATE TYPE PreparacionTableType AS TABLE
(
    ID_PASO     BIGINT,
    DESCRIPCION VARCHAR(500)
);
GO
----------------------------------------------------------------------------------------------------Listo
--Procedimiento para agregar receta
CREATE PROCEDURE usp_AddRecipe @nombre Varchar(30),
                               @descripcion Varchar(250),
                               @tiempo_preparacion Varchar(10),
                               @tiempo_coccion Varchar(10),
                               @porciones Smallint,
                               @dificultad Smallint,
                               @id_categoria Bigint,
                               @id_persona Bigint,
                               @ingredientes IngredientesTableType READONLY,
                               @preparacion PreparacionTableType READONLY
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @ID_Receta BIGINT;

        INSERT INTO RECETAS (NOMBRE_RECETA, DESCRIPCION, TIEMPO_PREPARACION, TIEMPO_COCCION, PORCIONES, DIFICULTAD,
                             ID_CATEGORIA, ID_PERSONA)
        VALUES (@nombre, @descripcion, @tiempo_preparacion, @tiempo_coccion, @porciones, @dificultad, @id_categoria,
                @id_persona);

        SET @ID_Receta = SCOPE_IDENTITY();

        INSERT INTO INGREDIENTES (ID_INGREDIENTE, CANTIDAD, ID_UNIDAD_MEDIDA, ID_RECETA)
        SELECT ID_INGREDIENTE, CANTIDAD, ID_UNIDAD_MEDIDA, @ID_Receta
        FROM @ingredientes;

        INSERT INTO PREPARACION (ID_RECETA, ID_PASO, DESCRIPCION)
        SELECT @ID_Receta, ID_PASO, DESCRIPCION
        FROM @preparacion;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
----------------------------------------------------------------------------------------------------Listo
--eliminar receta
CREATE PROCEDURE usp_DeleteRecipe @idReceta INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DELETE FROM INGREDIENTES WHERE id_receta = @idReceta;

        DELETE FROM PREPARACION WHERE id_receta = @idReceta;

        DELETE FROM RECETAS WHERE ID_RECETA = @idReceta;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO
----------------------------------------------------------------------------------------------------Listo
--buscar ingredientes
CREATE PROCEDURE GetIngredientByLike @like VARCHAR(15) AS
BEGIN
    SELECT ID_PRODUCTO, NOMBRE
    FROM PRODUCTOS
    WHERE NOMBRE LIKE @like
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