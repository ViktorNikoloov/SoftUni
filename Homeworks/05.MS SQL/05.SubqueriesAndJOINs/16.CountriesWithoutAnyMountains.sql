USE Geography
GO

SELECT COUNT(c.CountryCode) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL


