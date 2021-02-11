CREATE TABLE [dbo].[Menu]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NombrePlato] NVARCHAR(50) NOT NULL, 
    [DescripcionPlato] NVARCHAR(250) NOT NULL, 
    [PrecioPlato] MONEY NOT NULL
)
