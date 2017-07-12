alter table Oras
drop column Tara

create table Tara(
	Id int,
	Nume nvarchar(100)
)

insert into Tara(Id, nume)
values (1, 'Ungaria')
	,(2, 'UK')

alter table Oras
add TaraId int


select p.Id, p.NumePrenume, o.Nume as [Nume Oras], t.Nume as [Nume Tara]
from Persoana as p
inner join Oras as o on p.OrasID = o.Id
inner join (
	select *
	from Tara
	where id = 1
	) t on t.id = o.TaraId

--exemplu subcereri:

select 
	p.nume
	, p.varsta
	, MediePeTara.MedieVarsta
from Persoana p
	inner join Oras as o on p.OrasID = o.Id
	inner join Tara as t on t.Id = o.TaraId
	inner join (
			select 
				t.id
				, t.nume
				, avg(p.varsta) MedieVarsta
			from Persoana p
				inner join Oras as o on p.OrasID = o.Id
				inner join Tara as t on t.Id = o.TaraId
			group by t.id, t.Nume
			) as MediePeTara on MediePeTara.id = p.id
where p.varsta > MediePeTara.MedieVarsta



select * from Melodie
select * from Artist
Select * from Album
