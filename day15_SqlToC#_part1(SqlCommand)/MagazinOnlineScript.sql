--Magazin Online Creatinon--
--Marius Script--

--delete tables--

drop table LinieFactura
drop table LinieComanda
drop table Factura
drop table Comanda
drop table Client
drop table Produs
drop table Categorie

Go
--create tables:--

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Categorie')
BEGIN
    create Table Categorie(
	CategorieID int identity(1,1),
	Nume nvarchar(200),
	Constraint PK_CategorieID primary key(CategorieID)
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Produs')
BEGIN
    create table Produs (
	ProdusID int identity(1,1),
	Nume nvarchar(100) not null,
	CategorieID int not null,
	Pret decimal(8,2) not null check (Pret > 0),
	
	Constraint PK_ProdusID primary key(ProdusID),
	Constraint FK_CategorieID Foreign Key (CategorieID) references Categorie(CategorieID)
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Client')
BEGIN
	create table Client (
		ClientId int identity(1,1),
		Nume nvarchar(200) not null,
		Prenume nvarchar(200) not null,
		CNP char(13) NOT NULL UNIQUE,

		Constraint PK_ClientID primary key(ClientId),
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Comanda')
BEGIN
    create table Comanda (
	ComandaId int identity(1,1),
	ClientId int not null,

	Constraint PK_ComandaID primary key(ComandaId),
	Constraint FK_Comanda_ClientID Foreign Key (ClientId) references Client(ClientId)
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LinieComanda')
BEGIN
	create table LinieComanda (
	LinieComandaId int identity(1,1),
	ComandaId int NOT NULL,
	ProdusId int NOT NULL,
	Cantitate int NOT NULL default(1),

	Constraint PK_LinieComandaId primary key(LinieComandaId),
	Constraint FK_LinieComanda_ComandaId Foreign Key (ComandaId) references Comanda(ComandaId),
	Constraint FK_LinieComanda_ProdusId Foreign Key (ProdusId) references Produs(ProdusId),
	Constraint DF_Check_Cantitate check (Cantitate <> 0 )
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Factura')
BEGIN
    create table Factura
	(
		FacturaId int identity(1,1),
		ClinetId int not null,
		ComandaId int not null,
	
		constraint PK_FacturaID Primary Key (FacturaId),
		constraint FK_FacturaClinetID Foreign Key (ClinetId) references Client(ClientId),
		constraint FK_FacturaComandaID Foreign Key (ComandaId) references Comanda(ComandaId)
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LinieFactura')
BEGIN
    create table LinieFactura
	(
		LinieFacturaId int identity(1,1),
		FacturaId int not null,
		LinieComandaId int not null,
		ProdusId int not null,
		Pret decimal(8,2) not null,
		Cantitate int,

		constraint PK_LinieFacturaId Primary Key (LinieFacturaId),
		constraint FK_LinieFacutura_FacturaId Foreign Key (FacturaId) references Factura(FacturaId),
		constraint FK_LinieFactura_LinieComandaId Foreign Key (LinieComandaId) references LinieComanda(LinieComandaId),
		constraint FK_Factura_ProdusId Foreign Key (ProdusId) references Produs(ProdusId)
	)
END

--alter talbe Comanda
IF NOT EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'Comanda'
                 AND COLUMN_NAME = 'Finalizata') 
begin
alter table Comanda
add Finalizata bit not null default(0)
end

Go
--add values to tables--

insert into Categorie(Nume)
values
  ('Laptop')
, ('Monitor')
, ('Telefon')
, ('Televizor')

Go
 
insert into Produs(Nume, CategorieId, Pret)
values
  ('Laptop Lenovo', 1, 3000)
, ('Laptop Toshiba', 1, 3300)
, ('Laptop Dell', 1, 4000)
, ('Monitor Samsunng', 2, 1000)
, ('Monitor Benq', 2, 1600)
, ('Monitor LG', 2, 800)
, ('Telefon Samsung', 3, 2000)
, ('Telefon HTC', 3, 1800)
, ('Telefon Apple', 3, 2600)
, ('Telefon Motorola', 3, 1100)
, ('Televizor LG', 4, 2000)
, ('Televizor Samsung', 4, 2200)
, ('Televizor Panasonic', 4, 1800)
 
Go

insert into Client(Nume, Prenume, CNP)
values
  ('Stefanescu', 'Robert', '1900227112233')
, ('Marinescu', 'Marinica', '1600303112233')
, ('Vasilescu', 'Vasilica', '6010903112233')
, ('Popescu', 'Popica', '5050610112233')
, ('Iliescu', 'Ion', '3971010112233')
 
Go

insert into Comanda(ClientId)
values
  (1)
, (1)
, (2)
, (3)
, (5)
 
Go

insert into LinieComanda(ComandaId, ProdusId, Cantitate)
values
  (1, 1, 1)
, (1, 9, 2)
, (2, 9, -1)
, (3, 5, 1)
, (4, 13, 1)
, (4, 12, 1)
, (5, 3, 1)


Go

--generare Factura and LinieFactura--
alter procedure P_GenereazaFactura(@ComandaId int) 
as
begin
		if @ComandaId not in (select ComandaID from Comanda)
		begin
			raiserror('Eroare CommandaId nu exsita!', 16, 1)
			return
		end

		declare @finalizata bit
		select @finalizata = Finalizata from Comanda where ComandaId = @ComandaId

		if @finalizata <> 0
		begin
			raiserror('Eroare ID-ul deja a fost adaugat!', 16, 1)
			return
		end

		insert into Factura(ClinetId, ComandaId)
		select ClientId, ComandaId from Comanda where ComandaId = @ComandaId

		declare @lastFacturaID int
		select @lastFacturaID = max(FacturaId) from Factura

		insert into LinieFactura(FacturaId, LinieComandaId, ProdusId, Pret, Cantitate)
		select  
			@lastFacturaID
			, LinieComanda.LinieComandaId
			, LinieComanda.ProdusId
			, Produs.Pret
			, LinieComanda.Cantitate 
			from LinieComanda 
			inner join Produs on Produs.ProdusID = LinieComanda.ProdusId
			where ComandaId = @ComandaId

		update Comanda
		set Finalizata = 1
		where ComandaId = @ComandaId

end

Go

exec P_GenereazaFactura 1
exec P_GenereazaFactura 2
exec P_GenereazaFactura 3
exec P_GenereazaFactura 4

Go
--verifi tables--

Select * from Categorie
Select * from Produs
Select * from Client
Select * from Comanda
Select * from LinieComanda