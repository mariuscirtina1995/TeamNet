--day 15--

--exercitii de proceduri--

--Create new Tables--
create table Factura
	(
		FacturaId int identity(1,1),
		ClinetId int not null,
		ComandaId int not null,
	
		constraint PK_FacturaID Primary Key (FacturaId),
		constraint FK_FacturaClinetID Foreign Key (ClinetId) references Client(ClientId),
		constraint FK_FacturaComandaID Foreign Key (ComandaId) references Comanda(ComandaId)
	)

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

alter table Comanda
add Finalizata bit not null default(0)

Go


--generare Factura and LinieFactura--
create procedure P_GenereazaFactura(@ComandaId int) 
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

exec P_GenereazaFactura 5

--tranzactii--
--Se executa 2 evenimnete tranzactia e completa dupa ce ambele evenimente sunt gata--

GO

select * from Factura
select * from LinieFactura
select * from Comanda

select * from LinieComanda
select * from Produs