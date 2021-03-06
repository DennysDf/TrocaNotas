USE [SECSAUDE]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hospitais]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[IsAtivo] [bit] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL,
	[ProfissionalId] [int] NOT NULL,
 CONSTRAINT [PK_Hospitais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[IsProprio] [bit] NOT NULL,
	[Sexo] [nvarchar](max) NULL,
	[IsAtivo] [bit] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL,
	[ProfissionalId] [int] NOT NULL,
	[CRM] [nvarchar](max) NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotaFiscais]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotaFiscais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [nvarchar](max) NULL,
	[Numero] [nvarchar](max) NULL,
	[NomeArquivo] [nvarchar](max) NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[IsAtivo] [bit] NOT NULL DEFAULT ((1)),
	[DataCad] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ProfissionalId] [int] NOT NULL,
	[IdCidadao] [int] NULL,
 CONSTRAINT [PK_NotaFiscais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[CNS] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[NomeMae] [nvarchar](max) NULL,
	[DataNasc] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[ProfissionalId] [int] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[IsAtivo] [bit] NOT NULL DEFAULT ((1)),
	[Telefone] [nvarchar](max) NULL,
	[Sexo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Procedimentos]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedimentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[ValorMed] [nvarchar](max) NULL,
	[IsAtivo] [bit] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL,
	[ProfissionalId] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Procedimentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profissionais]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profissionais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Senha] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Extensao] [nvarchar](max) NULL,
	[SecretariaId] [int] NOT NULL,
	[IsAtivo] [bit] NOT NULL DEFAULT ((1)),
	[LastLogin] [datetime2](7) NULL,
	[DataCad] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[Tipo] [int] NOT NULL,
	[Funcao] [nvarchar](max) NULL,
 CONSTRAINT [PK_Profissionais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Secretaria]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secretaria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[IsAtivo] [bit] NOT NULL DEFAULT ((1)),
	[DataCad] [datetime2](7) NOT NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Secretaria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unidades]    Script Date: 04/11/2021 12:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[IsAtivo] [bit] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL,
	[ProfissionalId] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Unidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Hospitais] ADD  DEFAULT ((1)) FOR [IsAtivo]
GO
ALTER TABLE [dbo].[Hospitais] ADD  DEFAULT (getdate()) FOR [DataCad]
GO
ALTER TABLE [dbo].[Medicos] ADD  DEFAULT ((1)) FOR [IsAtivo]
GO
ALTER TABLE [dbo].[Medicos] ADD  DEFAULT (getdate()) FOR [DataCad]
GO
ALTER TABLE [dbo].[Procedimentos] ADD  DEFAULT ((1)) FOR [IsAtivo]
GO
ALTER TABLE [dbo].[Procedimentos] ADD  DEFAULT (getdate()) FOR [DataCad]
GO
ALTER TABLE [dbo].[Procedimentos] ADD  DEFAULT ((0)) FOR [Tipo]
GO
ALTER TABLE [dbo].[Unidades] ADD  DEFAULT ((1)) FOR [IsAtivo]
GO
ALTER TABLE [dbo].[Unidades] ADD  DEFAULT (getdate()) FOR [DataCad]
GO
ALTER TABLE [dbo].[Unidades] ADD  DEFAULT ((0)) FOR [Tipo]
GO
ALTER TABLE [dbo].[Hospitais]  WITH CHECK ADD  CONSTRAINT [FK_Hospitais_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Hospitais] CHECK CONSTRAINT [FK_Hospitais_Profissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos_Profissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[NotaFiscais]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscais_Profissionais_IdCidadao] FOREIGN KEY([IdCidadao])
REFERENCES [dbo].[Pacientes] ([Id])
GO
ALTER TABLE [dbo].[NotaFiscais] CHECK CONSTRAINT [FK_NotaFiscais_Profissionais_IdCidadao]
GO
ALTER TABLE [dbo].[NotaFiscais]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscais_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[NotaFiscais] CHECK CONSTRAINT [FK_NotaFiscais_Profissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Profissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[Procedimentos]  WITH CHECK ADD  CONSTRAINT [FK_Procedimentos_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Procedimentos] CHECK CONSTRAINT [FK_Procedimentos_Profissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[Profissionais]  WITH CHECK ADD  CONSTRAINT [FK_Profissionais_Secretaria_SecretariaId] FOREIGN KEY([SecretariaId])
REFERENCES [dbo].[Secretaria] ([Id])
GO
ALTER TABLE [dbo].[Profissionais] CHECK CONSTRAINT [FK_Profissionais_Secretaria_SecretariaId]
GO
ALTER TABLE [dbo].[Unidades]  WITH CHECK ADD  CONSTRAINT [FK_Unidades_Profissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Unidades] CHECK CONSTRAINT [FK_Unidades_Profissionais_ProfissionalId]
GO
