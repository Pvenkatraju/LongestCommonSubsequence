--CREATE TABLE SALES(ID INT IDENTITY, [Date] DATE, DailySales NUMERIC(10,2), Region VARCHAR(255))
--INSERT INTO SALES([Date],DailySales,Region)values(cast(getdate()-2 as date), 1006672,'R7')
--select * from SALES

SELECT TOP 1 Region from (select TOP 5 Region, Sum(DailySales) AS TotalSales
from SALES
where cast([Date] as date)>= cast(getdate()-28 as date)
Group BY Region
Order by Sum(DailySales) desc) as S
Order by S.TotalSales ASC


