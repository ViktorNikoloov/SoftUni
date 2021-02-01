USE Gringotts
GO

SELECT SUM([Difference]) AS [SumDifference]
	FROM(
		 SELECT FirstName AS [Host Wizard],
		 	    DepositAmount AS [Host Wizard Deposit],
		 	    LEAD (FirstName)   
		 	   		OVER (ORDER BY Id) AS [Guest Wizard],
		 	    LEAD (DepositAmount)
		 	   		OVER(ORDER BY Id) AS [Guest Wizard Deposit],
		 	    (DepositAmount - LEAD(DepositAmount)
		 	   		OVER (ORDER BY Id)) AS [Difference]
		 FROM WizzardDeposits
		) AS [WizardsAllInformation]

	/*SecondSolution*/
SELECT SUM([Difference]) AS [SumDifference]
	FROM(
		 SELECT original.FirstName								 AS [Host Wizard],
		 	    original.DepositAmount							 AS [Host Wizard Deposit],
		 		plusOne.FirstName								 AS [Guest Wizard],
		 		plusOne.DepositAmount							 AS [Guest Wizard Deposit],
		 		(original.DepositAmount - plusOne.DepositAmount) AS [Difference]
		 FROM WizzardDeposits AS original
		 JOIN WizzardDeposits AS plusOne ON plusOne.Id = original.Id + 1
		) AS [WizardsAllInformation]
		
