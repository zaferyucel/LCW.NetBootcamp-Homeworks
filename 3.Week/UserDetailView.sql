CREATE VIEW [dbo].[UserDetailView]
AS
SELECT        concat_ws (' ', dbo.Users.Name, dbo.Users.Surname) AS [Full Name], dbo.Users.Email, dbo.Users.Phone AS [Phone Number], dbo.Cities.CityName AS [City Name]
FROM            dbo.Cities INNER JOIN
                         dbo.Users ON dbo.Cities.CityId = dbo.Users.CityId
