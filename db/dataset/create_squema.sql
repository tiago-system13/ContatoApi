IF

EXISTS (SELECT * FROM sys.schemas WHERE name = 'ContatoApi')

DROP

SCHEMA [ContatoApi]

GO

CREATE

SCHEMA [ContatoApi] AUTHORIZATION [dbo]

GO