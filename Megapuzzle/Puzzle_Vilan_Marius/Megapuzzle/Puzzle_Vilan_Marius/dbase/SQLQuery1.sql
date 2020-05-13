CREATE PROC UserAdd
@username nvarchar(50),
@password nvarchar(50)
AS
INSERT INTO AUTH(username,password)
VALUES (@username,@password)