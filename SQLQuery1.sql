create database Malade
use Malade
create table tmalade
(
id int primary key identity(1,1),
noms varchar (50),
adresse nvarchar(50),
datenaissance date,
etatcivil varchar(50),
taille float,
poids float,
)
select *from tmalade
insert into tmalade values('MUNANGA','les volcans','2001-10-20','celibataire','1.65','56.9')
delete from tmalade where id=12