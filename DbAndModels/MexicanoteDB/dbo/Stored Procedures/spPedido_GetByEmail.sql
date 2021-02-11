CREATE PROCEDURE [dbo].[spPedido_GetByEmail]
	@EmailCliente nvarchar(50)
AS
begin

	set nocount on;

	select 
	[Id], [NombreCliente], [EmailCliente], 
	[DireccionCliente], [MenuId], [FechaPedido], 
	[CantidadTotal], [PrecioTotal]
	from dbo.Pedido
	where EmailCliente = @EmailCliente;

end
