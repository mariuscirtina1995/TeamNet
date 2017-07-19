select * from LinieComanda

delete Client where Nume = 'Mimescu'

select * from Comanda

delete LinieComanda 
from LinieComanda lc 
inner join Comanda c on c.ComandaId = lc.ComandaId 
where ClientId = 1; 
delete Comanda where ClientId = 1

delete LinieComanda where ProdusId = 1

select * from LinieComanda
select * from Comanda

select * from LinieFactura
select * from Factura