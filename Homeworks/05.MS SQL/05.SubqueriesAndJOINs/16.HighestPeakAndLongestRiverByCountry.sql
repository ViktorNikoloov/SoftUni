USE Geography
GO

SELECT TOP(5) c.CountryName, 
			  MAX(p.Elevation) AS [HighestPeakElevation], 
		   	  MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
	FULL OUTER JOIN MountainsCountries AS mc 
					ON c.CountryCode = mc.CountryCode
	FULL OUTER JOIN Mountains AS m 
					ON mc.MountainId = m.Id
	FULL OUTER JOIN Peaks AS p 
					ON m.Id = p.MountainId
	FULL OUTER JOIN CountriesRivers AS cr 
					ON c.CountryCode = cr.CountryCode
	FULL OUTER JOIN Rivers AS r 
					ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC,
		 [LongestRiverLength] DESC,
		 c.CountryName ASC