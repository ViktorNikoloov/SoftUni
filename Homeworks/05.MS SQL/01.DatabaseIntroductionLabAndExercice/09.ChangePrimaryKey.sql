USE Minions
GO

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07BB5C2A07]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername PRIMARY KEY (Id, Username)