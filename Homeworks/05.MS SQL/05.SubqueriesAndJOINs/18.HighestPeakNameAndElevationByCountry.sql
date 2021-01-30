USE Geography
GO

SELECT TOP(5) CountryName, 
CASE
	WHEN PeakName IS NOT NULL THEN PeakName
	WHEN PeakName IS NULL THEN '(no highest peak)'
END AS [Highest Peak Name],
CASE
	WHEN Elevation IS NOT NULL THEN Elevation
	WHEN PeakName IS NULL THEN 0
END AS [Highest Peak Elevation],
CASE
	WHEN MountainRange IS NOT NULL THEN MountainRange
	WHEN PeakName IS NULL THEN '(no mountain)'
END AS [Mountain]	
	FROM (
	      SELECT c.CountryName, 
	      	     m.MountainRange,
		         p.PeakName,
	      	     p.Elevation,
	      	     DENSE_RANK() 
		    		OVER (
	      			      PARTITION BY CountryName
	      			      ORDER BY p.Elevation DESC
	      	             ) AS [ElevationRank]
	      FROM Countries AS c
		  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		  LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		  LEFT JOIN Peaks AS p ON m.id = p.MountainId
	     ) AS [ElevationRankQuery]
WHERE [ElevationRank] = 1
ORDER BY CountryName ASC,
[Highest Peak Name] ASC
