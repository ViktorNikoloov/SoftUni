USE WMS
GO

SELECT * 
	FROM (
			SELECT DISTINCT p.PartId, 
			p.[Description], 
			pn.Quantity AS [Required], 
			p.StockQty AS [In Stock], 
			IIF(op.Quantity IS NOT NULL, op.Quantity, 0)  AS [Ordered]
			FROM Parts AS p
			LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
			LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
			LEFT JOIN Orders AS o ON j.JobId = o.JobId
			LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
			WHERE j.[Status]  NOT LIKE 'Finished'
		) [InfoQuery] 
	WHERE [Required] > [In Stock] + [Ordered]
	ORDER BY PartId