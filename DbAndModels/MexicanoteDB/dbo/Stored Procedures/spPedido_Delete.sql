CREATE PROCEDURE [dbo].[spPedido_Delete]
	@Id int
AS
begin

	set nocount on;

	delete
	from dbo.Pedido
	where Id = @Id;

end
