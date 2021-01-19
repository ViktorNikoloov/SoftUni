USE Geography
GO	

SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
		END AS [Currency]
	FROM Countries
	ORDER BY CountryName ASC

	--CASE
 --   WHEN Quantity > 30 THEN 'The quantity is greater than 30'
 --   WHEN Quantity = 30 THEN 'The quantity is 30'
 --   ELSE 'The quantity is under 30'