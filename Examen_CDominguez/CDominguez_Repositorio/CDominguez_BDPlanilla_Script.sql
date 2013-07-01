-- ===================================================================
-- Author:		Carlos Domínguez Lara
-- Create date: Jueves 25 de Noviembre 8:31 am
-- Description: Base de datos para Examen: Clases tecnicas Proyecto 2
-- Ultima Modificación: Jueves 25 de Noviembre 8:31 am
-- ===================================================================
use master 
go

IF  DB_ID('CDominguez_BDPlanilla') IS NOT NULL
	drop database CDominguez_BDPlanilla
go

-- use master drop database CDominguez_BDPlanilla  <--- Para eliminar la base de datos
create database CDominguez_BDPlanilla
go

use CDominguez_BDPlanilla

-- ==================================================================================================
-- ==================================================================================================

--TABLA DEPARTAMENTO==================================================
create table t_departamento(
	codigo int primary key  not null,
	nombre nvarchar(50),
	id_encargado int not null

)

--Creamos el indice unico para el nombre del departamento--------
create unique nonclustered index IX_t_departamento_nombre on t_departamento(
nombre
) ON [primary]


--TABLA EMPLEADO=======================================================
create table t_empleado(
	id int identity(1,1) primary key,
	identificacion nvarchar(25) not null,
	nombre nvarchar(25) not null,
	apellidos nvarchar(25) not null,
	telefono nvarchar(20) not null,
	codigo_departamento int not null,
	direccion nvarchar(255) not null,
	puesto nvarchar(25) not null,

	constraint FK_t_empleado_codigo_departamento
		foreign key(codigo_departamento) references t_departamento(codigo)
)

--Creamos el indice unico para la identificacion------------------
create unique nonclustered index IX_t_empleado_identificacion on t_empleado(
identificacion
) ON [primary]


