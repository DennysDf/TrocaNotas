
/****** Object:  Table [dbo].[Anamneses]    Script Date: 22/03/2019 19:29:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anamneses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[Tipo] [int] NOT NULL,
	[DataCad] [datetime2](7) NOT NULL,
	[IsAtivo] [bit] NOT NULL,
 CONSTRAINT [PK_Anamneses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Anamneses] ON 

INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (1, N'No momento esta em tratamendo medico?', 1, CAST(N'2019-03-19T07:54:48.5333333' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (2, N'Esta tomando alguma medicação no momento?', 1, CAST(N'2019-03-19T07:54:54.8900000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (3, N'Tem ou dteve alguma doença como hepatite, AIDS, ou outra?', 1, CAST(N'2019-03-19T07:55:00.9200000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (5, N'Você é hemofílio?', 1, CAST(N'2019-03-19T07:55:07.6100000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (6, N'Sofre de alguma doença do coração?', 1, CAST(N'2019-03-19T07:55:13.1266667' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (7, N'Sente falta de ar com frequência?', 1, CAST(N'2019-03-19T07:55:17.7666667' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (8, N'Costuma ter pés inchados', 1, CAST(N'2019-03-19T08:43:49.1400000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (9, N'Tem tosse persistente com frequencia?', 1, CAST(N'2019-03-19T08:43:54.2200000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (10, N'Alguma vez expectorou sangue?', 1, CAST(N'2019-03-19T08:43:58.1400000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (11, N'Você é diabetico?', 1, CAST(N'2019-03-22T06:01:18.6900000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (13, N'Quando se fere a feriada demora a cicatrizar?', 1, CAST(N'2019-03-22T06:03:21.0670000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (14, N'tem algum tipo de alergia?', 1, CAST(N'2019-03-22T06:03:47.9700000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (15, N'É alergico a penicilina (Benzetacil)?', 1, CAST(N'2019-03-22T06:05:01.3630000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (16, N'Alguma vez precisou tomar transfusão de sangue?', 1, CAST(N'2019-03-22T06:05:32.3000000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (17, N'Tem algum problema de estômago, rins, ou figado?', 1, CAST(N'2019-03-22T06:06:00.5670000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (18, N'Já demasiou alguma vez?', 1, CAST(N'2019-03-22T06:06:20.3000000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (19, N'Tem algum câncer, diabete ou doença do coração na sua familia?', 1, CAST(N'2019-03-22T06:07:19.6770000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (20, N'Fuma? Quantos por dia? Há quanto tempo?', 1, CAST(N'2019-03-22T06:08:43.2070000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (21, N'Bebe? Quantos por dia? Há quanto tempo?', 1, CAST(N'2019-03-22T06:09:51.6600000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (22, N'Você está grávida?', 1, CAST(N'2019-03-22T06:10:18.3930000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (23, N'Já fcou hospitalizado por algum motivo? Qual?', 1, CAST(N'2019-03-22T06:10:51.8800000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (24, N'Outras informações que julga importante referir:', 1, CAST(N'2019-03-22T06:11:25.8000000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (25, N'Tem ou teve feridas nós lábios ou na boca que demoraram a sarar?', 2, CAST(N'2019-03-22T06:12:12.0830000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (26, N'Tem hábito de ranger e/ou apertar os dentes?', 2, CAST(N'2019-03-22T06:12:51.0030000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (27, N'Tem sangramento ou dor nas gengivas?', 2, CAST(N'2019-03-22T06:13:20.1430000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (28, N'Tem dentes abalados?', 2, CAST(N'2019-03-22T06:13:41.5970000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (29, N'Utiliza fio dental?', 2, CAST(N'2019-03-22T06:14:03.2530000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (30, N'Usa  outros métodos de limpeza? Quais?', 2, CAST(N'2019-03-22T06:14:48.3800000' AS DateTime2), 1)
INSERT [dbo].[Anamneses] ([Id], [Descricao], [Tipo], [DataCad], [IsAtivo]) VALUES (31, N'Usa alguma prótese bucal? Ela o incomoda?', 2, CAST(N'2019-03-22T06:15:50.5030000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Anamneses] OFF
ALTER TABLE [dbo].[Anamneses] ADD  DEFAULT (getdate()) FOR [DataCad]
GO
ALTER TABLE [dbo].[Anamneses] ADD  DEFAULT ((1)) FOR [IsAtivo]
GO
