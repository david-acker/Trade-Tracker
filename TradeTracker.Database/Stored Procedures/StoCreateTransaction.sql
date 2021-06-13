CREATE PROCEDURE StoCreateTransaction
	@AccessKey CHAR(36)
  , @Symbol VARCHAR(10)
  , @TradeDate DATETIME2(2)
  , @TradePrice DECIMAL
  , @Quantity DECIMAL
  , @Notional DECIMAL
AS
/*-------------------------------------------------------------------------
	Name: StoCreateTransaction

	Description:
		Creates a new transaction.

	Input:
	@AccessKey			CHAR(36)
	@Symbol				VARCHAR(10)
	@TradeDate			DATETIME2(2)
	@TradePrice			DECIMAL
	@Quantity			DECIMAL
	@Notional			DECIMAL

	Output:
	TransactionId		INT
	Symbol				VARCHAR(10)
	TradeDate			DATETIME2(2)
	TradePrice			DECIMAL
	Quantity			DECIMAL
	Notional			DECIMAL
*/-------------------------------------------------------------------------
BEGIN
	DECLARE @TransactionId INT;

	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO [Transaction] (
			AccessKey
		  , Symbol
		  , TradeDate
		  , TradePrice
		  , Quantity
		  , Notional
		)
		VALUES (
			@AccessKey
		  , @Symbol
		  , @TradeDate
		  , @TradePrice
		  , @Quantity
		  , @Notional
		);

		SET @TransactionId = SCOPE_IDENTITY();

		UPDATE Position
		   SET Quantity = Quantity + @Quantity
		 WHERE AccessKey = @AccessKey
			   AND Symbol = @Symbol;

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
			END;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH;

	IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;
	ELSE
		RETURN 1;

	SELECT TransactionId
		 , AccessKey
		 , Symbol
		 , TradeDate
		 , TradePrice
		 , Quantity
		 , Notional
	  FROM [Transaction]
	 WHERE TransactionId = @TransactionId;
END;
GO