if db_id('webapidb') is not null
begin
	use master
	drop webapidb webapi
end 

create database webapidb
go
Use webapidb
go


create schema Adm;
go

CREATE TABLE Adm.Cliente(
CodCliente varchar(10) not null,  
NombreCompleto varchar(200) not null,
NombreCorto varchar(40) not null,
Abreviatura varchar(40) not null,
Ruc varchar(11) not null,
Estado char(1) not null,
GrupoFacturacion varchar(100) null,
InactivoDesde datetime null,
CodigoSAP varchar(20) null
);
GO  
alter table Adm.Cliente add constraint pk_cliente primary key(CodCliente)

IF (OBJECT_ID('spListarCliente') IS NOT NULL)
  DROP PROCEDURE spListarCliente
GO

create procedure spListarCliente as
begin
	select CodCliente,NombreCompleto,NombreCorto,Abreviatura,Ruc,Estado,GrupoFacturacion,InactivoDesde,CodigoSAP from Adm.Cliente
end
go

exec spListarCliente

IF (OBJECT_ID('spCrearCliente') IS NOT NULL)
  DROP PROCEDURE spCrearCliente
GO

create procedure spCrearCliente (
	@CodCliente varchar(10)
	,@NombreCompleto varchar(200)
	,@NombreCorto varchar(40)
	,@Abreviatura varchar(40)
	,@Ruc varchar(11)
	,@Estado char(1)
	,@GrupoFacturacion varchar(100)=null
	,@InactivoDesde datetime=null
	,@CodigoSAP varchar(20)=null
)
as
begin
	if not exists(select 1 from  Adm.Cliente where CodCliente=@CodCliente)
	begin
		insert into Adm.Cliente (CodCliente,NombreCompleto,NombreCorto,Abreviatura,Ruc,Estado,GrupoFacturacion,InactivoDesde,CodigoSAP )
		values (@CodCliente,@NombreCompleto,@NombreCorto,@Abreviatura,@Ruc,@Estado,@GrupoFacturacion,@InactivoDesde,@CodigoSAP)
	end
end
go

IF (OBJECT_ID('spActualizarCliente') IS NOT NULL)
  DROP PROCEDURE spActualizarCliente
GO
create procedure spActualizarCliente(
	@CodCliente varchar(10)
	,@NombreCompleto varchar(200)
	,@NombreCorto varchar(40)
	,@Abreviatura varchar(40)
	,@Ruc varchar(11)
	,@Estado char(1)
	,@GrupoFacturacion varchar(100)=null
	,@InactivoDesde datetime=null
	,@CodigoSAP varchar(20)=null)
as
begin
	if exists(select 1 from  Adm.Cliente where CodCliente=@CodCliente)	
		update Adm.Cliente set NombreCompleto=@NombreCompleto
		, NombreCorto = @NombreCorto
		,Abreviatura = @Abreviatura
		,Ruc = @Ruc
		,Estado=@Estado
		,GrupoFacturacion = @GrupoFacturacion
		,InactivoDesde = @InactivoDesde
		,CodigoSAP = @CodigoSAP
		where CodCliente=@CodCliente
end

IF (OBJECT_ID('spEliminarCliente') IS NOT NULL)
  DROP PROCEDURE spEliminarCliente
GO
create procedure spEliminarCliente(@CodCliente varchar(10))
as
begin
	if exists(select 1 from  Adm.Cliente where CodCliente=@CodCliente)	
		delete from Adm.Cliente where CodCliente=@CodCliente
end