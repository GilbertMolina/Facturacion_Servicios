--Crear Base de Datos

USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'BDServiciosABC')
	BEGIN
		ALTER DATABASE BDServiciosABC SET SINGLE_USER WITH ROLLBACK IMMEDIATE
		DROP DATABASE BDServiciosABC
	END
GO

CREATE DATABASE BDServiciosABC
GO

--Crear Tablas

USE [BDServiciosABC]
GO

CREATE TABLE TbPersona(
	PK_Correo			nchar(30) NOT NULL,
	Cedula				nvarchar(20) NOT NULL,
	Nombre				nvarchar(20) NOT NULL,
	Apellido1			nvarchar(20) NOT NULL,
	Apellido2			nvarchar(20) NOT NULL,
	FechaNacimiento		date NOT NULL,
	Direccion			nvarchar(50),
	Telefono			nchar(10) NOT NULL,
	Sexo				nchar(10) NOT NULL,
	Contrasena			nvarchar(30) NOT NULL,
	FK_IdRol			int NOT NULL,
	FK_IdEstado			int NOT NULL,
	CONSTRAINT PK_TbPersona_Correo PRIMARY KEY (PK_Correo),
	CONSTRAINT UC_TbPersona_Cedula UNIQUE(Cedula) 
)

CREATE TABLE TbRol(
	PK_IdRol		int IDENTITY(1,1) NOT NULL,
	Descripcion		nvarchar(50) NOT NULL,
	CONSTRAINT PK_TbRol_IdRol PRIMARY KEY (PK_IdRol)
)

CREATE TABLE TbEstado(
	PK_IdEstado		int IDENTITY(1,1) NOT NULL,
	Descripcion		nvarchar(20) NOT NULL,
	CONSTRAINT PK_TbEstado_IdEstado PRIMARY KEY (PK_IdEstado)
)

CREATE TABLE TbServicio(
	PK_IdServicio	int IDENTITY(1,1) NOT NULL,
	Descripcion		nvarchar(50) NOT NULL,
	PrecioUnitario	money NOT NULL,
	FK_IdImpuesto	int NOT NULL,
	FK_IdEstado		int NOT NULL
	CONSTRAINT PK_TbServicio_IdServicio PRIMARY KEY (PK_IdServicio)
)

CREATE TABLE TbImpuesto(
	PK_IdImpuesto	int IDENTITY(1,1) NOT NULL,
	Descripcion		nvarchar(50) NOT NULL,
	PorcentajeImpuesto	numeric(9,2) NOT NULL
	CONSTRAINT PK_TbImpuesto_IdImpuesto PRIMARY KEY (PK_IdImpuesto)
)

CREATE TABLE TbFactura(
	PK_IdFactura		int IDENTITY(1,1) NOT NULL,
	FK_Correo			nchar(30) NOT NULL,
	FechaEmision		date NOT NULL,
	FechaVencimiento	date,
	MontoTotal			money NOT NULL,
	MontoCancelado		money NOT NULL,
	SaldoActual			money NOT NULL,
	FK_IdEstado			int NOT NULL,
	CONSTRAINT PK_TbFactura_IdFactura PRIMARY KEY (PK_IdFactura)
)

CREATE TABLE TbDetalleFactura(
	PK_IdFactura			int NOT NULL,
	PK_IdDetalleFactura		int IDENTITY(1,1) NOT NULL,
	FK_IdServicio			int NOT NULL,
	PrecioUnitario			money NOT NULL,
	Cantidad				int NOT NULL,
	CONSTRAINT PK_TbDetFact_IdFact_IdDet PRIMARY KEY (PK_IdFactura,PK_IdDetalleFactura)
)

CREATE TABLE TbRecibo(
	PK_IdRecibo		int IDENTITY(1,1) NOT NULL,
	FechaEmision	date NOT NULL,
	FK_Correo		nchar(30) NOT NULL,
	Descripcion		nvarchar(20) NOT NULL,
	MontoTotal		money NOT NULL,
	FK_IdEstado		int NOT NULL,
	CONSTRAINT PK_TbRecibo_IdRecibo PRIMARY KEY (PK_IdRecibo)
)

CREATE TABLE TbDetalleRecibo(
	PK_IdRecibo			int NOT NULL,
	PK_IdDetalleRecibo	int IDENTITY(1,1) NOT NULL,
	FK_IdFactura		int NOT NULL,
	MontoCancelado		money NOT NULL,
	CONSTRAINT PK_TbDetRec_IdRec_IdDet PRIMARY KEY (PK_IdRecibo,PK_IdDetalleRecibo)
)

--Crear relaciones

ALTER TABLE TbPersona
	ADD CONSTRAINT FK_TbPersona_IdRol
	FOREIGN KEY (FK_IdRol)
	REFERENCES TbRol(PK_IdRol)
	
ALTER TABLE TbPersona
	ADD CONSTRAINT FK_TbPersona_IdEstado
	FOREIGN KEY (FK_IdEstado)
	REFERENCES TbEstado(PK_IdEstado)

ALTER TABLE TbServicio
	ADD CONSTRAINT FK_TbServicio_IdImpuesto
	FOREIGN KEY (FK_IdImpuesto)
	REFERENCES TbImpuesto(PK_IdImpuesto)
	
ALTER TABLE TbServicio
	ADD CONSTRAINT FK_TbServicio_IdEstado
	FOREIGN KEY (FK_IdEstado)
	REFERENCES TbEstado(PK_IdEstado)
	
ALTER TABLE TbFactura
	ADD CONSTRAINT FK_TbFactura_Correo
	FOREIGN KEY (FK_Correo)
	REFERENCES TbPersona(PK_Correo)
	
ALTER TABLE TbFactura
	ADD CONSTRAINT FK_TbFactura_IdEstado
	FOREIGN KEY (FK_IdEstado)
	REFERENCES TbEstado(PK_IdEstado)

ALTER TABLE TbDetalleFactura
	ADD CONSTRAINT FK_TbDetFact_IdServicio
	FOREIGN KEY (FK_IdServicio)
	REFERENCES TbServicio(PK_IdServicio)

ALTER TABLE TbDetalleFactura
	ADD CONSTRAINT FK_TbDetFact_IdFactura
	FOREIGN KEY (PK_IdFactura)
	REFERENCES TbFactura(PK_IdFactura)

ALTER TABLE TbRecibo
	ADD CONSTRAINT FK_TbRecibo_Correo
	FOREIGN KEY (FK_Correo)
	REFERENCES TbPersona(PK_Correo)
	
ALTER TABLE TbRecibo
	ADD CONSTRAINT FK_TbRecibo_IdEstado
	FOREIGN KEY (FK_IdEstado)
	REFERENCES TbEstado(PK_IdEstado)
	
ALTER TABLE TbDetalleRecibo
	ADD CONSTRAINT FK_TbDetRec_IdRecibo
	FOREIGN KEY (PK_IdRecibo)
	REFERENCES TbRecibo(PK_IdRecibo)
	
ALTER TABLE TbDetalleRecibo
	ADD CONSTRAINT FK_TbDetRec_IdFactura
	FOREIGN KEY (FK_IdFactura)
	REFERENCES TbFactura(PK_IdFactura)
	
--Crear inserciones de las tablas

--Tabla TbRol
INSERT INTO TbRol(Descripcion) VALUES 
('Super Administrador'), 
('Administrador'),
('Agente de cobros registro facturas'),
('Agente de cobros registro recibos'),
('Encargado seguimiento de cobros'),
('Cliente');

--Tabla TbEstado
INSERT INTO TbEstado(Descripcion) VALUES 
('Activo'),
('Inactivo'),
('Nuevo(a)'),
('Impreso(a)'),
('Anulado(a)');

--Tabla TbPersona
INSERT INTO TbPersona(PK_Correo, Cedula, Nombre, Apellido1, Apellido2, FechaNacimiento, Direccion, Telefono, Sexo, Contrasena, FK_IdRol, FK_IdEstado) VALUES 
('jeison812@gmail.com', '304370355', 'Jeison', 'Leandro', 'Hernández', '2008-08-08', 'Cartago', '89898989', 'M', '12345', 1, 1),
('gmolinac91@gmail.com', '304540214', 'Gilberth', 'Molina', 'Castrillo', '2008-08-08', 'Cartago', '77777777', 'M', '12345', 2, 1),
('milena@gmail.com', '109890765', 'Milena', 'Picado', 'Santamaria', '2008-08-08', 'San José', '66666666', 'F', '12345', 3, 1),
('johndoe@gmail.com', '505460657', 'John', 'Doe', 'Doe', '2008-08-08', 'Puntarenas', '88888888', 'M', '12345', 4, 1),
('jamesdoe@gmail.com', '206570153', 'James', 'Doe', 'Doe', '2008-08-08', 'Limon', '33333333', 'M', '12345', 5, 1),
('judiedoe@gmail.com', '606580841', 'Judie', 'Doe', 'Doe', '2008-08-08', 'Alajuela', '11111111', 'F', '12345', 6, 1),
('joedoe@gmail.com', '105650413', 'Joe', 'Doe', 'Doe', '2008-08-08', 'Heredia', '33333333', 'M', '12345', 6, 1);

--Tabla TbImpuesto
INSERT INTO TbImpuesto(Descripcion, PorcentajeImpuesto) VALUES 
('Impuesto de venta', 13),
('Valor agregado', 19),
('Exento de impuesto', 0);

--Tabla TbServicio
INSERT INTO TbServicio(Descripcion, PrecioUnitario, FK_IdImpuesto, FK_IdEstado) VALUES 
('Seguridad', 475000, 1, 1),
('Sevicio de limpieza', 275000, 2, 1),
('Vigilancia 24/7', 1275000, 3, 1);

--Tabla TbFactura
INSERT INTO TbFactura(FK_Correo, FechaEmision, FechaVencimiento, MontoTotal, MontoCancelado, SaldoActual, FK_IdEstado) VALUES 
('judiedoe@gmail.com', '08/07/2014', '08/08/2014', 1275000, 730000, 545000, 3),
('joedoe@gmail.com', '06/06/2014', '06/10/2014', 275000, 140000, 135000, 3);

--Tabla TbDetalleFactura
INSERT INTO TbDetalleFactura(PK_IdFactura, FK_IdServicio, PrecioUnitario, Cantidad) VALUES 
(1, 3, 1275000, 4),
(2, 2, 275000, 2);

--Tabla TbRecibo
INSERT INTO TbRecibo(FechaEmision, FK_Correo, Descripcion, MontoTotal, FK_IdEstado) VALUES 
('08/07/2014', 'judiedoe@gmail.com', 'Abono de cuenta', 10000, 1),
('03/07/2014', 'joedoe@gmail.com', 'Primer pago', 30000, 1);

--Tabla TbDetalleRecibo
INSERT INTO TbDetalleRecibo(PK_IdRecibo, FK_IdFactura, MontoCancelado) VALUES 
(1, 1, 150000),
(2, 2, 350000);
	
--Crear procedimientos almacenados

--Tabla TbDetalleFactura

IF OBJECT_ID('SP_TbReporteFacturas', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbReporteFacturas;
GO
CREATE PROCEDURE SP_TbReporteFacturas
	@PK_Correo	nchar(30)
AS
	SET NOCOUNT ON
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbFactura.FechaEmision,TbFactura.FechaVencimiento,TbFactura.PK_IdFactura,TbFactura.MontoTotal,TbFactura.MontoCancelado, 
           TbFactura.SaldoActual
	FROM   TbFactura INNER JOIN TbPersona ON TbFactura.FK_Correo = TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo  
GO

IF OBJECT_ID('SP_TbReporteFacturasxFecha', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbReporteFacturasxFecha;
GO
CREATE PROCEDURE SP_TbReporteFacturasxFecha
	@PK_Correo	nchar(30),
	@FechIni	date,
	@FechFin	date
AS
	SET NOCOUNT ON
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbFactura.FechaEmision,TbFactura.FechaVencimiento,TbFactura.PK_IdFactura,TbFactura.MontoTotal,TbFactura.MontoCancelado, 
           TbFactura.SaldoActual
	FROM   TbFactura INNER JOIN TbPersona ON TbFactura.FK_Correo = TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo AND TbFactura.FechaEmision BETWEEN @FechIni and @FechFin 
GO

IF OBJECT_ID('SP_TbDetalleFactura_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleFactura_Mostrar;
GO
CREATE PROCEDURE SP_TbDetalleFactura_Mostrar
	@PK_IdFactura	int
AS
	SET NOCOUNT ON
	SELECT df.PK_IdDetalleFactura 'Id Detalle', df.PK_IdFactura 'Id Factura', s.Descripcion 'Servicio', df.PrecioUnitario 'Precio Unitario', df.Cantidad
	FROM TbDetalleFactura df, TbServicio s
	WHERE s.PK_IdServicio = df.FK_IdServicio
	AND PK_IdFactura = @PK_IdFactura
GO

IF OBJECT_ID('SP_TbDetalleFactura_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleFactura_Buscar;
GO
CREATE PROCEDURE SP_TbDetalleFactura_Buscar
	@PK_IdFactura			int,
	@PK_IdDetalleFactura	int
AS
	SET NOCOUNT ON
	SELECT PK_IdDetalleFactura, PK_IdFactura, FK_IdServicio, PrecioUnitario, Cantidad
	FROM TbDetalleFactura
	WHERE PK_IdFactura = @PK_IdFactura
	AND PK_IdDetalleFactura = @PK_IdDetalleFactura
GO

IF OBJECT_ID('SP_TbDetalleFactura_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleFactura_Insertar;
GO
CREATE PROCEDURE SP_TbDetalleFactura_Insertar
	@PK_IdFactura		int,
	@FK_IdServicio		int,
	@PrecioUnitario		money,
	@Cantidad			int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbDetalleFactura(PK_IdFactura, FK_IdServicio, PrecioUnitario, Cantidad)
	VALUES (@PK_IdFactura, @FK_IdServicio, @PrecioUnitario, @Cantidad)
	COMMIT
GO

IF OBJECT_ID('SP_TbDetalleFactura_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleFactura_Actualizar;
GO
CREATE PROCEDURE SP_TbDetalleFactura_Actualizar
	@PK_IdDetalleFactura	int,
	@PK_IdFactura			int,
	@FK_IdServicio			int,
	@PrecioUnitario			money,
	@Cantidad				int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbDetalleFactura
	SET FK_IdServicio = @FK_IdServicio, PrecioUnitario = @PrecioUnitario, Cantidad = @Cantidad
	WHERE PK_IdFactura = @PK_IdFactura
	AND PK_IdDetalleFactura = @PK_IdDetalleFactura
	COMMIT
GO

IF OBJECT_ID('SP_TbDetalleFactura_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleFactura_Eliminar;
GO
CREATE PROCEDURE SP_TbDetalleFactura_Eliminar
	@PK_IdFactura			int,
	@PK_IdDetalleFactura	int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbDetalleFactura
	WHERE PK_IdFactura = @PK_IdFactura
	AND PK_IdDetalleFactura = @PK_IdDetalleFactura
	COMMIT
GO

--Tabla TbPersona

IF OBJECT_ID('SP_TbPersona_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Mostrar;
GO
CREATE PROCEDURE SP_TbPersona_Mostrar
AS
	SET NOCOUNT ON
	SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
	FROM TbPersona p, TbRol r, TbEstado e
	WHERE r.PK_IdRol = p.FK_IdRol
	AND e.PK_IdEstado = p.FK_IdEstado
	ORDER BY p.PK_Correo
GO

IF OBJECT_ID('SP_TbPersona_MostrarFiltrado', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_MostrarFiltrado;
GO
CREATE PROCEDURE SP_TbPersona_MostrarFiltrado
	@Cedula				nvarchar(20),
	@NombreCompleto		nvarchar(60)
AS
	SET NOCOUNT ON
	IF (@Cedula <> '' And @NombreCompleto <> '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
			AND p.Cedula like '%' + @Cedula + '%'
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
	ELSE IF (@Cedula <> '' And @NombreCompleto = '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
			AND p.Cedula like '%' + @Cedula + '%'
		END
	ELSE IF (@Cedula = '' And @NombreCompleto <> '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
	ELSE IF (@Cedula = '' And @NombreCompleto = '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
		END
GO

IF OBJECT_ID('SP_TbPersona_MostrarClientesFiltrado', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_MostrarClientesFiltrado;
GO
CREATE PROCEDURE SP_TbPersona_MostrarClientesFiltrado
	@Cedula				nvarchar(20),
	@NombreCompleto		nvarchar(60)
AS
	SET NOCOUNT ON
	IF (@Cedula <> '' And @NombreCompleto <> '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
			AND r.Descripcion = 'Cliente'
			AND p.Cedula like '%' + @Cedula + '%'
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
	ELSE IF (@Cedula <> '' And @NombreCompleto = '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND e.PK_IdEstado = p.FK_IdEstado
			AND r.Descripcion = 'Cliente'
			AND p.Cedula like '%' + @Cedula + '%'
		END
	ELSE IF (@Cedula = '' And @NombreCompleto <> '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND r.Descripcion = 'Cliente'
			AND e.PK_IdEstado = p.FK_IdEstado
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
	ELSE IF (@Cedula = '' And @NombreCompleto = '')
		BEGIN
			SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
			FROM TbPersona p, TbRol r, TbEstado e
			WHERE r.PK_IdRol = p.FK_IdRol
			AND r.Descripcion = 'Cliente'
			AND e.PK_IdEstado = p.FK_IdEstado
		END
GO

IF OBJECT_ID('SP_TbPersona_MostrarClientes', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_MostrarClientes;
GO
CREATE PROCEDURE SP_TbPersona_MostrarClientes
AS
	SET NOCOUNT ON
	SELECT p.PK_Correo 'Correo', p.Cedula, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Completo', p.FechaNacimiento 'Fecha de Nacimiento', p.Direccion 'Dirección', p.Telefono 'Teléfono', p.Sexo, p.Contrasena 'Contraseña', r.Descripcion 'Id Rol', e.Descripcion 'Id Estado'
	FROM TbPersona p, TbRol r, TbEstado e
	WHERE r.PK_IdRol = p.FK_IdRol
	AND e.PK_IdEstado = p.FK_IdEstado
	AND r.Descripcion = 'Cliente'
	ORDER BY p.PK_Correo
GO

IF OBJECT_ID('SP_TbPersona_Login', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Login;
GO
CREATE PROCEDURE SP_TbPersona_Login
	@PK_Correo		nchar(30),
	@Contrasena		nvarchar(30)
AS
	SET NOCOUNT ON
	SELECT PK_Correo, Cedula, Nombre, Apellido1, Apellido2, FechaNacimiento, Direccion, Telefono, Sexo, Contrasena, FK_IdRol, FK_IdEstado
	FROM TbPersona
	WHERE PK_Correo = @PK_Correo
	AND Contrasena = @Contrasena
GO

IF OBJECT_ID('SP_TbPersona_Busqueda_Mantenimiento', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Busqueda_Mantenimiento;
GO
CREATE PROCEDURE SP_TbPersona_Busqueda_Mantenimiento
	@PK_Correo	nchar(30),
	@Cedula		nvarchar(20)
AS
	SET NOCOUNT ON
	SELECT PK_Correo, Cedula, Nombre, Apellido1, Apellido2, FechaNacimiento, Direccion, Telefono, Sexo, Contrasena, FK_IdRol, FK_IdEstado
	FROM TbPersona
	WHERE PK_Correo = @PK_Correo
	OR Cedula = @Cedula
GO

IF OBJECT_ID('SP_TbPersona_RecordarContrasena', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_RecordarContrasena;
GO
CREATE PROCEDURE SP_TbPersona_RecordarContrasena
	@PK_Correo	nchar(30),
	@Cedula		nvarchar(20)
AS
	SET NOCOUNT ON
	SELECT PK_Correo, Cedula, Nombre, Apellido1, Apellido2, FechaNacimiento, Direccion, Telefono, Sexo, Contrasena, FK_IdRol, FK_IdEstado
	FROM TbPersona
	WHERE PK_Correo = @PK_Correo
	AND Cedula = @Cedula
GO

IF OBJECT_ID('SP_TbPersona_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Insertar;
GO
CREATE PROCEDURE SP_TbPersona_Insertar
	@PK_Correo			nchar(30),
	@Cedula				nvarchar(20),
	@Nombre				nvarchar(20),
	@Apellido1			nvarchar(20),
	@Apellido2			nvarchar(20),
	@FechaNacimiento	date,
	@Direccion			nvarchar(50),
	@Telefono			nchar(10),
	@Sexo				nchar(10),
	@Contrasena			nvarchar(30),
	@FK_IdRol			int,
	@FK_IdEstado		int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbPersona(PK_Correo, Cedula, Nombre, Apellido1, Apellido2, FechaNacimiento, Direccion, Telefono, Sexo, Contrasena, FK_IdRol, FK_IdEstado)
	VALUES (@PK_Correo, @Cedula, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @Direccion, @Telefono, @Sexo, @Contrasena, @FK_IdRol, @FK_IdEstado)
	COMMIT
GO

IF OBJECT_ID('SP_TbPersona_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Actualizar;
GO
CREATE PROCEDURE SP_TbPersona_Actualizar
	@PK_Correo			nchar(30),
	@Cedula				nvarchar(20),
	@Nombre				nvarchar(20),
	@Apellido1			nvarchar(20),
	@Apellido2			nvarchar(20),
	@FechaNacimiento	date,
	@Direccion			nvarchar(50),
	@Telefono			nchar(10),
	@Sexo				nchar(10),
	@FK_IdRol			int,
	@FK_IdEstado		int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbPersona
	SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion, 
		Telefono = @Telefono, Sexo = @Sexo, FK_IdRol = @FK_IdRol, FK_IdEstado = @FK_IdEstado
	WHERE PK_Correo = @PK_Correo
	AND Cedula = @Cedula
	COMMIT
GO

IF OBJECT_ID('SP_TbPersona_ActualizarContrasena', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_ActualizarContrasena;
GO
CREATE PROCEDURE SP_TbPersona_ActualizarContrasena
	@PK_Correo			nchar(30),
	@Contrasena			nvarchar(30)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbPersona
	SET Contrasena = @Contrasena
	WHERE PK_Correo = @PK_Correo
	COMMIT
GO

IF OBJECT_ID('SP_TbPersona_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbPersona_Eliminar;
GO
CREATE PROCEDURE SP_TbPersona_Eliminar
	@PK_Correo	nchar(30),
	@Cedula		nvarchar(20)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbPersona
	WHERE PK_Correo = @PK_Correo
	AND Cedula = @Cedula
	COMMIT
GO

--Tabla TbRol

IF OBJECT_ID('SP_TbRol_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRol_Mostrar;
GO
CREATE PROCEDURE SP_TbRol_Mostrar
AS
	SET NOCOUNT ON
	SELECT PK_IdRol 'ID Rol', Descripcion 'Descripción'
	FROM TbRol
GO

IF OBJECT_ID('SP_TbRol_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRol_Buscar;
GO
CREATE PROCEDURE SP_TbRol_Buscar
	@PK_IdRol int
AS
	SET NOCOUNT ON
	SELECT PK_IdRol, Descripcion
	FROM TbRol
	WHERE PK_IdRol = @PK_IdRol	
GO

IF OBJECT_ID('SP_TbRol_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRol_Insertar;
GO
CREATE PROCEDURE SP_TbRol_Insertar
	@PK_IdRol int,
	@Descripcion nvarchar(20)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbRol(PK_IdRol, Descripcion)
	VALUES (@PK_IdRol, @Descripcion)
	COMMIT
GO

IF OBJECT_ID('SP_TbRol_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRol_Actualizar;
GO
CREATE PROCEDURE SP_TbRol_Actualizar
	@PK_IdRol int,
	@Descripcion nvarchar(20)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbRol
	SET Descripcion = @Descripcion
	WHERE PK_IdRol = @PK_IdRol	
	COMMIT
GO

IF OBJECT_ID('SP_TbRol_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRol_Eliminar;
GO
CREATE PROCEDURE SP_TbRol_Eliminar
	@PK_IdRol int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbRol
	WHERE PK_IdRol = @PK_IdRol	
	COMMIT
GO

--Tabla TbEstado

IF OBJECT_ID('SP_TbEstado_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbEstado_Mostrar;
GO
CREATE PROCEDURE SP_TbEstado_Mostrar
AS
	SET NOCOUNT ON
	SELECT PK_IdEstado 'Id Estado', Descripcion 'Descripción'
	FROM TbEstado
GO

IF OBJECT_ID('SP_TbEstado_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbEstado_Buscar;
GO
CREATE PROCEDURE SP_TbEstado_Buscar
	@PK_IdEstado int
AS
	SET NOCOUNT ON
	SELECT PK_IdEstado, Descripcion
	FROM TbEstado
	WHERE PK_IdEstado = @PK_IdEstado
GO

IF OBJECT_ID('SP_TbEstado_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbEstado_Insertar;
GO
CREATE PROCEDURE SP_TbEstado_Insertar
	@Descripcion nvarchar(20)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbEstado(Descripcion)
	VALUES (@Descripcion)
	COMMIT
GO

IF OBJECT_ID('SP_TbEstado_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbEstado_Actualizar;
GO
CREATE PROCEDURE SP_TbEstado_Actualizar
	@PK_IdEstado	int,
	@Descripcion	nvarchar(20)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbEstado
	SET Descripcion = @Descripcion
	WHERE PK_IdEstado = @PK_IdEstado
	COMMIT
GO

IF OBJECT_ID('SP_TbEstado_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbEstado_Eliminar;
GO
CREATE PROCEDURE SP_TbEstado_Eliminar
	@PK_IdEstado	int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbEstado
	WHERE PK_IdEstado = @PK_IdEstado
	COMMIT
GO

--Tabla TbServicio

IF OBJECT_ID('SP_TbServicio_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_Mostrar;
GO
CREATE PROCEDURE SP_TbServicio_Mostrar
AS
	SET NOCOUNT ON
	SELECT s.PK_IdServicio 'Id Servicio', s.Descripcion 'Descripción', s.PrecioUnitario 'Precio Unitario', i.Descripcion 'Impuesto', i.PorcentajeImpuesto 'Porcentaje Impuesto', e.Descripcion 'Estado'
	FROM TbServicio s, TbImpuesto i, TbEstado e
	WHERE i.PK_IdImpuesto = s.FK_IdImpuesto
	AND e.PK_IdEstado = s.FK_IdEstado
GO

IF OBJECT_ID('SP_TbServicio_MostrarFiltrado', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_MostrarFiltrado;
GO
CREATE PROCEDURE SP_TbServicio_MostrarFiltrado
	@Descripcion			nvarchar(50),
	@PrecioUnitario     	money
AS
	SET NOCOUNT ON
	IF (@Descripcion <> '' And @PrecioUnitario <> 0)
		BEGIN
			SELECT s.PK_IdServicio 'Id Servicio', s.Descripcion 'Descripción', s.PrecioUnitario 'Precio Unitario', i.Descripcion 'Impuesto', i.PorcentajeImpuesto 'Porcentaje Impuesto', e.Descripcion 'Estado'
			FROM TbServicio s, TbImpuesto i, TbEstado e
			WHERE i.PK_IdImpuesto = s.FK_IdImpuesto
			AND e.PK_IdEstado = s.FK_IdEstado
			AND s.Descripcion like '%' + @Descripcion + '%'
			AND PrecioUnitario = @PrecioUnitario AND s.FK_IdImpuesto = i.PK_IdImpuesto and s.FK_IdEstado = e.PK_IdEstado
		END
	ELSE IF (@Descripcion <> '' And @PrecioUnitario = 0)
		BEGIN
			SELECT s.PK_IdServicio 'Id Servicio', s.Descripcion 'Descripción', s.PrecioUnitario 'Precio Unitario', i.Descripcion 'Impuesto', i.PorcentajeImpuesto 'Porcentaje Impuesto', e.Descripcion 'Estado'
			FROM TbServicio s, TbImpuesto i, TbEstado e
			WHERE i.PK_IdImpuesto = s.FK_IdImpuesto
			AND e.PK_IdEstado = s.FK_IdEstado
			AND s.Descripcion like '%' + @Descripcion + '%' AND s.FK_IdImpuesto = i.PK_IdImpuesto and s.FK_IdEstado = e.PK_IdEstado
		END
	ELSE IF (@Descripcion = '' And @PrecioUnitario <> 0)
		BEGIN
			SELECT s.PK_IdServicio 'Id Servicio', s.Descripcion 'Descripción', s.PrecioUnitario 'Precio Unitario', i.Descripcion 'Impuesto', i.PorcentajeImpuesto 'Porcentaje Impuesto', e.Descripcion 'Estado'
			FROM TbServicio s, TbImpuesto i, TbEstado e
			WHERE i.PK_IdImpuesto = s.FK_IdImpuesto
			AND e.PK_IdEstado = s.FK_IdEstado
			AND s.PrecioUnitario = @PrecioUnitario AND s.FK_IdImpuesto = i.PK_IdImpuesto and s.FK_IdEstado = e.PK_IdEstado
		END
	ELSE IF (@Descripcion = '' And @PrecioUnitario = '')
		BEGIN
			SELECT s.PK_IdServicio 'Id Servicio', s.Descripcion 'Descripción', s.PrecioUnitario 'Precio Unitario', i.Descripcion 'Impuesto', i.PorcentajeImpuesto 'Porcentaje Impuesto', e.Descripcion 'Estado'
			FROM TbServicio s, TbImpuesto i, TbEstado e
			WHERE i.PK_IdImpuesto = s.FK_IdImpuesto
			AND e.PK_IdEstado = s.FK_IdEstado
		END
GO

IF OBJECT_ID('SP_TbServicio_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_Buscar;
GO
CREATE PROCEDURE SP_TbServicio_Buscar
	@PK_IdServicio int
AS
	SET NOCOUNT ON
	SELECT PK_IdServicio, Descripcion, PrecioUnitario, FK_IdImpuesto, FK_IdEstado
	FROM TbServicio
	WHERE PK_IdServicio = @PK_IdServicio	
GO

IF OBJECT_ID('SP_TbServicio_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_Insertar;
GO
CREATE PROCEDURE SP_TbServicio_Insertar	
	@Descripcion nvarchar(50),
	@PrecioUnitario money,
	@FK_IdImpuesto int, 
	@FK_IdEstado int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbServicio(Descripcion, PrecioUnitario, FK_IdImpuesto, FK_IdEstado)
	VALUES (@Descripcion, @PrecioUnitario, @FK_IdImpuesto, @FK_IdEstado)
	COMMIT
GO

IF OBJECT_ID('SP_TbServicio_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_Actualizar;
GO
CREATE PROCEDURE SP_TbServicio_Actualizar
	@PK_IdServicio int,
	@Descripcion nvarchar(50),
	@PrecioUnitario money,
	@FK_IdImpuesto int, 
	@FK_IdEstado int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbServicio
	SET Descripcion = @Descripcion, PrecioUnitario = @PrecioUnitario, 
		FK_IdImpuesto = @FK_IdImpuesto, FK_IdEstado = @FK_IdEstado
	WHERE PK_IdServicio = @PK_IdServicio	
	COMMIT
GO

IF OBJECT_ID('SP_TbServicio_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbServicio_Eliminar;
GO
CREATE PROCEDURE SP_TbServicio_Eliminar
	@PK_IdServicio int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbServicio
	WHERE PK_IdServicio = @PK_IdServicio	
	COMMIT
GO

--Tabla TbImpuesto

IF OBJECT_ID('SP_TbImpuesto_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_Mostrar;
GO
CREATE PROCEDURE SP_TbImpuesto_Mostrar
AS
	SET NOCOUNT ON
	SELECT PK_IdImpuesto 'ID Impuesto', Descripcion 'Descripción', PorcentajeImpuesto 'Porcentaje Impuesto'
	FROM TbImpuesto
GO

IF OBJECT_ID('SP_TbImpuesto_MostrarFiltrado', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_MostrarFiltrado;
GO
CREATE PROCEDURE SP_TbImpuesto_MostrarFiltrado
	@Descripcion			nvarchar(50),
	@PorcentajeImpuesto		numeric(9,2)
AS
	SET NOCOUNT ON
	IF (@Descripcion <> '' And @PorcentajeImpuesto <> 0)
		BEGIN
			SELECT PK_IdImpuesto 'ID Impuesto', Descripcion 'Descripción', PorcentajeImpuesto 'Porcentaje Impuesto'
			FROM TbImpuesto
			WHERE Descripcion like '%' + @Descripcion + '%'
			AND PorcentajeImpuesto = @PorcentajeImpuesto
		END
	ELSE IF (@Descripcion <> '' And @PorcentajeImpuesto = 0)
		BEGIN
			SELECT PK_IdImpuesto 'ID Impuesto', Descripcion 'Descripción', PorcentajeImpuesto 'Porcentaje Impuesto'
			FROM TbImpuesto
			WHERE Descripcion like '%' + @Descripcion + '%'
		END
	ELSE IF (@Descripcion = '' And @PorcentajeImpuesto <> 0)
		BEGIN
			SELECT PK_IdImpuesto 'ID Impuesto', Descripcion 'Descripción', PorcentajeImpuesto 'Porcentaje Impuesto'
			FROM TbImpuesto
			WHERE PorcentajeImpuesto = @PorcentajeImpuesto
		END
	ELSE IF (@Descripcion = '' And @PorcentajeImpuesto = 0)
		BEGIN
			SELECT PK_IdImpuesto 'ID Impuesto', Descripcion 'Descripción', PorcentajeImpuesto 'Porcentaje Impuesto'
			FROM TbImpuesto
		END
GO

IF OBJECT_ID('SP_TbImpuesto_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_Buscar;
GO
CREATE PROCEDURE SP_TbImpuesto_Buscar
	@PK_IdImpuesto int
AS
	SET NOCOUNT ON
	SELECT PK_IdImpuesto, Descripcion, PorcentajeImpuesto
	FROM TbImpuesto
	WHERE PK_IdImpuesto = @PK_IdImpuesto	
GO

IF OBJECT_ID('SP_TbImpuesto_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_Insertar;
GO
CREATE PROCEDURE SP_TbImpuesto_Insertar
	@Descripcion nvarchar(50),
	@PorcentajeImpuesto numeric(9,2)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbImpuesto(Descripcion, PorcentajeImpuesto)
	VALUES (@Descripcion, @PorcentajeImpuesto)
	COMMIT
GO

IF OBJECT_ID('SP_TbImpuesto_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_Actualizar;
GO
CREATE PROCEDURE SP_TbImpuesto_Actualizar
	@PK_IdImpuesto int,
	@Descripcion nvarchar(50),
	@PorcentajeImpuesto numeric(9,2)
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbImpuesto
	SET Descripcion = @Descripcion, PorcentajeImpuesto = @PorcentajeImpuesto
	WHERE PK_IdImpuesto = @PK_IdImpuesto	
	COMMIT
GO

IF OBJECT_ID('SP_TbImpuesto_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbImpuesto_Eliminar;
GO
CREATE PROCEDURE SP_TbImpuesto_Eliminar
	@PK_IdImpuesto int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbImpuesto
	WHERE PK_IdImpuesto = @PK_IdImpuesto	
	COMMIT
GO

--Tabla TbFactura

IF OBJECT_ID('SP_TbFactura_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_Mostrar;
GO
CREATE PROCEDURE SP_TbFactura_Mostrar
	@TipoFactura	int
AS
	SET NOCOUNT ON
	SELECT f.PK_IdFactura 'Id Factura', f.FK_Correo 'Correo', p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Cliente', f.FechaEmision 'Fecha de Emisión', f.FechaVencimiento 'Fecha de Vencimiento', f.MontoTotal 'Monto Total', f.MontoCancelado 'Monto Cancelado', f.SaldoActual 'Saldo Actual', e.Descripcion 'Estado'
	FROM TbFactura f, dbo.TbPersona p, TbEstado e 
	WHERE p.PK_Correo = f.FK_Correo
	AND e.PK_IdEstado = f.FK_IdEstado
	ANd f.FK_IdEstado = @TipoFactura
GO

IF OBJECT_ID('SP_TbFactura_MostrarFiltrado', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_MostrarFiltrado;
GO
CREATE PROCEDURE SP_TbFactura_MostrarFiltrado
	@PK_IdFactura           int,
	@NombreCompleto         nvarchar(60)
        
AS
	SET NOCOUNT ON
	IF (@PK_IdFactura <> 0 And @NombreCompleto <> '')
		BEGIN
			SELECT f.PK_IdFactura 'Id Factura', f.FK_Correo 'Correo', p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Cliente', f.FechaEmision 'Fecha de Emisión', f.FechaVencimiento 'Fecha de Vencimiento', f.MontoTotal 'Monto Total', f.MontoCancelado 'Monto Cancelado', f.SaldoActual 'Saldo Actual', e.Descripcion 'Estado'
			FROM TbFactura f, dbo.TbPersona p, TbEstado e 
			WHERE p.PK_Correo = f.FK_Correo
			AND e.PK_IdEstado = f.FK_IdEstado
			AND f.PK_IdFactura = @PK_IdFactura
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
    ELSE IF (@PK_IdFactura <> 0 And @NombreCompleto = '')
        BEGIN
			SELECT f.PK_IdFactura 'Id Factura', f.FK_Correo 'Correo', p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Cliente', f.FechaEmision 'Fecha de Emisión', f.FechaVencimiento 'Fecha de Vencimiento', f.MontoTotal 'Monto Total', f.MontoCancelado 'Monto Cancelado', f.SaldoActual 'Saldo Actual', e.Descripcion 'Estado'
			FROM TbFactura f, dbo.TbPersona p, TbEstado e 
			WHERE p.PK_Correo = f.FK_Correo
			AND e.PK_IdEstado = f.FK_IdEstado
			AND f.PK_IdFactura = @PK_IdFactura
        END
    ELSE IF (@PK_IdFactura = 0 And @NombreCompleto <> '')
		BEGIN
			SELECT f.PK_IdFactura 'Id Factura', f.FK_Correo 'Correo', p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Cliente', f.FechaEmision 'Fecha de Emisión', f.FechaVencimiento 'Fecha de Vencimiento', f.MontoTotal 'Monto Total', f.MontoCancelado 'Monto Cancelado', f.SaldoActual 'Saldo Actual', e.Descripcion 'Estado'
			FROM TbFactura f, dbo.TbPersona p, TbEstado e 
			WHERE p.PK_Correo = f.FK_Correo
			AND e.PK_IdEstado = f.FK_IdEstado
			AND p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 like '%' + @NombreCompleto + '%'
		END
    ELSE IF (@PK_IdFactura = 0 And @NombreCompleto = '')
		BEGIN
			SELECT f.PK_IdFactura 'Id Factura', f.FK_Correo 'Correo', p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 'Nombre Cliente', f.FechaEmision 'Fecha de Emisión', f.FechaVencimiento 'Fecha de Vencimiento', f.MontoTotal 'Monto Total', f.MontoCancelado 'Monto Cancelado', f.SaldoActual 'Saldo Actual', e.Descripcion 'Estado'
			FROM TbFactura f, dbo.TbPersona p, TbEstado e 
			WHERE p.PK_Correo = f.FK_Correo
			AND e.PK_IdEstado = f.FK_IdEstado
		END
GO

IF OBJECT_ID('SP_TbFactura_Busqueda_Mantenimiento', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_Busqueda_Mantenimiento;
GO
CREATE PROCEDURE SP_TbFactura_Busqueda_Mantenimiento
	@PK_IdFactura int
AS
	SET NOCOUNT ON
	SELECT PK_IdFactura, FK_Correo, FechaEmision, FechaVencimiento, MontoTotal, MontoCancelado, SaldoActual, FK_IdEstado
	FROM TbFactura
	WHERE PK_IdFactura = @PK_IdFactura 
GO

IF OBJECT_ID('SP_TbFactura_NumeroFacturaSiguiente', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_NumeroFacturaSiguiente;
GO
CREATE PROCEDURE SP_TbFactura_NumeroFacturaSiguiente
AS
	SET NOCOUNT ON
	SELECT MAX(PK_IdFactura)+1 as 'NumeroFacturaSiguiente'
	FROM TbFactura
GO

IF OBJECT_ID('SP_TbFactura_TotalFactura', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_TotalFactura;
GO
CREATE PROCEDURE SP_TbFactura_TotalFactura
	@PK_IdFactura int
AS
	SET NOCOUNT ON
	SELECT SUM(PrecioUnitario) as 'Total Factura'
	FROM TbDetalleFactura
	WHERE PK_IdFactura = @PK_IdFactura
GO

IF OBJECT_ID('SP_TbFactura_ActualizarMontoTotal', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_ActualizarMontoTotal;
GO
CREATE PROCEDURE SP_TbFactura_ActualizarMontoTotal
	@PK_IdFactura	int,
	@MontoTotal		money
AS
	SET NOCOUNT ON
	UPDATE TbFactura
	SET MontoTotal = @MontoTotal
    WHERE PK_IdFactura = @PK_IdFactura
GO

IF OBJECT_ID('SP_TbFactura_InsertarConFechaVencimiento', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_InsertarConFechaVencimiento;
GO
CREATE PROCEDURE SP_TbFactura_InsertarConFechaVencimiento
	@FK_Correo              nchar(30),
	@FechaEmision           date,
	@FechaVencimiento       date,
	@MontoTotal             money,
	@MontoCancelado         money,
	@SaldoActual            money,
	@FK_IdEstado            int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbFactura(FK_Correo, FechaEmision, FechaVencimiento, MontoTotal, MontoCancelado, SaldoActual, FK_IdEstado)
	VALUES (@FK_Correo, @FechaEmision, @FechaVencimiento, @MontoTotal, @MontoCancelado, @SaldoActual, @FK_IdEstado)
	COMMIT
GO

IF OBJECT_ID('SP_TbFactura_InsertarSinFechaVencimiento', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_InsertarSinFechaVencimiento;
GO
CREATE PROCEDURE SP_TbFactura_InsertarSinFechaVencimiento
	@FK_Correo              nchar(30),
	@FechaEmision           date,
	@MontoTotal             money,
	@MontoCancelado         money,
	@SaldoActual            money,
	@FK_IdEstado            int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbFactura(FK_Correo, FechaEmision, MontoTotal, MontoCancelado, SaldoActual, FK_IdEstado)
	VALUES (@FK_Correo, @FechaEmision, @MontoTotal, @MontoCancelado, @SaldoActual, @FK_IdEstado)
	COMMIT
GO

IF OBJECT_ID('SP_TbFactura_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_Actualizar;
GO
CREATE PROCEDURE SP_TbFactura_Actualizar
	@PK_IdFactura           int,
	@FK_Correo              nchar(30),
	@FechaEmision           date,
    @FechaVencimiento       date,
    @MontoTotal             money,
	@MontoCancelado         money,
    @SaldoActual            money,
    @FK_IdEstado            int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbFactura
	SET FK_Correo = @FK_Correo, FechaEmision = @FechaEmision, FechaVencimiento = @FechaVencimiento, 
		MontoTotal = @MontoTotal, MontoCancelado = @MontoCancelado, SaldoActual = @SaldoActual, FK_IdEstado = @FK_IdEstado
    WHERE PK_IdFactura = @PK_IdFactura
    COMMIT
GO

IF OBJECT_ID('SP_TbFactura_Imprimir', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_Imprimir;
GO
CREATE PROCEDURE SP_TbFactura_Imprimir
	@PK_IdFactura   int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbFactura
	SET FK_IdEstado = 4
    WHERE PK_IdFactura = @PK_IdFactura
    COMMIT
GO

IF OBJECT_ID('SP_TbFactura_Anular', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbFactura_Anular;
GO
CREATE PROCEDURE SP_TbFactura_Anular
	@PK_IdFactura   int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbFactura
	SET FK_IdEstado = 5
    WHERE PK_IdFactura = @PK_IdFactura
    COMMIT
GO

--Tabla TbRecibo

IF OBJECT_ID('SP_TbRecibo_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRecibo_Mostrar;
GO
CREATE PROCEDURE SP_TbRecibo_Mostrar
AS
	SET NOCOUNT ON
	SELECT r.PK_IdRecibo 'Id Recibo', r.FechaEmision 'Fecha de Emisión', r.FK_Correo 'Correo', r.Descripcion 'Descripción', r.MontoTotal 'Monto Total', r.FK_IdEstado 'Id Estado'
	FROM TbRecibo r
GO

IF OBJECT_ID('SP_TbRecibo_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRecibo_Buscar;
GO
CREATE PROCEDURE SP_TbRecibo_Buscar
	@PK_IdRecibo int
AS
	SET NOCOUNT ON
	SELECT PK_IdRecibo, FechaEmision, FK_Correo, Descripcion, MontoTotal, FK_IdEstado
	FROM TbRecibo
	WHERE PK_IdRecibo = @PK_IdRecibo	
GO

IF OBJECT_ID('SP__Reporte_Recibos', 'P') IS NOT NULL 
    DROP PROCEDURE SP__Reporte_Recibos;
GO
CREATE PROCEDURE SP__Reporte_Recibos
	@PK_Correo	nchar(30)
AS
	SET NOCOUNT ON
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbRecibo.FechaEmision,TbRecibo.PK_IdRecibo,TbRecibo.MontoTotal, TbRecibo.Descripcion
	FROM   TbRecibo INNER JOIN TbPersona ON TbRecibo.FK_Correo = dbo.TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo 
GO

IF OBJECT_ID('SP_TbRecibo_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRecibo_Insertar;
GO
CREATE PROCEDURE SP_TbRecibo_Insertar
	@PK_IdRecibo 	int,
	@FechaEmision 	date,
	@FK_Correo 		nvarchar(30),
	@Descripcion 	nvarchar(20),
	@MontoTotal 	money,
	@FK_IdEstado 	int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbRecibo(PK_IdRecibo, FechaEmision, FK_Correo, Descripcion, MontoTotal, FK_IdEstado)
	VALUES (@PK_IdRecibo, @FechaEmision, @FK_Correo, @Descripcion, @MontoTotal, @FK_IdEstado)
	COMMIT
GO

IF OBJECT_ID('SP_TbRecibo_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRecibo_Actualizar;
GO
CREATE PROCEDURE SP_TbRecibo_Actualizar
	@PK_IdRecibo 	int,
	@FechaEmision 	date,
	@FK_Correo 		nvarchar(30),
	@Descripcion 	nvarchar(20),
	@MontoTotal 	money,
	@FK_IdEstado 	int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbRecibo
	SET FechaEmision = @FechaEmision, FK_Correo = @FK_Correo, Descripcion = @Descripcion, MontoTotal = @MontoTotal,
	FK_IdEstado = @FK_IdEstado
	WHERE PK_IdRecibo = @PK_IdRecibo	
	COMMIT
GO

IF OBJECT_ID('SP_TbRecibo_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbRecibo_Eliminar;
GO
CREATE PROCEDURE SP_TbRecibo_Eliminar
	@PK_IdRecibo 	int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbRecibo
	WHERE PK_IdRecibo = @PK_IdRecibo	
	COMMIT
GO

--Tabla TbDetalleRecibo

IF OBJECT_ID('SP_TbDetalleRecibo_Mostrar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleRecibo_Mostrar;
GO
CREATE PROCEDURE SP_TbDetalleRecibo_Mostrar
	@PK_IdRecibo	int
AS
	SET NOCOUNT ON
	SELECT PK_IdRecibo 'Id Recibo', PK_IdDetalleRecibo 'Id Detalle Recibo', FK_IdFactura 'Id Factura', MontoCancelado 'Monto Cancelado'
	FROM TbDetalleRecibo
	WHERE PK_IdRecibo = @PK_IdRecibo
GO

IF OBJECT_ID('SP_TbDetalleRecibo_Buscar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleRecibo_Buscar;
GO
CREATE PROCEDURE SP_TbDetalleRecibo_Buscar
	@PK_IdRecibo			int,
	@PK_IdDetalleRecibo		int,
	@FK_IdFactura			int
AS
	SET NOCOUNT ON
	SELECT PK_IdRecibo, PK_IdDetalleRecibo, FK_IdFactura, MontoCancelado
	FROM TbDetalleRecibo
	WHERE PK_IdRecibo = @PK_IdRecibo
	AND PK_IdDetalleRecibo = @PK_IdDetalleRecibo
	AND FK_IdFactura = @FK_IdFactura
GO

IF OBJECT_ID('SP_TbDetalleRecibo_Insertar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleRecibo_Insertar;
GO
CREATE PROCEDURE SP_TbDetalleRecibo_Insertar
	@PK_IdRecibo		int,
	@FK_IdFactura		int,
	@MontoCancelado		money
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	INSERT INTO TbDetalleRecibo(PK_IdRecibo, FK_IdFactura, MontoCancelado)
	VALUES (@PK_IdRecibo, @FK_IdFactura, @MontoCancelado)
	COMMIT
GO

IF OBJECT_ID('SP_TbDetalleRecibo_Actualizar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleRecibo_Actualizar;
GO
CREATE PROCEDURE SP_TbDetalleRecibo_Actualizar
	@PK_IdRecibo			int,
	@PK_IdDetalleRecibo		int,
	@FK_IdFactura			int,
	@MontoCancelado			money
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	UPDATE TbDetalleRecibo
	SET FK_IdFactura = @FK_IdFactura, MontoCancelado = @MontoCancelado
	WHERE PK_IdRecibo = @PK_IdRecibo
	AND PK_IdDetalleRecibo = @PK_IdDetalleRecibo
	AND FK_IdFactura = @FK_IdFactura
	COMMIT
GO

IF OBJECT_ID('SP_TbDetalleRecibo_Eliminar', 'P') IS NOT NULL 
    DROP PROCEDURE SP_TbDetalleRecibo_Eliminar;
GO
CREATE PROCEDURE SP_TbDetalleRecibo_Eliminar
	@PK_IdRecibo			int,
	@PK_IdDetalleRecibo		int,
	@FK_IdFactura			int
AS
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DELETE FROM TbDetalleRecibo
	WHERE PK_IdRecibo = @PK_IdRecibo
	AND PK_IdDetalleRecibo = @PK_IdDetalleRecibo
	AND FK_IdFactura = @FK_IdFactura
	COMMIT
GO


IF OBJECT_ID('SP_Reporte_Recibo', 'P') IS NOT NULL 
    DROP PROCEDURE SP_Reporte_Recibo;
GO
CREATE PROCEDURE SP_Reporte_Recibos
	@PK_Correo	nchar(30)

AS	
	SET NOCOUNT ON;
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbRecibo.FechaEmision,TbRecibo.PK_IdRecibo,TbRecibo.MontoTotal, TbRecibo.Descripcion
	FROM   TbRecibo INNER JOIN TbPersona ON TbRecibo.FK_Correo = dbo.TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo 
GO

IF OBJECT_ID('SP_Reporte_RecibosxFecha', 'P') IS NOT NULL 
    DROP PROCEDURE SP_Reporte_RecibosxFecha;
GO
CREATE PROCEDURE SP_Reporte_RecibosxFecha
	@PK_Correo	nchar(30),
	@FechIni	date,
	@FechFin	date
AS	
	SET NOCOUNT ON;
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbRecibo.FechaEmision,TbRecibo.PK_IdRecibo,TbRecibo.MontoTotal, TbRecibo.Descripcion
	FROM   TbRecibo INNER JOIN TbPersona ON TbRecibo.FK_Correo = dbo.TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo AND TbRecibo.FechaEmision BETWEEN @FechIni AND @FechFin
GO

IF OBJECT_ID('SP_Reporte_Facturas', 'P') IS NOT NULL 
    DROP PROCEDURE SP_Reporte_Facturas;
GO
CREATE PROCEDURE SP_Reporte_Facturas
	@PK_Correo	nchar(30)
AS	
	SET NOCOUNT ON;
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbFactura.FechaEmision,TbFactura.FechaVencimiento,TbFactura.PK_IdFactura,TbFactura.MontoTotal,TbFactura.MontoCancelado, 
           TbFactura.SaldoActual
	FROM   TbFactura INNER JOIN TbPersona ON TbFactura.FK_Correo = TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo 
GO

IF OBJECT_ID('SP_Reporte_FacturasXFecha', 'P') IS NOT NULL 
    DROP PROCEDURE SP_Reporte_FacturasXFecha;
GO
CREATE PROCEDURE SP_Reporte_FacturasXFecha
	@PK_Correo	nchar(30),
	@FechIni	date,
	@FechFin	date

AS	
	SET NOCOUNT ON;
	SELECT TbPersona.Nombre,TbPersona.Cedula,TbPersona.Apellido1,TbPersona.PK_Correo,TbPersona.Direccion,TbPersona.Telefono, 
           TbFactura.FechaEmision,TbFactura.FechaVencimiento,TbFactura.PK_IdFactura,TbFactura.MontoTotal,TbFactura.MontoCancelado, 
           TbFactura.SaldoActual
	FROM   TbFactura INNER JOIN TbPersona ON TbFactura.FK_Correo = TbPersona.PK_Correo
	WHERE  TbPersona.PK_Correo = @PK_Correo AND TbFactura.FechaEmision BETWEEN @FechIni and @FechFin
GO

--Crear triggers


