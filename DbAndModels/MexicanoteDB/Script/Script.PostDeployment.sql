/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Datos default
if not exists (select * from dbo.Menu)
begin

    insert into dbo.Menu([NombrePlato], [DescripcionPlato], [PrecioPlato])
    values ('Ándale Burrito', 'Un Burrito Chihuahua Style con Porcion de Nachos y una Coca-Cola', 600),
    ('Cantinflas Con Frio', 'Un Pozole Abundante con Porcion de Quesadilla', 400),
    ('Échale Enchiladas', 'Tres Enchiladas Con Salsa de Frijoles y Cerveza Modelo', 550);

end
