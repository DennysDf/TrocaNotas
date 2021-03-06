USE [SECSAUDE]
GO
/****** Object:  Table [dbo].[Trocas]    Script Date: 05/11/2021 00:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trocas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [int] NOT NULL,
	[IsAtivo] [bit] NOT NULL DEFAULT ((1)),
	[DataCad] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ProfissionalId] [int] NOT NULL,
	[CidadaoId] [int] NOT NULL,
	[Data] [varchar](max) NULL,
 CONSTRAINT [PK_Trocas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Trocas]  WITH CHECK ADD  CONSTRAINT [FK_Trocas_Profiissionais_CidadaoId] FOREIGN KEY([CidadaoId])
REFERENCES [dbo].[Pacientes] ([Id])
GO
ALTER TABLE [dbo].[Trocas] CHECK CONSTRAINT [FK_Trocas_Profiissionais_CidadaoId]
GO
ALTER TABLE [dbo].[Trocas]  WITH CHECK ADD  CONSTRAINT [FK_Trocas_Profiissionais_ProfissionalId] FOREIGN KEY([ProfissionalId])
REFERENCES [dbo].[Profissionais] ([Id])
GO
ALTER TABLE [dbo].[Trocas] CHECK CONSTRAINT [FK_Trocas_Profiissionais_ProfissionalId]
GO
ALTER TABLE [dbo].[Trocas]  WITH CHECK ADD  CONSTRAINT [FK_Trocas_Profissionais_CidadaoId] FOREIGN KEY([CidadaoId])
REFERENCES [dbo].[Pacientes] ([Id])
GO
ALTER TABLE [dbo].[Trocas] CHECK CONSTRAINT [FK_Trocas_Profissionais_CidadaoId]
GO
