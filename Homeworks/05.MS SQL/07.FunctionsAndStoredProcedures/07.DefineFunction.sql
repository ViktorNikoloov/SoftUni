USE SoftUni
GO

CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(20), @Word VARCHAR(20))
RETURNS BIT
AS
BEGIN
	DECLARE @WordLen INT = LEN(@Word);
	DECLARE @Index INT = 1;
		WHILE(@Index <= @WordLen)
			BEGIN
				IF(CHARINDEX(SUBSTRING(@Word, @Index, 1), @SetOfLetters) = 0)
					BEGIN
						RETURN 0
					END
				SET @Index +=1
			END
		RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')
GO