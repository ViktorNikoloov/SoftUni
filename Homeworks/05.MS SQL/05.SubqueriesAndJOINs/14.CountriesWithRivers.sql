USE Geography
GO

SELECT TOP(5) crs.CountryName, r.RiverName
	FROM Countries AS crs 
	LEFT JOIN Continents AS cts ON crs.ContinentCode = cts.ContinentCode
	LEFT OUTER JOIN CountriesRivers AS cr ON crs.CountryCode = cr.CountryCode
	LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE cts.ContinentName = 'Africa'
	ORDER BY crs.CountryName ASC


--Write a query that selects:
--•	CountryName
--•	RiverName
--Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
