--tranzactii--
--Se executa 2 evenimnete tranzactia e completa dupa ce ambele evenimente sunt gata--

select * from factura
--set exact_abort on

begin transaction MyTransaction

	insert into Factura(ClinetId)
	values (20)

	declare @comandaId int
	set @comandaId = (Select MAX(ComandaId) from Comanda)

	insert into LinieComanda(ComandaId, ProdusId, Cantitate)
	select @comandaId, 10, 1

commit transaction MyTransaction
--rollback transaction MyTransaction totul de la bigin

--real example--
GO

alter procedure P_GenereazaFactura @ComandaId int 
as
begin
	set xact_abort on --daca exista eroare in cod => rollback
	
	begin TRAN MyTran

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

	commit tran MyTran

end
--rollback transaction MyTransact


exec P_GenereazaFactura 7

--transaction exampled
set xact_abort on
begin tran 

insert into Comanda(ComandaId)
select 4

rollback
--commit

Go
alter procedure P_GenereazaClinetiTest @numar int, @commit bit
as
begin
	
	begin tran MyTran 

	declare @i int
	set @i = 1

	while @i < @numar begin

		if @i > 9 begin
			insert into Client(Nume, Prenume, CNP)
			values( 
				CONCAT('Nume', Cast(@i as nvarchar(10)))
				, CONCAT('Prenume', Cast(@i as nvarchar(10)))
				, Concat (left('0000000000000', 13 - LEN(CAST(@i as nvarchar(10)))),  Cast(@i as nvarchar(10)))
				)
		end
		else begin
			insert into Client(Nume, Prenume, CNP)
			values( 
				CONCAT('Nume0', Cast(@i as nvarchar(10)))
				, CONCAT('Prenume0', Cast(@i as nvarchar(10)))
				, CONCAT('123456789220', Cast(@i as nvarchar(10))) 
				)
		end

		set @i = @i + 1

	end

	if @commit = 1
		commit tran MyTran
	else
		rollback tran MyTran
end

select * from Client

exec P_GenereazaClinetiTest 10 ,0

exec P_GenereazaClinetiTest 100 ,1


delete from Client 