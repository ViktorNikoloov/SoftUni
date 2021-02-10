USE WMS
GO

SELECT j.JobId, ISNULL(SUM(Quantity * Price), 0) AS [Total]
	FROM JOBS AS j
	LEFT JOIN Orders AS o ON j.JobId = o.JobId
	LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
	LEFT JOIN Parts AS p ON op.PartId = p.PartId
	WHERE j.FinishDate IS NOT NULL
	GROUP BY  j.JobId
	ORDER BY SUM(Price) DESC,
			 j.JobId ASC