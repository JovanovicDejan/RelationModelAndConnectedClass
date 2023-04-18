USE TSQL;
GO

--SELECT
ALTER PROC dbo.KlijentSelect
AS
SET LOCK_TIMEOUT 3000
BEGIN TRY
	SELECT * FROM dbo.Klijenti
END TRY
BEGIN CATCH
	 RETURN ERROR_MESSAGE()
END CATCH
GO


--INSERT
ALTER PROC dbo.KlijentiInsert
	@naziv nvarchar(40),
	@kontakt nvarchar(30),
	@grad nvarchar(15),
	@zemlja nvarchar(15)
AS
SET LOCK_TIMEOUT 3000
BEGIN TRY
	INSERT INTO dbo.Klijenti(Naziv, Kontakt, Grad, Zemlja)
	VALUES
	(@naziv, @kontakt, @grad, @zemlja)
	RETURN 0
END TRY

BEGIN CATCH
	RETURN ERROR_NUMBER()
END CATCH
GO

--Prodcedure for delete client
ALTER PROC dbo.KlijentiDelete
	@klijentid int
AS
SET LOCK_TIMEOUT 3000

IF NOT EXISTS( SELECT KlijentId FROM dbo.Klijenti WHERE dbo.Klijenti.KlijentId = @klijentid)
BEGIN
	RETURN -1
END
BEGIN TRY
	DELETE FROM dbo.Klijenti WHERE KlijentId=@klijentid
	RETURN 0
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER()
END CATCH
GO


--UPDATE
ALTER PROC dbo.KlijentUpdate
	@klijentid int,
	@naziv nvarchar(40),
	@kontakt nvarchar(30),
	@grad nvarchar(15),
	@zemlja nvarchar(15)
AS
SET LOCK_TIMEOUT 3000

IF NOT EXISTS(SELECT KlijentId FROM dbo.Klijenti WHERE KlijentId=@klijentid)
BEGIN
	RETURN -1
END
BEGIN TRY
	UPDATE dbo.Klijenti
	SET
	Naziv = @naziv,
	Kontakt = @kontakt,
	Grad = @grad,
	Zemlja = @zemlja
	WHERE dbo.Klijenti.KlijentId = @klijentid
	RETURN 0
END TRY
BEGIN CATCH
	RETURN ERROR_MESSAGE()
END CATCH
GO

SELECT * FROM dbo.Klijenti ORDER BY KlijentId DESC

