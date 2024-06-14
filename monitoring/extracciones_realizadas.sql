CREATE TABLE [dbo].[extracciones_realizadas]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Licencia] NVARCHAR(50) NOT NULL, 
    [Documentos] INT NOT NULL, 
    [Fecha] DATETIME NOT NULL
)
