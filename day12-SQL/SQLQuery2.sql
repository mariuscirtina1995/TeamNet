--create table Melodie(
--	Id int,
--	Name nvarchar(100),
--	Author nvarchar(100),
--	HasVideo bit,
--	ReleaseDate datetime,
--	DurationInSeconds int
--)

--insert into Melodie(Id, Name, Author, HasVideo, ReleaseDate, DurationInSeconds)
--values (1, N'Acum', 'AmCazut Pe Gheata', 0, '2011-03-02', 120)
--       , (1, N'AmMurit', 'Doru', 1, '2014-05-04', 80)
--	   , (1, N'Nu Mai Conteaza', 'MariaDeLaGalati', 1, '2013-11-02', 74)
--	   , (1, N'Astept', 'Toto', 0, '2017-09-01', 150)

--insert into Oras(Id, nume, tara, populatie)
--values (1, 'Constanta', 'Ungaria', 500000)
--	,(2, 'Londra', 'UK', 1000000)
--	,(3, 'Berlin', 'Germania', 6000000)

--select * from Melodie
--delete from Melodie

--insert into Persoana(Id, Nume, Prenume, [Data Nasterii])
--values (8, N'Grigore', N'Mihai', '1998-02-05')


--insert into Oras(Id, nume, tara, populatie)
--values (4, 'Constanta', 'Ungaria', 500000)


--select *
--from Persoana
--CROSS JOIN Oras

--select *
--from Persoana
--inner join ORAS on Persoana.OrasID = Oras.Id

--select *
--from Persoana
--left join ORAS on Persoana.OrasID = Oras.Id

--select *
--from Persoana
--right join ORAS on Persoana.OrasID = Oras.Id

--select *
--from Persoana
--full join ORAS on Persoana.OrasID = Oras.Id


select * from Persoana 

select * from Oras

select * from Tara

--inner join whith alias on tables
select p.Id, p.NumePrenume, o.Nume
from Persoana as p
inner join Oras as o on p.OrasID = o.Id

insert into Melodie(Id, Nume, AlbumID, DurataInSecunde)
values	(1, N'Melodie1', 10, 87)
		, (2, N'Melodie2', 20, 90)
		, (3, N'Melodie3', 30, 110)
		, (4, N'Melodie4', 40, 130)

insert into Album(Id, Nume, ArtistID, Gen, DataLansarii)
values	(1, N'Album1', 100, N'Metal', '1990-02-04')
		, (2, N'Album2',200, N'Popular', '1980-01-09')
		, (3, N'Album3', 300, N'Dance', '1989-01-06')
		, (4, N'Album4', 400, N'NextGen', '1995-07-03')

select * from Melodie
select * from Artist
Select * from Album


select alb.ID, alb.Nume, alb.Nume, count(m.ID) as [Numar de Melodii] , AVG(m.DurataInSecunde) as [Medie Durata]
from Melodie m
inner join Album alb on m.AlbumID = alb.ID
inner join Artist art on alb.ArtistID = art.ID
group by alb.id, alb.Nume, art.Nume


select m.Nume, m.DurataInSecunde, MedieDurataMelodii.[Medie Durata], count(m.ID) as [NumberOfMelodii]
from Melodie m
inner join (
		select
			alb.ID as AlbumID
			, AVG(m.DurataInSecunde) as [Medie Durata]
		from Melodie m
			inner join Album alb on m.AlbumID = alb.ID
			inner join Artist art on alb.ArtistID = art.ID
		group by alb.ID
	) as MedieDurataMelodii on MedieDurataMelodii.AlbumID = m.AlbumID
group by m.Nume, m.DurataInSecunde, MedieDurataMelodii.[Medie Durata]
having m.DurataInSecunde > MedieDurataMelodii.[Medie Durata]