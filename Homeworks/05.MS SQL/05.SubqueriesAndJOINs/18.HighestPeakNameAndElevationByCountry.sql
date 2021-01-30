USE Geography
GO

SELECT TOP(5) Country, 
			  CASE
			  	  WHEN PeakName IS NULL THEN '(no highest peak)'
				  ELSE PeakName
			  END AS [Highest Peak Name],
			  CASE
			  	  WHEN Elevation IS NULL THEN 0
				  ELSE Elevation
			  END AS [Highest Peak Elevation],
			  CASE
			  	  WHEN MountainRange IS NULL THEN '(no mountain)'
				  ELSE MountainRange
			  END AS [Mountain]	
FROM (
	  SELECT c.CountryName AS Country, 
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
ORDER BY Country ASC,
[Highest Peak Name] ASC
