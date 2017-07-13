-- Day 13 --


select * from persoana

alter Table Persoana 
alter column  [Data Nasterii] date NOT NULL

insert into Persoana(ID, nume, prenume, OrasID, [Data Nasterii])
values (9, 'Popa', 'Matei', 5, '2019-02-03')


select * from persoana

select * from Melodie

select * from PlayList

select * from PersoanaFirma

alter table Persoana
drop constraint cnpCheck

alter table Persoana
add constraint cnpCheck check (CNP not like '0%')

alter table Persoana
add constraint cnpCheck check (left(CNP,1) <> 0)