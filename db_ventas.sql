CREATE DATABASE [Ventas]
GO

USE [Ventas]

 /***************** TABLAS *******************/

 /*TABLA CLIENTE*/
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[email] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*TABLA CONCEPTO*/
CREATE TABLE [dbo].[concepto](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_venta] [bigint] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioUnitario] [decimal](16, 2) NOT NULL,
	[importe] [decimal](16, 2) NOT NULL,
	[id_producto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*TABLA PRODUCTO*/
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precioUnitario] [decimal](16, 2) NOT NULL,
	[costo] [decimal](16, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*TABLA USUARIOS*/
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](256) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[passToken] [varchar](256) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*TABLA VENTAS*/
CREATE TABLE [dbo].[venta](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[total] [decimal](16, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/******************* RELACIONES **********************/

ALTER TABLE [dbo].[concepto]  WITH NOCHECK ADD  CONSTRAINT [FK_producto_concepto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[concepto] CHECK CONSTRAINT [FK_producto_concepto]
GO
ALTER TABLE [dbo].[concepto]  WITH NOCHECK ADD  CONSTRAINT [FK_venta_concepto] FOREIGN KEY([id_venta])
REFERENCES [dbo].[venta] ([id])
GO
ALTER TABLE [dbo].[concepto] CHECK CONSTRAINT [FK_venta_concepto]
GO
ALTER TABLE [dbo].[venta]  WITH NOCHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
USE [master]
GO
ALTER DATABASE [Ventas] SET  READ_WRITE 
GO


INSERT INTO Usuarios(email,password,nombre) VALUES ('admin@admin.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin')