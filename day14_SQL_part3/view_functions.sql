-- DAY 14 --

select * from Comanda
select * from LinieComanda
select * from Produs
select * from Client
select * from Categorie
Go

--select distinct Comanda.ComandaId
--from Comanda
--inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
--inner join Produs on LinieComanda.ProdusId = Produs.ProdusID
--where Produs.Pret >= 2500
--group by Comanda.ComandaId


--select Comanda.ComandaId
--from Comanda
--inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
--inner join Produs on LinieComanda.ProdusId = Produs.ProdusID
--inner join Categorie on Categorie.CategorieID = Produs.CategorieID
--where Produs.Pret >= 2000 and Categorie.Nume like '%Televizor%'
--group by Comanda.ComandaId


--select 
--	Comanda.ComandaId [ComandaID]
--	, Client.ClientId as [IDClinet]
--	, Client.Nume as [NumeClinet]
--	, Client.Prenume as [PrenumeClinet]
--	, Sum(LinieComanda.Cantitate * Produs.Pret) as [ValoareComanda]
--	, Sum(LinieComanda.Cantitate) [CantitateProdus]
--from Comanda
--inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
--inner join Produs on LinieComanda.ProdusId = Produs.ProdusID
--inner join Categorie on Categorie.CategorieID = Produs.CategorieID
--inner join Client on Client.ClientId = Comanda.ClientId
--group by Comanda.ComandaId, Client.ClientId, Client.Nume, Client.Prenume 


--views--
--GO

--CREATE VIEW V_Comanda AS
--select 
--	Comanda.ComandaId [ComandaID]
--	, Client.ClientId as [ClientID]
--	, Client.Nume as [NumeClinet]
--	, Client.Prenume as [PrenumeClinet]
--	, Sum(LinieComanda.Cantitate * Produs.Pret) as [ValoareComanda]
--	, Sum(LinieComanda.Cantitate) [CantitateProdus]
--from Comanda
--inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
--inner join Produs on LinieComanda.ProdusId = Produs.ProdusID
--inner join Categorie on Categorie.CategorieID = Produs.CategorieID
--inner join Client on Client.ClientId = Comanda.ClientId
--group by Comanda.ComandaId, Client.ClientId, Client.Nume, Client.Prenume 

--GO

--select * 
--from V_Comanda
--inner join Client on Client.ClientId = V_Comanda.ClientID

--variables--
--GO

--declare @nume_variabila int
--declare @second_variable date
--declare @my_variable int

--set @nume_variabila = 1
--select @my_variable = Comanda.ClientId
--from Comanda 
--where ComandaId = 1

--select @my_variable as [My Variable]

--select *
--from Client
--where Client.ClientId = @my_variable


--declare @pret_Target decimal(8,2)
--set @pret_Target = 2600

--select *
--from Produs
--where Pret > @pret_Target

--select *
--from Produs
--where Pret < @pret_Target

--select *
--from Produs
--where Pret = @pret_Target



--Functii--
--Go

--In Programmability/Functions/Scalat-valued

--declare @valoare int
--set @valoare = 2

--select dbo.F_Functie(@valoare)

--Go
--create Function F_Functie(@valoare int)
--returns int 
--	as 
--		begin  
--			return @valoare + 3
--		end

--Go
--	-- need dbo.fucntion_name
--select dbo.F_Functie()

--drop function dbo.F_Functie

--select *
--from Produs
--where dbo.F_Functie(pret) = 2203

--create Function F_GetSexFromCNP (@varaible char(13))
--returns char(1) 
--as
--	begin
--		declare @rezult char(1)
--		select @rezult = 
--				case 
--					when LEFT(@varaible, 1) in (1,3,5,7) then 'M'
--					else 'F'
--				end
--		return @rezult
--	end

--Go

--Create Function F_GetDataNasterii(@CNP char(13))
--returns date
--as
--begin	
--	return
--	case when left(@CNP, 1) in (1,2) 
--			then CAST (CONCAT('18',SUBSTRING(@CNP, 2, 2), '/', SUBSTRING(@CNP, 4, 2), '/', SUBSTRING(@CNP, 6, 2))  as date)
 		 
--		 when left(@CNP, 1) in (3,4) 
--			then CAST (CONCAT('19',SUBSTRING(@CNP, 2, 2), '/', SUBSTRING(@CNP, 4, 2), '/', SUBSTRING(@CNP, 6, 2)) as date)

--		 when left(@CNP, 1) in (5,6) 
--			then CAST (CONCAT('20',SUBSTRING(@CNP, 2, 2), '/', SUBSTRING(@CNP, 4, 2), '/', SUBSTRING(@CNP, 6, 2)) as date)
--	end
--end

--Go

--select * 
--	, dbo.F_GetSexFromCNP(CNP) as Gender
--	, dbo.F_GetDataNasterii(CNP) as DataNasterii
--from Client

--declare @tmp table(id int) --tabela temporara
--insert into @tmp(id)
--values (1), (2), (3)
--select * from @tmp

--create function F_GetComenzi()
--returns @rezult table (ComandaId int, ClinetId int)
--as
--	begin
--		insert into @rezult(ComandaId, ClinetId)
--		select * from Comanda
--		return
--	end

--select * from dbo.F_GetComenzi()

--create function F_GetComenziCuValoareMinima(@valoareMin int)
--returns @rezult table (
--	ComandaId int
--	, ClinetId int
--	, NumeClient nvarchar(200)
--	, PrenumeClient nvarchar(200)
--	, ValoareComanda int
--	, CantitateProdus int )

--as
--	begin

--		insert into @rezult(ComandaId
--				, ClinetId
--				, NumeClient
--				, PrenumeClient
--				, ValoareComanda
--				, CantitateProdus)
--		select * from V_Comanda
--		where ValoareComanda > @valoareMin

--		return
--	end
	
--select * from dbo.F_GetComenziCuValoareMinima(2000)

--create function F_GetStringWithoutDiacritics(@string nvarchar(max))
--returns varchar(4000)
--as
--	begin
--		declare @rezult nvarchar(max)
--		declare @diacritics nchar(4)
--		set @diacritics = 'șăîțâ'
--		set @rezult = replace(@string, N'ă', 'a')
--		set @rezult = replace(@rezult, N'ș', 's')
--		set @rezult = replace(@rezult, N'î', 'i')
--		set @rezult = replace(@rezult, N'ț', 't')
--		set @rezult = replace(@rezult, N'â', 'a')
									   
--		set @rezult = replace(@string, N'Ă', 'A')
--		set @rezult = replace(@rezult, N'Ș', 'S')
--		set @rezult = replace(@rezult, N'Î', 'I')
--		set @rezult = replace(@rezult, N'Ț', 'T')
--		set @rezult = replace(@rezult, N'Â', 'A')
--		return @rezult				   
--	end

select * from V_Comanda

GO

create function F_CalculeazaValoareMedie(@ComandaID int)
returns decimal(8,2) --pret mediu
as
	begin
		declare @var decimal(8,2)

		select @var = ValoareComanda/CantitateProdus
			from V_Comanda
			where CantitateProdus > 0 and ComandaID = @ComandaID
		return @var
	end

Go


select ComandaID as ComandaID, dbo.F_CalculeazaValoareMedie(ComandaID) as ValoareMedie
from Comanda


select ComandaID as ComandaID, dbo.F_CalculeazaValoareMedieEvenNgative(ComandaID) as ValoareMedie
from Comanda
