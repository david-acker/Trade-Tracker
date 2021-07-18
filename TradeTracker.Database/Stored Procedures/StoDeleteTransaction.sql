USE [TradeTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE StoDeleteTransaction
	@TransactionId INT
  , @AccessKey CHAR(36)
AS
/*-------------------------------------------------------------------------
	Name: StoDeleteTransaction

	Description:
		Deletes an existing transaction.

	Input:
	@TransactionId		INT
	@AccessKey			CHAR(36)
*/-------------------------------------------------------------------------
BEGIN
	DECLARE @Symbol VARCHAR(10);
	DECLARE @Quantity DECIMAL;

	BEGIN TRANSACTION;
	BEGIN TRY

		SELECT @Symbol = Symbol
			 , @Quantity = Quantity
		  FROM [Transaction]
		 WHERE TransactionId = @TransactionId
			   AND AccessKey = @AccessKey;

		UPDATE Position
		   SET Quantity = Quantity - @Quantity
		 WHERE AccessKey = @AccessKey
		       AND Symbol = @Symbol;

		DELETE FROM [Transaction]
		 WHERE TransactionId = @TransactionId
		       AND AccessKey = @AccessKey;

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH;

	IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;
	ELSE
		RETURN 1;
END;
GO