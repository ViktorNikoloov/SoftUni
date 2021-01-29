USE Geography
GO

SELECT CountryCode, COUNT(MountainId) AS [Mountain Ranges]
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode