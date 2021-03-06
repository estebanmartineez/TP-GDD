USE [GD2C2016]
GO
/****** Object:  Schema [INTERNAL_SERVER_ERROR]    Script Date: 11/12/2016 14:52:00 ******/
CREATE SCHEMA [INTERNAL_SERVER_ERROR]
GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[actualizarIntentoLogin]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [INTERNAL_SERVER_ERROR].[actualizarIntentoLogin](@username int)
as
begin
	UPDATE GD2C2016.INTERNAL_SERVER_ERROR.Usuario SET intIntentosLogin = 0 WHERE intIdUsuario = @username;
end



GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[comprarBono]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
create procedure [INTERNAL_SERVER_ERROR].[comprarBono] @Usuario int, @cantidad int, @codigoPlan int
as
begin transaction
declare @aux int
set @aux = 0
  
	while(@aux < @cantidad)
	begin
	set @aux = @aux + 1
	insert into INTERNAL_SERVER_ERROR.Bono (intCodigoPlan, datFechaCompra, intIdAfiliadoCompro) values (@codigoPlan, GETDATE(), @Usuario)
	end
 commit






GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[CreacionFuncionalidades]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[CreacionFuncionalidades]
AS
BEGIN
	insert into INTERNAL_SERVER_ERROR.Rol(varNombreRol, bitHabilitado) values
	('Afiliado', 1),
	('Profesional', 1),
	('Administrativo', 1)

	Insert into INTERNAL_SERVER_ERROR.Funcionalidad(varFuncionalidad, varDescripcion) values 
	('ABM Rol', 'AMB Rol'),
	('Registro Usuario', 'Registro Usuario'),
	('ABM Afiliado', 'ABM Afiliado'),
	('ABM Profesional', 'AMB Profesional'),
	('ABM Esp Medicas', 'ABM Esp Medicas'),
	('ABM Planes', 'ABM Planes'),
	('Registrar Agenda', 'Registrar Agenda'),
	('Comprar Bonos', 'Comprar Bonos'),
	('Pedir Turnos', 'Pedir Turnos'),
	('Registro Llegada Atencion Medica', 'Registro Llegada Atencion Medica'),
	('Registro Resultado Atencion Medica', 'Registro Resultado Atencion Medica'),
	('Cancelar Atencion Medica', 'Cancelar Atencion Medica'),
	('Listado Estadistico','Listado Estadistico')

	Insert Into INTERNAL_SERVER_ERROR.FuncionalidadXRol(intIdFuncionalidad,varNombreRol) values
	(1,'Administrativo'),
	(2,'Administrativo'),
	(3,'Administrativo'),
	(4,'Administrativo'),
	(5,'Administrativo'),
	(6,'Administrativo'),
	(7,'Administrativo'),
	(7,'Profesional'),
	(8,'Afiliado'),
	(9,'Administrativo'),
	(9,'Afiliado'),
	(10,'Administrativo'),
	(11,'Profesional'),
	(12,'Profesional'),
	(12,'Afiliado'),
	(13,'Administrativo')


END







GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[eliminarRol]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[eliminarRol] @rol varchar(20)
  AS
  BEGIN
		delete from INTERNAL_SERVER_ERROR.FuncionalidadXRol where varNombreRol = @rol;
		delete from INTERNAL_SERVER_ERROR.Rol where varNombreRol = @rol;
 END







GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionAfiliado]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionAfiliado]
AS
BEGIN
	Insert into INTERNAL_SERVER_ERROR.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Paciente_Dni, HASHBYTES('SHA2_256', 'afiliado'), Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Telefono, Paciente_Direccion, Paciente_Mail, Paciente_Fecha_Nac
	from gd_esquema.Maestra

	Insert into INTERNAL_SERVER_ERROR.Afiliado(intIdUsuario, intCodigoPlan, bitEstadoActual, intNumeroConsultaMedica)
	select distinct Paciente_Dni, Plan_Med_Codigo, 1, 0
	from gd_esquema.Maestra

	Insert into INTERNAL_SERVER_ERROR.UsuarioXRol(intIdUsuario)
	select distinct Paciente_Dni  from gd_esquema.Maestra

	UPDATE INTERNAL_SERVER_ERROR.UsuarioXRol SET varNombreRol = 'Afiliado' where varNombreRol is null;

	UPDATE a
	SET a.intNumeroAfiliado = CAST(CONCAT(u.intIdUsuario,'01') AS bigint)
	FROM Afiliado a 
	INNER JOIN Usuario u ON a.intIdUsuario = u.intIdUsuario
