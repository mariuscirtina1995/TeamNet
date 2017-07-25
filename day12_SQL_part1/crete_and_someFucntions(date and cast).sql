--create database MyDatabase

--ctr + k + c -- Comment
--ctr + k + u -- Decomment
--create table Persoana (
--	Id int,
--	Nume nvarchar(200),
--	Prenume nvarchar(200)
--)

alter table Persoana 
add Varsta tinyint;

alter table Persoana
drop column Varsta

alter table Persoana
alter column Varsta tinyint

insert into Persoana (Id, Nume, Prenume) 
values (7, N'Petrscu', N'Marius')

select Id, Nume, Prenume from Persoana 

delete from Persoana where id = 1

delete from Persoana

update Persoana set Varsta = 27, Nume = 'Stefanescu' 
where Id = 1

insert into Persoana(Id, Nume, Prenume, Varsta)
values (1, N'Stefanescu', N'Robert', 27)
       , (2, N'Popescu', N'Popica', 50)
       , (3, N'Marinescu', N'Marinica', 14)
       , (4, N'Ionescu', N'Ionica', 20)
       , (5, N'Georgescu', N'Georgica', 34)


select * 
from Persoana 
where id <> 1
-- <> is !=
	
select * from Persoana 

select * 
from Persoana
where id = 3 
and Varsta between 10 and 20

select *
from Persoana
where Prenume like '%a'

select *
from Persoana
where Prenume like '[A-Z]%'

select *
from Persoana
where varsta is null or varsta = 14

select *
from Persoana
order by Varsta asc

select *
from persoana
order by id
OFFSET 2 rows	-- sare 2 lini
fetch next 3 rows only -- intoarce urmatoarele 3 linii 

--primele 3 linii
select top 3 * 
from Persoana

select count(varsta)
from Persoana

select Nume + ' ' + Prenume as [Nume Premume]
from Persoana

select cast (SUM(varsta) as decimal) / AVG(varsta)
from Persoana


-- date sys.functions--
select GETDATE() --data serverului !!!

select DATEADD(d, 1, GETDATE())

select DATEADD(yy, 1, GETDATE())

select DATEADD(m, 1, GETDATE())

select DATEADD(yy, 1, DATEADD(m, 1, DATEADD(d, 1, GETDATE())))

select DATEDIFF(d, '2017-01-01', '2017-07-12')

select DATEPART(DY, '2017-07-09')


alter table persoana
add NumePrenume as Nume + ' ' + Prenume

alter table persoana
add [Data Nasterii] date

alter table persoana
add varsta as datediff(yy, [Data Nasterii], getdate())

--convert and cast functions--
select cast('10' as int) 
select convert(int, '10')
select convert(datetime, '07-12-2017', 101)

select *
from persoana
order by cast(varsta as varchar(100)) asc

select Id, Nume from Persoana
union all
select Id, Nume from Oras

select Id from Persoana
intersect
select Id from Oras

select Id from Persoana
except
select Id from Oras


select OrasID, count(*), avg(Orasid)
from Persoana
group by OrasID

select t.id, t.Nume, count(*) as [Count]
from Persoana p
inner join oras o on p.OrasID = o.Id
inner join tara t on o.TaraId = t.Id
group by t.id, t.Nume
having count(*) > 0
order by count(*) desc


select NumePrenume
	,Varsta
	,case 
		when varsta = 19 then 'Este 19'
		when varsta > 18 then 'Major'  
		else 'Minor'
	end as Stare
from Persoana

select NumePrenume
	,Varsta
	,case varsta
		when 19 then 'Este 19'
		when 40 then 'Batran'  
		else 'nustu'
	end as Stare2
from Persoana