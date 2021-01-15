USE Minions

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id 
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameIsAtLeastThreeSymbols 
CHECK (LEN('Username') >= 3); 
