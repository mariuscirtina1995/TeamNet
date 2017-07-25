/*
Produs:
ProdusId, -> PK IDENTITY(1,1)
Nume, -> NOT NULL, NVARCHAR(200)
CategorieId, -> FK NOT NULL
Pret -> DECIMAL(8,2) NOT NULL, CHECK Pret>0
 
Categorie:
CategorieId, -> PK IDENTITY(1,1)
Nume -> NOT NULL, NVARCHAR(200)
 
Client:
ClientId, -> PK IDENTITY(1,1)
Nume, -> NOT NULL NVARCHAR(200)
Prenume,  -> NOT NULL NVARCHAR(200)
CNP -> CHAR(13) NOT NULL UNIQUE
 
Comanda:
ComandaId, -> PK IDENTITY(1,1)
ClientId -> FK NOT NULL
 
LinieComanda:
LinieComandaId, -> PK IDENTITY(1,1)
ComandaId, -> FK NOT NULL
ProdusId, -> FK NOT NULL
Cantitate -> INT NOT NULL, CHECK <> 0, DEFAULT(1)
*/

create Table Categorie(
	CategorieID int identity(1,1),
	Nume nvarchar(200),
	Constraint PK_CategorieID primary key(CategorieID)
)


create table Produs (
	ProdusID int identity(1,1),
	Nume nvarchar(100) not null,
	CategorieID int not null,
	Pret decimal(8,2) not null check (Pret > 0),
	
	Constraint PK_ProdusID primary key(ProdusID),
	Constraint FK_CategorieID Foreign Key (CategorieID) references Categorie(CategorieID)
)

create table Client (
	ClientId int identity(1,1),
	Nume nvarchar(200) not null,
	Prenume nvarchar(200) not null,
	CNP char(13) NOT NULL UNIQUE,

	Constraint PK_ClientID primary key(ClientId),
)

create table Comanda (
	ComandaId int identity(1,1),
	ClientId int not null,

	Constraint PK_ComandaID primary key(ComandaId),
	Constraint FK_Comanda_ClientID Foreign Key (ClientId) references Client(ClientId)
)


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

insert into Categorie(Nume)
values
  ('Laptop')
, ('Monitor')
, ('Telefon')
, ('Televizor')
 
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
 
insert into Client(Nume, Prenume, CNP)
values
  ('Stefanescu', 'Robert', '1900227112233')
, ('Marinescu', 'Marinica', '1600303112233')
, ('Vasilescu', 'Vasilica', '6010903112233')
, ('Popescu', 'Popica', '5050610112233')
, ('Iliescu', 'Ion', '3971010112233')
 
insert into Comanda(ClientId)
values
  (1)
, (1)
, (2)
, (3)
, (5)
 
insert into LinieComanda(ComandaId, ProdusId, Cantitate)
values
  (1, 1, 1)
, (1, 9, 2)
, (2, 9, -1)
, (3, 5, 1)
, (4, 13, 1)
, (4, 12, 1)
, (5, 3, 1)
 
select * from Categorie

select * from Client

select * from Produs

select * from Comanda

select * from LinieComanda


select p.Nume as [Numar de Produse], c.nume as [Nume Categorie]
from Produs p
inner join Categorie c on p.CategorieID = c.CategorieID
order by c.Nume

select count(*) as [Numar de Produse], c.nume as [Nume Categorie]
from Produs p
inner join Categorie c on p.CategorieID = c.CategorieID
group by c.Nume
order by count(*)

select avg(p.Pret) as [Medie pe Produse], c.nume as [Nume Categorie]
from Produs p
inner join Categorie c on p.CategorieID = c.CategorieID
group by c.Nume
order by count(*)


select Comanda.ComandaId, Sum(LinieComanda.Cantitate * Produs.pret)
from Comanda
inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
inner join Produs on Produs.ProdusID = LinieComanda.ProdusId
group by Comanda.ComandaId
having Sum(LinieComanda.Cantitate * Produs.pret) > 0


select
	Client.ClientId as [Client ID]
	, Client.Nume as [Nume Cleint] 
	, Sum(LinieComanda.Cantitate * Produs.pret) as [Pret TOTAL]
from Comanda
	inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId
	inner join Produs on Produs.ProdusID = LinieComanda.ProdusId
	inner join Client on Client.ClientId = Comanda.ClientId
group by Client.ClientId, Client.Nume
order by Sum(LinieComanda.Cantitate * Produs.pret) desc



--get gender from cnp--
select *
	,CNP,
	case when left(CNP, 1) in (1,3,5,7) then 'Masculin'
		 when left(CNP, 1) in (2,4,6,8) then 'Feminin'
	else
		'Neutru'
	end as 'Gender'
from Client
	

--get birth date from cnp--
select ClientId, Nume, Prenume
	,CNP,
	case when left(CNP, 1) in (1,2) 
			then CAST (CONCAT('18',SUBSTRING(CNP, 2, 2), '/', SUBSTRING(CNP, 4, 2), '/', SUBSTRING(CNP, 6, 2))  as date)
 		 
		 when left(CNP, 1) in (3,4) 
			then CAST (CONCAT('19',SUBSTRING(CNP, 2, 2), '/', SUBSTRING(CNP, 4, 2), '/', SUBSTRING(CNP, 6, 2)) as date)

		 when left(CNP, 1) in (5,6) 
			then CAST (CONCAT('20',SUBSTRING(CNP, 2, 2), '/', SUBSTRING(CNP, 4, 2), '/', SUBSTRING(CNP, 6, 2)) as date)

	end as [Data Nasterii]
from Client


select
	Client.ClientId as [Client ID]
	, Client.Nume as [Nume Cleint] 
	, Sum(LinieComanda.Cantitate) as [Cantitate Cumparata]
from Client
	inner join Comanda on Client.ClientId = Comanda.ClientId
	inner join LinieComanda on LinieComanda.ComandaId = Comanda.ComandaId	
group by Client.ClientId, Client.Nume
