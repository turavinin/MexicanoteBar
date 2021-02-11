CREATE PROCEDURE [dbo].[spPedido_UpdateEmail]
	@Id int,
	@EmailCliente nvarchar(50)
AS
begin

	set nocount on;

	update dbo.Pedido
	set EmailCliente = @EmailCliente
	where Id = @Id;

end
