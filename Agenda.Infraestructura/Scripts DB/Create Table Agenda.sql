USE [AgendaDB]
GO

/****** Object:  Table [dbo].[Agenda]    Script Date: 24/4/2024 19:54:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agenda](
	[IdAgenda] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Nacionalidad] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [int] NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[FechaNacimiento] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[IdUser] [bigint] NOT NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[IdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

