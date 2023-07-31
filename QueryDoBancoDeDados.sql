CREATE DATABASE [ToDoListDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoListDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ToDoListDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoListDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ToDoListDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [ToDoListDB]
GO
/****** Object:  Table [dbo].[Prioridade]    Script Date: 30/07/2023 21:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Prioridade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 30/07/2023 21:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarefa]    Script Date: 30/07/2023 21:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarefa](
	[Id] [uniqueidentifier] NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[DataDeInicio] [datetime2](7) NULL,
	[DataDeConclusao] [datetime2](7) NULL,
	[PrioridadeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tarefa] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_Prioridade_PrioridadeId] FOREIGN KEY([PrioridadeId])
REFERENCES [dbo].[Prioridade] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_Prioridade_PrioridadeId]
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_Status_StatusId]
GO


INSERT INTO Status(Titulo) Values('Não Iniciada')
INSERT INTO Status(Titulo) Values('Em Andamento')
INSERT INTO Status(Titulo) Values('Concluída')

INSERT INTO Prioridade(Titulo) Values('Baixa')
INSERT INTO Prioridade(Titulo) Values('Média')
INSERT INTO Prioridade(Titulo) Values('Alta')

INSERT INTO Tarefa(Descricao,PrioridadeId,StatusId,Titulo) Values('Criar sua primeira tarefa do teste do DArtagnan',3,1,'Criar a primeira tarefa')