END








GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionAgenda]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionAgenda]
AS
BEGIN
DECLARE @profesional int;
DECLARE profesionales CURSOR FOR SELECT DISTINCT intIdUsuario 
FROM Profesional WHERE intIdUsuario IS NOT NULL;
OPEN profesionales;

FETCH profesionales INTO @profesional;

WHILE @@FETCH_STATUS = 0
BEGIN 
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'lunes','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'martes','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'miercoles','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'jueves','2010-01-01','2018-01-01','7:00','18:00');
	FETCH profesionales INTO @profesional
END
CLOSE profesionales;
DEALLOCATE profesionales;
END






GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionBono]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionBono]
AS
BEGIN
	INSERT INTO INTERNAL_SERVER_ERROR.Bono(intCodigoPlan, datFechaCompra,datFechaImpresion,intNumeroConsultaMedica, intIdAfiliadoCompro, intIdAfiliadoUtilizo)
	SELECT Plan_Med_Codigo, Compra_Bono_Fecha,Bono_Consulta_Fecha_Impresion,Bono_Consulta_Numero, Paciente_Dni, Paciente_Dni
	FROM GD2C2016.gd_esquema.Maestra
	where Compra_Bono_Fecha is not null
END





GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionEspecialidad]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionEspecialidad]
AS
BEGIN
	insert into INTERNAL_SERVER_ERROR.Especialidad(intEspecialidadCodigo, varDescripcion, intCodigoTipoEspecialidad, varDescripcionTipoEspecialidad)
	select distinct Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	from gd_esquema.Maestra where Especialidad_Codigo is not null
END







GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionPlanMedico]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionPlanMedico]
AS
BEGIN
	Insert into INTERNAL_SERVER_ERROR.[Plan](intCodigoPlan, varDescripcion, monPrecioBonoConsulta, monPrecioBonoFarmacia)
	select distinct Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
	from gd_esquema.Maestra
END








GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionProfesional]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionProfesional]
AS
BEGIN
	Insert into INTERNAL_SERVER_ERROR.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Medico_Dni, HASHBYTES('SHA2_256', 'Profesional'), Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Telefono, Medico_Direccion, Medico_Mail, Medico_Fecha_Nac
	from gd_esquema.Maestra where Medico_Dni IS NOT NULL
	
	insert into INTERNAL_SERVER_ERROR.Profesional(intIdUsuario)
	select distinct Medico_Dni
	from gd_esquema.Maestra where Medico_Dni is not null

	Insert into INTERNAL_SERVER_ERROR.UsuarioXRol(intIdUsuario)
	select distinct Medico_Dni from gd_esquema.Maestra

	UPDATE INTERNAL_SERVER_ERROR.UsuarioXRol SET varNombreRol = 'Profesional' where varNombreRol is null;

	Insert into INTERNAL_SERVER_ERROR.ProfesionalXEspecialidad(intIdUsuario, intEspecialidadCodigo)
	select distinct Medico_Dni, Especialidad_Codigo
	from gd_esquema.Maestra where Medico_Dni is not null
END







GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[MigracionTurno]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[MigracionTurno]
AS
BEGIN

	INSERT INTO INTERNAL_SERVER_ERROR.Turno([datFechaTurno],[intIdPaciente],[intIdDoctor],[bitEstado])VALUES(GETDATE(),NULL,NULL,1)
	DBCC CHECKIDENT ('INTERNAL_SERVER_ERROR.Turno', RESEED, 56564);  
	DELETE INTERNAL_SERVER_ERROR.Turno 

	Insert into INTERNAL_SERVER_ERROR.Turno(datFechaTurno, intIdPaciente,intIdDoctor, bitEstado)
	select distinct Turno_Fecha, Paciente_Dni, Medico_Dni, 1
	from gd_esquema.Maestra where Turno_Numero is not null

	insert into INTERNAL_SERVER_ERROR.Asistencia(intIdTurno, datFechaYHora, bitAtendido)
	select distinct Turno_Numero, Turno_Fecha, 1
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL

	insert into INTERNAL_SERVER_ERROR.Consulta(intIdTurno, datFechaYHora, varSintomas, varEnfermedad)
	select distinct Turno_Numero, Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL

