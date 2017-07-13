-- day 13 --

--drop table Frima

--create table Frima
--	(
--		ID int Primary Key,
--		Nume nvarchar(200) not Null,
--		OrasID int 
--	)

	
--create table Frima
--	(
--		ID int,
--		Nume nvarchar(200) not Null,
--		OrasID int 
--		Constraint PK_Firma primary key(ID)
--	)


--column must be not null
--alter table Persoana
--add constraint PK_Persoana Primary Key(ID)


--alter table Album
--alter column id int not null

--Go

--alter table Album
--add constraint PK_Album Primary Key(ID)

--alter table Persoana
--add constraint FK_PersoanaOras
--FOREIGN KEY (OrasID) REFERENCES Oras(ID);

--alter table Album
--add constraint FK_AlbumArtist
--FOREIGN KEY (ArtistID) REFERENCES Artist(ID);

--(
--	ID int primary key,
--	PersoanaID int,
--	FirmaID int
--	constraint FK_PersoanaID FOREIGN KEY (PersoanaID) REFERENCES Persoana(ID),
--	constraint FK_FirmaID FOREIGN KEY (FirmaID) REFERENCES Frima(ID),
--)

--alter table PersoanaFirma
--add constraint PK_PersoanaFirma Primary Key (ID)


--create table PlayList
--(
--	ID int,
--	MelodieID int,
--	PersoanaID int
--	constraint PK_PlayList Primary Key (ID)
--	constraint FK_PlayList_MelodieID FOREIGN KEY (MelodieID) REFERENCES Melodie(ID),
--	constraint FK_PlayLsit_PersoanaID FOREIGN KEY (PersoanaID) REFERENCES Persoana(ID),
--)

--alter table Oras
--add constraint DF_Populatie default 0 for populatie

--insert into oras(nume, TaraId)
--values ('NEW_BangKok', 2)


select * from Persoana

select * from Oras

create table PersoanaFirma

create table Concediu(
	ID int not null identity(1,1),
	PersoanaID int not null,
	FirmaID int not null,
	OrasDestinatieID int not null,
	DataInceput date not null default cast(DATEADD(dd, 1, GETDATE()) as date),
	DateIntorci date not null,
	DuratInZile as DATEDIFF(dd, DataInceput, DateIntorci),

	Constraint PK_Concediu Primary Key (ID),
	Constraint PK_Concediu_OrasDestinatieID foreign Key (OrasDestinatieID) references oras(ID),
	Constraint PK_Concediu_PersoanaID foreign Key (PersoanaID) references Persoana(ID),
	Constraint PK_Concediu_FirmaID foreign Key (FirmaID) references Frima(ID),
	Constraint CK_DATE CHECK (DateIntorci >= DataInceput) 
)


