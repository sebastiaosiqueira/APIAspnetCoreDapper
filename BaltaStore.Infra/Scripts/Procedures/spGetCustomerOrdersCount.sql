CREATE PROCEDURE spGetCustomerOrdersCount
@Document CHAR(11)
AS
SELECT 
c.[ID],
CONCAT(C.[FirstName], '', c.[LastName]) as [Name],
c.[Document],
Count(o.Id)
FROM
[Customer]  c inner JOIN [Order] o on o.[CustomerId] = c.[Id]