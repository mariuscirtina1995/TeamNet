/*
Produs : ProdusId, nume, categorieId, Pret(2 zecimale)

Categorie : CategorieId, nume

Client : ClientId, nume, Prenume, CNP, 

Comanda : ComandaId, ClientId,

LinieFactura: LinieFacturaId, FacturaID, ProdusID, Cantitate

*/


create table Produs(
	ProdusID int not null ,
	Nume varchar(100) not null,
	CategorieID int not null,
	Pret decimal(8,2) not null check (Pret > 10),

	Constraint PK_Produs Primary Key (ProdusID),
	Constraint FK_Ca
}


