USE Minions

ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime 
DEFAULT GETDATE() FOR LastLoginTime