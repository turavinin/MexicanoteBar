CREATE PROCEDURE [dbo].[spPedido_GetById]
	@Id int
AS
begin

	set nocount on;

	select 
	[Id], [NombreCliente], [EmailCliente], 
	[DireccionCliente], [MenuId], [FechaPedido], 
	[CantidadTotal], [PrecioTotal]
	from dbo.Pedido
	where Id = @Id;

end