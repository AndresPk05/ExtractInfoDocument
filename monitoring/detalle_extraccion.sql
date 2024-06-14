CREATE TABLE [dbo].[detalle_extraccion]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Nombre_Documento] NVARCHAR(150) NULL, 
    [TipoDocumento] NCHAR(10) NULL, 
    [Id_extraccion] UNIQUEIDENTIFIER NULL
    FOREIGN KEY (Id_extraccion) REFERENCES extracciones_realizadas(Id)
)
