CREATE PROCEDURE [dbo].[spMenu_GetAll]
AS

begin

	set nocount on;

	select [Id], [NombrePlato], [DescripcionPlato], [PrecioPlato]
	from dbo.Menu;

end
