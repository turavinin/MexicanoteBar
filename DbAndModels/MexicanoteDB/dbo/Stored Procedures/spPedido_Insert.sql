CREATE PROCEDURE [dbo].[spPedido_Insert]
	@NombreCliente nvarchar(50),
	@EmailCliente nvarchar(50),
	@DireccionCliente nvarchar(100),
	@MenuId int,
	@FechaPedido datetime2(7),
	@CantidadTotal int,
	@PrecioTotal money,
	@Id int output
AS
begin

	set nocount on;

	insert into 
	dbo.Pedido(NombreCliente, EmailCliente, 
	DireccionCliente, MenuId, FechaPedido, CantidadTotal, PrecioTotal)

	values (@NombreCliente, @EmailCliente, 
	@DireccionCliente, @MenuId, @FechaPedido, @CantidadTotal, @PrecioTotal);

	set @Id = SCOPE_IDENTITY();

end

