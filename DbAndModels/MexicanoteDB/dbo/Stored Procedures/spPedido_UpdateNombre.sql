CREATE PROCEDURE [dbo].[spPedido_UpdateNombre]
	@Id int,
	@NombreCliente nvarchar(50)
AS
begin

	set nocount on;

	update dbo.Pedido
	set NombreCliente = @NombreCliente
	where Id = @Id;

end
