create table ContatoApi.Contato (
 id integer IDENTITY not null,
 contato_nome varchar(60) not null,
 contato_sexo varchar(1) not null,
 contato_dt_nascimento Date not null,
 contato_idade int not null
);

ALTER TABLE ContatoApi.Contato
   ADD CONSTRAINT PK_CONTATO_ID PRIMARY KEY CLUSTERED (id);