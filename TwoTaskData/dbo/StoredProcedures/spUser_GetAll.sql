﻿CREATE PROCEDURE [dbo].[spUser_GetAll]
	AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, UserName, Email, [Password], PasswordSalt
	FROM [dbo].[User]
	ORDER BY Id;
END
