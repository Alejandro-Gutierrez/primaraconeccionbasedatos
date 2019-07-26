create database pruebaconexion;
use pruebaconexion;

create table Usuario(
idUsuario int not null auto_increment,
Documento varchar(45),
Nombres varchar(45),
Primer_apellido varchar(45),
Segundo_apellido varchar(45),
Edad int(11),
Genero varchar(45),
Celular varchar(45),


primary key(idUsuario)
)engine=innodb;

