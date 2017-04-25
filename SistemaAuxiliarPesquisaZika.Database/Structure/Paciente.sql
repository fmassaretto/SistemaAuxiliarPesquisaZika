CREATE TABLE [dbo].[Paciente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NumeroCaso] INT NOT NULL, 
    [NomeCompleto] VARCHAR(200) NOT NULL, 
    [CPF] VARCHAR(50) NULL, 
    [RG] VARCHAR(50) NULL, 
    [Endereco] VARCHAR(200) NULL, 
    [Bairro] VARCHAR(50) NULL, 
    [Cidade] VARCHAR(50) NULL, 
    [UBSFrequenta] VARCHAR(100) NULL, 
    [Email] VARCHAR(100) NULL, 
    [Telefone] VARCHAR(50) NULL, 
    [DataNascimento] DATETIME NULL
)
