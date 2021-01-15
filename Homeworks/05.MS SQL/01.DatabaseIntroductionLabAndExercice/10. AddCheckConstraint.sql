USE Minions

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtLeastFiveSymbols 
CHECK (LEN('Password') >= 5); 