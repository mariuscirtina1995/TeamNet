-- Proceduri --

--Go
--create procedure P_ProceduraMea
--as
--begin
--	select 1
--	select 2	
--	select 3
--end 

--Go

--drop procedure P_ProceduraMea

--Go

--alter procedure P_ProceduraMea
--as
--begin
--	create Table Test(Id int, Nume nvarchar(100))
--	insert into Test(id, Nume)
--	values (1,'test1'), (2,'test2')
--	drop table Test
--end 

--exec P_ProceduraMea

--create procedure P_AdaugaProdus 
--	@nume varchar(200)
--	, @categorieId int
--	, @pret decimal(8,2)

--as
--begin
	
--	insert into Produs(Nume, CategorieID, Pret)
--	values(@nume, @categorieId, @pret)
	
--end

---- select SCOPE_IDENTITY //doar in procedura!

--select * from Produs

--exec P_AdaugaProdus 'Televizor Philips2', 4, 2100  

--exec P_AdaugaProdus @nume = 'Televizor Philips3', @pret=2100, @categorieId = 4  

--select @@IDENTITY


----exercitii proceduro--

--create procedure P_AddCommnad
--	@ClientID int
--	, @ProdusID int
--	, @Cantitate int
--as
--begin
	
--	insert into Comanda(ClientId)
--	values(@ClientID) 

--	declare @lastID int
--	select @lastID = max(ComandaId) from Comanda

--	insert into LinieComanda(ComandaId, ProdusId, Cantitate)
--	values(@lastID ,@ProdusID, @Cantitate)

--end

--exec P_AddCommnad 2, 3, 1

--exec P_AddCommnad 
--	@ClientID = 2
--	, @ProdusID = 3
--	, @Cantitate = 1



--create procedure P_StergeComanda
--	@ComandaID int
--as
--begin
	
--	delete 
--	from LinieComanda
--	where ComandaId = @ComandaID

--	delete
--	from Comanda
--	where ComandaId = @ComandaID

--end

--exec P_StergeComanda 2

--select * from Comanda
--select * from LinieComanda


--create procedure P_BetterAddCommnad
--	@ClientID int
--	, @ProdusID int
--	, @Cantitate int
--as
--begin
--	declare @firstMaxID int
--	select @firstMaxID = max(ComandaId) from Comanda

--	insert into Comanda(ClientId)
--	values(@ClientID) 

--	declare @secondMaxID int
--	select @secondMaxID = max(ComandaId) from Comanda
	
--	if (@firstMaxID <> @secondMaxID) begin
--		insert into LinieComanda(ComandaId, ProdusId, Cantitate)
--		values(@secondMaxID ,@ProdusID, @Cantitate)
--	end

--end

--exec P_AddCommnad 
--	@ClientID = 4
--	, @ProdusID = 3
--	, @Cantitate = 4

--While--
--declare @i int
--set @i = 1;

--while @i < 3 begin

--	declare @c int 
--	set @c = @i + 1
--	exec P_BetterAddCommnad @i, @i, @c
--	set @i = @i + 1
--end


--select * from Comanda

--Cursor--

declare @clineid int
declare @nume nvarchar(200)
declare @prenume nvarchar(200)

declare cr cursor
for select ClientId, Nume, Prenume from Client

open cr
fetch next from cr into  @clineid, @nume, @prenume

while @@FETCH_STATUS = 0
begin
	exec P_AdaugaProdus
		'Nume2'
		,2
		,1200 

	select 
	@clineid as [Client ID]
	, @nume as [Client Nume]
	, @prenume as [Client Prenume]
	fetch next from cr into  @clineid, @nume, @prenume
end

close cr
deallocate cr

select * from Produs


--Error Raising--
--try catch--
--raiserror-

--de obicei folosim 16
raiserror('EROAREA MEA DE OM NEBUN', 16, 1)