/*	INSERT INTO INTERNAL_SERVER_ERROR.Agenda(intIdProfesional,dateHorarioAtencion, intIdEspecialidad)
	SELECT DISTINCT Medico_Dni,Turno_Fecha, Especialidad_Codigo FROM gd_esquema.Maestra;*/
END






GO
/****** Object:  StoredProcedure [INTERNAL_SERVER_ERROR].[procedureSumarIntentoLogin]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [INTERNAL_SERVER_ERROR].[procedureSumarIntentoLogin] @username int
AS
BEGIN
	UPDATE GD2C2016.INTERNAL_SERVER_ERROR.Usuario SET intIntentosLogin = intIntentosLogin + 1 WHERE intIdUsuario = @username;	
END


GO
/****** Object:  UserDefinedFunction [INTERNAL_SERVER_ERROR].[validarUsuario]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [INTERNAL_SERVER_ERROR].[validarUsuario](@username INT, @pass varchar(100))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @devolver varchar(50);
	DECLARE @nombreRol varchar(50);
	DECLARE @cantidadRoles INT;
	DECLARE @cantidadIntentos INT;

	SELECT @nombreRol = p.varNombreRol,@cantidadRoles = COUNT(p.varNombreRol),@cantidadIntentos = u.intIntentosLogin FROM GD2C2016.INTERNAL_SERVER_ERROR.Usuario u,GD2C2016.INTERNAL_SERVER_ERROR.UsuarioXRol p 
	WHERE u.intIdUsuario = p.intIdUsuario and u.intIdUsuario = @username and u.nvarPassword =  HASHBYTES('SHA2_256', @pass)
	GROUP BY p.varNombreRol,u.intIntentosLogin;
		IF(@cantidadIntentos < 3)
			BEGIN
				IF(@cantidadRoles is not null) 
				BEGIN
					--exec INTERNAL_SERVER_ERROR.actualizarIntentoLogin @username
					--UPDATE GD2C2016.INTERNAL_SERVER_ERROR.Usuario SET intIntentosLogin = 0 WHERE intIdUsuario = @username;
				SET	@devolver = CONVERT(VARCHAR(100),@cantidadRoles)+@nombreRol;
				END
			END
		ELSE 
			BEGIN
				--exec procedureSumarIntentoLogin @username
			--	UPDATE GD2C2016.INTERNAL_SERVER_ERROR.Usuario SET intIntentosLogin = intIntentosLogin + 1 WHERE intIdUsuario = @username;
				SET	@devolver = 'LOGIN INVALIDO';
			END
		RETURN @devolver;
END

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Afiliado]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Afiliado](
	[intIdUsuario] [int] NOT NULL,
	[bitEstadoActual] [bit] NULL,
	[intCodigoPlan] [int] NULL,
	[datFechaBaja] [date] NULL,
	[intNumeroAfiliado] [bigint] NULL,
	[intCantidadFamiliares] [int] NULL,
	[intNumeroConsultaMedica] [int] NULL,
 CONSTRAINT [PK_Afiliado] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan](
	[intIdAfiliadoHistoricoPlan] [int] IDENTITY(1,1) NOT NULL,
	[intIdUsuario] [int] NULL,
	[datFechaModificacion] [date] NULL,
	[varMotivoModificacion] [varchar](250) NULL,
	[intCodigoPlan] [int] NULL,
 CONSTRAINT [PK_AfiliadoHistoricoPlan] PRIMARY KEY CLUSTERED 
(
	[intIdAfiliadoHistoricoPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Agenda]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Agenda](
	[intIdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[intIdProfesional] [int] NULL,
	[dateFechaInicio] [date] NULL,
	[dateFechaFin] [date] NULL,
	[timeHoraInicio] [time](7) NULL,
	[timeHoraFin] [time](7) NULL,
	[charDia] [char](15) NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[intIdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Asistencia]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Asistencia](
	[intIdTurno] [int] NOT NULL,
	[datFechaYHora] [datetime] NULL,
	[varBono] [varchar](50) NULL,
	[bitAtendido] [bit] NULL,
	[intIdAsistencia] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Asistencia] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Bono]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Bono](
	[intIINTERNAL_SERVER_ERRORno] [int] IDENTITY(1,1) NOT NULL,
	[intCodigoPlan] [int] NULL,
	[datFechaCompra] [datetime] NULL,
	[intIdAfiliadoCompro] [int] NULL,
	[intIdAfiliadoUtilizo] [int] NULL,
	[intNumeroConsultaMedica] [int] NULL,
	[datFechaImpresion] [datetime] NULL,
 CONSTRAINT [PK_Bono] PRIMARY KEY CLUSTERED 
(
	[intIINTERNAL_SERVER_ERRORno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Consulta]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Consulta](
	[intIdTurno] [int] NOT NULL,
	[datFechaYHora] [datetime] NULL,
	[varSintomas] [varchar](150) NULL,
	[varEnfermedad] [varchar](150) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Especialidad]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Especialidad](
	[intEspecialidadCodigo] [numeric](18, 0) NOT NULL,
	[varDescripcion] [varchar](255) NULL,
	[intCodigoTipoEspecialidad] [numeric](18, 0) NULL,
	[varDescripcionTipoEspecialidad] [varchar](255) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[intEspecialidadCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Funcionalidad]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Funcionalidad](
	[intIdFuncionalidad] [int] IDENTITY(1,1) NOT NULL,
	[varFuncionalidad] [varchar](50) NULL,
	[varDescripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[intIdFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[FuncionalidadXRol]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[FuncionalidadXRol](
	[intIdFuncionalidadXRol] [int] IDENTITY(1,1) NOT NULL,
	[intIdFuncionalidad] [int] NULL,
	[varNombreRol] [varchar](50) NULL,
 CONSTRAINT [PK_FuncionalidadXRol] PRIMARY KEY CLUSTERED 
(
	[intIdFuncionalidadXRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Plan]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Plan](
	[intCodigoPlan] [int] NOT NULL,
	[varDescripcion] [varchar](150) NULL,
	[monPrecioBonoConsulta] [money] NULL,
	[monPrecioBonoFarmacia] [money] NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[intCodigoPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Profesional]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Profesional](
	[intIdUsuario] [int] NOT NULL,
	[intMatricula] [int] NULL,
 CONSTRAINT [PK_Profesional] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad](
	[intIdProfesionalXEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[intIdUsuario] [int] NULL,
	[intEspecialidadCodigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ProfesionalXEspecialidad] PRIMARY KEY CLUSTERED 
(
	[intIdProfesionalXEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Rol]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Rol](
	[varNombreRol] [varchar](50) NOT NULL,
	[bitHabilitado] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[varNombreRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Turno]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Turno](
	[intIdTurno] [int] IDENTITY(1,1) NOT NULL,
	[datFechaTurno] [datetime] NULL,
	[intIdPaciente] [int] NULL,
	[intIdDoctor] [int] NULL,
	[bitEstado] [bit] NULL,
	[intEspecialidadCodigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[TurnoCancelado]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[TurnoCancelado](
	[intIdTurno] [int] NOT NULL,
	[varMotivo] [varchar](50) NULL,
	[varTipo] [varchar](50) NULL,
 CONSTRAINT [PK_TurnoCancelado] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[Usuario]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[Usuario](
	[intIdUsuario] [int] NOT NULL,
	[nvarPassword] [nvarchar](100) NULL,
	[varNombre] [varchar](50) NULL,
	[varApellido] [varchar](50) NULL,
	[varTipoDocumento] [varchar](50) NULL,
	[intNroDocumento] [int] NULL,
	[intTelefono] [int] NULL,
	[varEstadoCivil] [varchar](100) NULL,
	[varDireccion] [varchar](250) NULL,
	[varMail] [varchar](150) NULL,
	[datFechaNacimiento] [datetime] NULL,
	[chrSexo] [char](1) NULL,
	[intIntentosLogin] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [INTERNAL_SERVER_ERROR].[UsuarioXRol]    Script Date: 11/12/2016 14:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [INTERNAL_SERVER_ERROR].[UsuarioXRol](
	[intIdUsuarioXRol] [int] IDENTITY(1,1) NOT NULL,
	[varNombreRol] [varchar](50) NULL,
	[intIdUsuario] [int] NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[intIdUsuarioXRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Usuario] ADD  DEFAULT ((0)) FOR [intIntentosLogin]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Plan] FOREIGN KEY([intCodigoPlan])
REFERENCES [INTERNAL_SERVER_ERROR].[Plan] ([intCodigoPlan])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Plan]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [INTERNAL_SERVER_ERROR].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Usuario]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan]  WITH CHECK ADD  CONSTRAINT [FK_AfiliadoHistoricoPlan_Afiliado] FOREIGN KEY([intIdUsuario])
REFERENCES [INTERNAL_SERVER_ERROR].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan] CHECK CONSTRAINT [FK_AfiliadoHistoricoPlan_Afiliado]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan]  WITH CHECK ADD  CONSTRAINT [FK_AfiliadoHistoricoPlan_Plan] FOREIGN KEY([intCodigoPlan])
REFERENCES [INTERNAL_SERVER_ERROR].[Plan] ([intCodigoPlan])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan] CHECK CONSTRAINT [FK_AfiliadoHistoricoPlan_Plan]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Asistencia_Turno] FOREIGN KEY([intIdTurno])
REFERENCES [INTERNAL_SERVER_ERROR].[Turno] ([intIdTurno])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Asistencia] CHECK CONSTRAINT [FK_Asistencia_Turno]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_AfiliadoCompro] FOREIGN KEY([intIdAfiliadoCompro])
REFERENCES [INTERNAL_SERVER_ERROR].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono] CHECK CONSTRAINT [FK_Bono_AfiliadoCompro]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_AfiliadoUtilizo] FOREIGN KEY([intIdAfiliadoUtilizo])
REFERENCES [INTERNAL_SERVER_ERROR].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono] CHECK CONSTRAINT [FK_Bono_AfiliadoUtilizo]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Plan] FOREIGN KEY([intCodigoPlan])
REFERENCES [INTERNAL_SERVER_ERROR].[Plan] ([intCodigoPlan])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Bono] CHECK CONSTRAINT [FK_Bono_Plan]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Asistencia] FOREIGN KEY([intIdTurno])
REFERENCES [INTERNAL_SERVER_ERROR].[Asistencia] ([intIdTurno])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Consulta] CHECK CONSTRAINT [FK_Consulta_Asistencia]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad] FOREIGN KEY([intIdFuncionalidad])
REFERENCES [INTERNAL_SERVER_ERROR].[Funcionalidad] ([intIdFuncionalidad])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Rol] FOREIGN KEY([varNombreRol])
REFERENCES [INTERNAL_SERVER_ERROR].[Rol] ([varNombreRol])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Rol]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Profesional]  WITH CHECK ADD  CONSTRAINT [FK_Profesional_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [INTERNAL_SERVER_ERROR].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Profesional] CHECK CONSTRAINT [FK_Profesional_Usuario]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXEspecialidad_Especialidad] FOREIGN KEY([intEspecialidadCodigo])
REFERENCES [INTERNAL_SERVER_ERROR].[Especialidad] ([intEspecialidadCodigo])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad] CHECK CONSTRAINT [FK_ProfesionalXEspecialidad_Especialidad]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXEspecialidad_Profesional] FOREIGN KEY([intIdUsuario])
REFERENCES [INTERNAL_SERVER_ERROR].[Profesional] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[ProfesionalXEspecialidad] CHECK CONSTRAINT [FK_ProfesionalXEspecialidad_Profesional]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Afiliado] FOREIGN KEY([intIdPaciente])
REFERENCES [INTERNAL_SERVER_ERROR].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Turno] CHECK CONSTRAINT [FK_Turno_Afiliado]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Profesional] FOREIGN KEY([intIdDoctor])
REFERENCES [INTERNAL_SERVER_ERROR].[Profesional] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[Turno] CHECK CONSTRAINT [FK_Turno_Profesional]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[TurnoCancelado]  WITH CHECK ADD  CONSTRAINT [FK_TurnoCancelado_Turno] FOREIGN KEY([intIdTurno])
REFERENCES [INTERNAL_SERVER_ERROR].[Turno] ([intIdTurno])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[TurnoCancelado] CHECK CONSTRAINT [FK_TurnoCancelado_Turno]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Rol] FOREIGN KEY([varNombreRol])
REFERENCES [INTERNAL_SERVER_ERROR].[Rol] ([varNombreRol])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Rol]
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [INTERNAL_SERVER_ERROR].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [INTERNAL_SERVER_ERROR].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Usuario]
GO

exec INTERNAL_SERVER_ERROR.MigracionEspecialidad;
 exec INTERNAL_SERVER_ERROR.MigracionPlanMedico;
 exec INTERNAL_SERVER_ERROR.CreacionFuncionalidades;
 exec INTERNAL_SERVER_ERROR.MigracionProfesional;
 exec INTERNAL_SERVER_ERROR.MigracionAfiliado;
 exec INTERNAL_SERVER_ERROR.MigracionBono;
 exec INTERNAL_SERVER_ERROR.MigracionTurno;
 exec INTERNAL_SERVER_ERROR.MigracionAgenda;