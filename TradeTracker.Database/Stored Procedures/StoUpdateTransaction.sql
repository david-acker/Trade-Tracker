USE [TradeTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE StoUpdateTransaction
	@TransactionId INT
  , @AccessKey CHAR(36)
  , @Symbol VARCHAR(10)
  , @TradeDate DATETIME2(2)
  , @TradePrice DECIMAL
  , @Quantity DECIMAL
  , @Notional DECIMAL
AS
/*-------------------------------------------------------------------------
	Name: StoUpdateTransaction

	Description:
		Updates an existing transaction.

	Input:
	@TransactionId		INT
	@AccessKey			CHAR(36)
	@Symbol				VARCHAR(10)
	@TradeDate			DATETIME2(2)
	@TradePrice			DECIMAL
	@Quantity			DECIMAL
	@Notional			DECIMAL
*/-------------------------------------------------------------------------
BEGIN
	DECLARE @Original_Symbol VARCHAR(10);
	DECLARE @Original_TradeDate DATETIME2(2);
	DECLARE @Original_TradePrice DECIMAL;
	DECLARE @Original_Quantity DECIMAL;
	DECLARE @Original_Notional DECIMAL;

	DECLARE @QuantityDelta DECIMAL;

	BEGIN TRANSACTION
		BEGIN TRY
			
			SELECT @Original_Symbol = Symbol
				 , @Original_TradeDate = TradeDate
			     , @Original_TradePrice = TradePrice
				 , @Original_Quantity = Quantity
				 , @Original_Notional = Notional
			  FROM [Transaction]
			 WHERE TransactionId = @TransactionId
				   AND AccessKey = @AccessKey;

			UPDATE [Transaction]
			   SET Symbol = @Symbol
			     , TradeDate = @TradeDate
			     , TradePrice = @TradePrice
			     , Quantity = @Quantity
			     , Notional = @Notional
		     WHERE TransactionId = @TransactionId
				   AND AccessKey = @AccessKey;

			IF @Original_Symbol != @Symbol
				BEGIN
					UPDATE Position
					   SET Quantity = Quantity - @Original_Quantity
					 WHERE Symbol = @Original_Symbol
						   AND AccessKey = @AccessKey;

					UPDATE Position
					   SET Quantity = Quantity + @Quantity
					 WHERE Symbol = @Symbol
					       AND AccessKey = @AccessKey;

				IF @@ROWCOUNT = 0
					BEGIN
						INSERT INTO Position (
							   AccessKey
							 , Symbol
							 , Quantity
						)
						VALUES (
							   @AccessKey
							 , @Symbol
							 , @Quantity
						);
					END
				END
			ELSE
				BEGIN
					SET @QuantityDelta = @Quantity - @Original_Quantity;

					UPDATE Position
					   SET Quantity = Quantity + @QuantityDelta
					 WHERE Symbol = @Original_Symbol
					       AND AccessKey = @AccessKey;
				END

		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION;
		END CATCH

	IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;
END
GO