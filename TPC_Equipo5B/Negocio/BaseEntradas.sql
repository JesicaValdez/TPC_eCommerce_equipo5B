use master 
go
create database ENTRADAS_DB
go
use ENTRADAS_DB
go

CREATE TABLE [dbo].[TiposEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Fecha] [DateTime] NOT NULL,
	[IdTipoEvento] [int] NOT NULL,
	[PrecioEntrada] [money] NOT NULL,
	[CantidadEntradas] [int] NOT NULL,
 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD  CONSTRAINT [FK_Eventos_TiposEvento] FOREIGN KEY([IdTipoEvento])
REFERENCES [dbo].[TiposEvento] ([Id])
GO

ALTER TABLE [dbo].[Eventos] CHECK CONSTRAINT [FK_Eventos_TiposEvento]
GO



insert into TiposEvento values ('Recital'),('Deporte'), ('Teatro')
insert into Eventos values ('GH25', 'Iron Maiden en Buenos Aires', 'Iron Maiden toca en Buenos Aires', getdate()+50, 1, 80000, 50000), 
('MB01', 'River Plate vs Atletico Mineiro', 'semis de la Libertadores', getdate()+8, 2, 111111111, 80000)

