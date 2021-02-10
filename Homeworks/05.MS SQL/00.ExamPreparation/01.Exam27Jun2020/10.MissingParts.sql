USE WMS
GO

SELECT  *
	FROM Parts AS p
	LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
	LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON p.PartId = op.PartId

	WHERE j.[Status] = 'In Progress'
	 AND (p.StockQty + op.Quantity) >= pn.Quantity
	 ORDER BY p.PartId ASC


	 select p.PartId,
       p.Description,
       PN.Quantity as Required,
       p.StockQty,
       IIF(O.Delivered = 0, OP.Quantity, 0)
from Parts as p
         LEFT join PartsNeeded PN on p.PartId = PN.PartId
         LEFT join OrderParts OP on p.PartId = OP.PartId
         LEFT join Orders O on O.OrderId = OP.OrderId
         LEFT join Jobs J on J.JobId = PN.JobId
where j.Status not like 'Finished'
  and (p.StockQty + IIF(O.Delivered = 0, OP.Quantity, 0)) < (PN.Quantity)
ORDER BY PartId

--List all parts that are needed for active jobs (not Finished) without sufficient quantity in stock and in pending orders (the sum of parts in stock and parts ordered is less than the required quantity). Order them by part ID (ascending).
--Required columns:
--•	Part ID
--•	Description
--•	Required – number of parts required for active jobs
--•	In Stock – how many of the part are currently in stock
--•	Ordered – how many of the parts are expected to be delivered (associated with order that is not Delivered)



--p.PartId, 
--		p.Description, 
--		pn.Quantity AS [Required], 
--		p.StockQty AS [In Stock],
--		op.Quantity AS [Ordered]