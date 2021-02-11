CREATE TABLE [dbo].[Pedido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NombreCliente] NVARCHAR(50) NOT NULL,
    [EmailCliente] NVARCHAR(50) NOT NULL,
    [DireccionCliente] NVARCHAR(100) NOT NULL,
    [MenuId] INT NOT NULL, 
    [FechaPedido] DATETIME2 NOT NULL,
    [CantidadTotal] INT NOT NULL, 
    [PrecioTotal] MONEY NOT NULL
)
