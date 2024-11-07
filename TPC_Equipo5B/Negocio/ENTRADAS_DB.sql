CREATE DATABASE ENTRADAS_DB
GO
USE ENTRADAS_DB
GO

CREATE TABLE [dbo].[TiposEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
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


CREATE TABLE Usuarios (
    IDUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(100) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Pass VARCHAR(50) NOT NULL,
    TipoUsuario INT NOT NULL,
)

CREATE TABLE Clientes(
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    DNI VARCHAR(8) NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(20) NOT NULL,
    fechaNacimiento DATETIME NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    EmailPropio VARCHAR(50) NOT NULL
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
)

CREATE TABLE Imagenes (
    IdImagen INT PRIMARY KEY IDENTITY(1,1),        
    IdEvento INT NOT NULL,                        
    ImagenUrl VARCHAR(1000) NOT NULL,                               
    FOREIGN KEY (IdEvento) REFERENCES Eventos(Id)
)

CREATE TABLE Compra (
    IdCompra BIGINT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT NOT NULL,
    FechaCompra DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(50),
    MontoTotal DECIMAL(10, 2),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
)

CREATE TABLE TiposEntradas (
    IdTipoEntrada INT PRIMARY KEY IDENTITY(1,1),
    TipoEntrada NVARCHAR(50) NOT NULL
)

CREATE TABLE Entrada (
    IdEntrada INT PRIMARY KEY IDENTITY(1,1),
    IDTipoEntrada INT NOT NULL,
    IdUsuarioDueño INT NOT NULL,
    IdCliente INT NOT NULL,
    IdEvento INT NOT NULL,
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    Eliminado BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (IDUsuarioDueño) REFERENCES Usuarios(IDUsuario),
    FOREIGN KEY (IdTipoEntrada) REFERENCES TiposEntradas(IdTipoEntrada),
    FOREIGN KEY (IdEvento) REFERENCES Eventos(Id)
)

CREATE TABLE PreciosEntradas (
    IDTipoEntrada INT NOT NULL,
    IdEvento INT NOT NULL,
    Precio MONEY NOT NULL
    FOREIGN KEY (IdTipoEntrada) REFERENCES TiposEntradas(IdTipoEntrada),
    FOREIGN KEY (IdEvento) REFERENCES Eventos(Id)
)

DELETE FROM Eventos
Delete from TiposEvento
ALTER TABLE Eventos 
ALTER COLUMN Descripcion VARCHAR(1000); 

INSERT INTO TiposEvento VALUES ('Recital'), ('Teatro'), ('Shows')
INSERT INTO Eventos (Codigo, Nombre, Descripcion, Fecha, IdTipoEvento, CantidadEntradas) VALUES
-- Recitales
('RC01', 'Queen en Concierto', 'Queen se presenta en el estadio principal', DATEADD(day, 10, GETDATE()), 1, 600),
('RC02', 'COLDPLAY Music of the Spheres', 'World Tour de Coldplay, Live Buenos Aires', DATEADD(day, 25, GETDATE()), 1, 450),
('RC03', 'Maria Becerra', 'Concierto de Maria Becerra en el estadio Monumental River Plate', DATEADD(day, 25, GETDATE()), 1, 600),
('RC04', 'The Rolling Stones Live', 'Concierto de The Rolling Stones', DATEADD(day, 50, GETDATE()), 1, 400),

-- Obras Teatrales
('OT01', 'Hamlet', 'Obra teatral de Shakespeare. La obra transcurre en Dinamarca, y trata de los acontecimientos posteriores al asesinato del rey Hamlet (padre del príncipe Hamlet), a manos de su hermano Claudio. El fantasma del rey pide a su hijo que se vengue de su asesino. La obra discurre vívidamente alrededor de la locura, y de la transformación del profundo dolor en desmesurada ira. Además de explorar temas como la traición, la venganza, el incesto y la corrupción moral.', DATEADD(day, 15, GETDATE()), 2, 200),
('OT02', 'Escape Room', 'Obra de teatro con una combinación de comedia y suspenso intrigante. Cuatro personajes en una sala de escape ambientada en la segunda guerra mundial, un desafío que cumplir y superar y una serie de eventos muy extraños que empiezan a suceder que no parecen ser propios del escape room. Suspenso, risas y un final inesperado te esperan en una de las obras de teatro de Buenos Aires más populares de la temporada.', DATEADD(day, 30, GETDATE()), 2, 250),
('OT03', 'El Fantasma de la Ópera', 'Musical internacional en teatro. La obra está inspirada en hechos reales y en la novela Trilby de George du Maurier, y combina elementos de romance, terror, drama, misterio y tragedia. La historia trata sobre un ser misterioso que aterroriza la Ópera de París para atraer la atención de una joven vocalista a la que ama.', DATEADD(day, 45, GETDATE()), 2, 180),
('OT04', 'Tootsie', 'es la versión teatral de la hiper conocida película protagonizada por Dustin Hoffman que cuenta la historia de un actor arrogante quien no logra conseguir trabajo debido a su egocentrismo. Decide entonces presentarse a un casting para actrices y logra el co-protagónico femenino, pero el gran problema surge cuando se enamora de su compañera de reparto, y entonces tiene que encontrar la forma de develar su mentira, con el agravante que él ha sido mejor hombre como mujer, de lo que era como hombre con las mujeres.', DATEADD(day, 60, GETDATE()), 2, 220),

-- Shows
('SH01', 'Cirque du Soleil', 'Espectáculo acrobático del Cirque du Soleil', DATEADD(day, 20, GETDATE()), 3, 300),
('SH02', 'Disney on Ice', 'Show de Disney en hielo', DATEADD(day, 40, GETDATE()), 3, 350);

SELECT * FROM Eventos

-- Eventos de Recitales
INSERT INTO Imagenes (IdEvento, ImagenUrl)
VALUES 
(1, 'https://www.cultura.gal/sites/default/files/images/evento/01-remember-queen-g03.jpg'),
(1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTS-vcqCB2rAJzxp1nJ0LBIjO7tbOW0ZiMsVA&s'),
(1, 'https://www.radio-top40.com/wp-content/uploads/2021/07/MERCURY.jpeg'),

(2, 'https://www.web-media.com.ar/uploads/imagenes/blog/lightbox_entradas-coldplay-argentina-2022.jpg'),
(2, 'https://images.impresa.pt/expresso/2024-06-30-coldplay-8be56c7a'),
(2, 'https://www.lanacion.com.ar/resizer/v2/primer-recital-de-3ASPYJ52PZFAHB47UE7DQDLNYM.JPG?auth=186d1e87f30d870e567ddd00336e8f75c2be41a48e13b5b53d700954f8afe179&width=420&height=280&quality=70&smart=true'),
(2, 'https://i.pinimg.com/736x/94/16/95/94169561c2a67d572b24cc754b685a65.jpg'),

(3, 'https://statics.forbesargentina.com/2024/03/crop/65fda0caf1705__822x822.webp'),
(3, 'https://riverelmasgrande.com/download/multimedia.normal.965d83f1cdd4acff.TWFyw61hIEJlY2VycmEgUml2ZXIgKDEpX25vcm1hbC53ZWJw.webp'),

(4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbNrGI1PGkPn0iLdLssHqX37PHsHRkATZgOA&s'),
(4, 'https://www.entradas.com/obj/media/ES-eventim/galery/222x222/r/rolling_stones_222x222.jpg'),
(4, 'https://media.elobservador.com.uy/p/12bb5aaf0887d8e6d4a094d71d1c3741/adjuntos/367/imagenes/100/519/0100519899/1000x0/smart/rolling-stones.jpg'),

-- Eventos de Obras de Teatro
(5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSNnVMUaZ1wKb7Oi1hFRn2DyWPBK64-G3_9eg&s'),
(5, 'https://static.eldiario.es/clip/1ee52e24-e803-4d89-8d9d-08b272ff0fbc_16-9-aspect-ratio_default_0.jpg'),
(5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQLDpFR2DdlD577kbj60Gv_ZH760tB3CM3veA&s'),

(6, 'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgFJSHULQmzZDkK4mmC8ojZ3m1OH5co-lE0Jwq2rZg_hnIiZCWi6c1n0S3JJKEmpwF7ZbAzHCe9q1R5B1TASczY5cwcFS6B6w33Ehy7DI3VpMagNvQ_3VHLvzXfWmBoZ7SKQ94HW05FKkUt_jyG0JBri65fwZCRefyg6_ivZhseonPPGxIy4958MhcgXLE/s1600/Escape%20Room.jpeg'),
(6, 'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEh3JB2j43ymxlarAcJWLdV2rPDHyVlwIMirMiaJ-DpkB-Pvld5FCalrpUbiJOg-rJtrT6pn7v3eJZ6zp_GcKvGTCp0KoWkYS5xSO8ranFMTEJtVP1EyGc8pR-rXLFKXAroQKRFi3XdCps_J49LaSYx-vBDfsRMjO9Xw5hrtu2L5EBbADfP2N0hMESl8QbU/s4032/20240118_221635-01%5B1%5D.jpeg'),
(6, 'https://fotos.perfil.com/2023/12/20/trim/1040/780/1220escape-1723656.jpg'),

(7, 'https://entradas.lavanguardia.com/wp-content/uploads/2024/01/el-fantasma-de-la-opera-umusic-albeniz.jpg'),
(7, 'https://www.dondeir.com/wp-content/uploads/2020/10/el-fantasma-de-la-opera-gratis.jpg'),
(7, 'https://www.publico.es/uwu/wp-content/uploads/2024/02/NAC_2554-e1707828031775.jpg'),

(8, 'https://resizer.glanacion.com/resizer/v2/YHOODPZHJNABREI6M5VCIYYL2A.png?auth=50aff1169aa6ff124db14bd18102b8d1ba0f33d04a2ca93b84b68d304a53c0b5&width=300&height=300&smart=true'),
(8, 'https://www.clarin.com/2023/01/26/FdstB3zQF_2000x1500__1.jpg'),
(8, 'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg82t06-ZbjYD9zXalpOvG4LAm4Yd6Jl8jtSJrbYgIQVWVr3oEc36VHqA6XbV0Hfh0QsdiraZgc2zHGpwuZu2qLUe-4BaTBYbEyZzI2dymFSyowjKzg8ea8XYsFCa-IvbGF1HoxpC4rRcBAWw4R_MZZlIlZOJi8NcsZWH4Esw22g2uiuIDGfFEcoWib/w1200-h630-p-k-no-nu/20230518_222956-01%5B1%5D.jpeg'),

-- Eventos de Shows
(9, 'https://www.andorramania.net/pictures/cirque-du-soleil/cirque-du-soleil-andorra-2023-festa-pancarta.jpg'),
(9, 'https://www.estiber.com/blog/wp-content/uploads/2024/04/cirque-du-soleil-0001.jpg'),
(9, 'https://cdn-imgix.headout.com/media/images/f651944bf5b1f2fbef32cae8859b8407-23648-london-cirque-du-soleil-alegria-06.jpg?auto=format&q=90&fit=crop&crop=faces'),

(10, 'https://www.boardwalkhall.com/assets/img/241137620-DOI-D38-Atlantic-City-Shuman-Venue-Static-Kit-840x550-ArtOnly-a7c06c65f6.jpg'),
(10, 'https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,q_75,w_1200/v1/crm/fortwayne/coe_Disney-on-Ice-Let-s-Dance_647D4D5B-BE06-019E-161075E0AE8EB701_6484c66c-acbf-4156-2e4188b68ccdc98b.jpg'),
(10, 'https://i.ytimg.com/vi/vEfnrTub_RQ/sddefault.jpg'),
(10, 'https://i.ytimg.com/vi/BwW--F4agjw/maxresdefault.jpg');

-- Usuarios
INSERT INTO Usuarios (NombreUsuario, Email, Pass, TipoUsuario)
VALUES
    ('Admin', 'admin@example.com', 'admin', 1)
