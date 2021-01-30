USE Geography
GO

SELECT ContinentCode, 
	   CurrencyCode, 
	   Usage
FROM(
	  SELECT ContinentCode, 
			 CurrencyCode, 
			 Usage, 
			 DENSE_RANK()
				OVER (
						PARTITION BY ContinentCode 
						ORDER BY Usage DESC
					 ) AS [UsageRanking]
	  FROM (
			 SELECT ContinentCode, 
			 	     CurrencyCode, 
			 	     COUNT(CurrencyCode) AS [Usage]
			 FROM Countries
			 GROUP BY ContinentCode, CurrencyCode
		   ) AS [UsageQuery]
			 WHERE Usage > 1
	) AS [DenseRankQuery]
WHERE UsageRanking = 1
ORDER BY ContinentCode

