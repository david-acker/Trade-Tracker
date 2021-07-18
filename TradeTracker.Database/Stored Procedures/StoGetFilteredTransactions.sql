USE [TradeTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE StoGetFilteredTransactions
	@AccessKey CHAR(36)
  , @Skip INT = NULL
  , @Take INT = NULL
  , @StartDate DATETIME2(2) = NULL
  , @EndDate DATETIME2(2) = NULL
  , @Symbol VARCHAR(10) = NULL
  , @TransactionType CHAR(1) = NULL
  , @OrderByField VARCHAR(25) = NULL
  , @OrderByDirection CHAR(1) = NULL
AS
/*-------------------------------------------------------------------------
	Name: StoGetFilteredTransactions

	Description:
		Returns a filtered and paginated list of transactions.

	Input:
	@AccessKey			CHAR(36)
	@Skip				INT
	@Take				INT
	@StartDate			DATETIME2(2)
	@EndDate			DATETIME2(2)
	@Symbol				VARCHAR(10)
	@TransactionType	CHAR(1)
	@OrderByField		VARCHAR(25)
	@OrderByDirection	CHAR(1)

	Output 1:
	TransactionId		INT
	Symbol				VARCHAR(10)
	TradeDate			DATETIME2(2)
	TradePrice			DECIMAL
	Quantity			DECIMAL
	Notional			DECIMAL

	Output 2:
	TransactionCount	INT
*/-------------------------------------------------------------------------
BEGIN
	--Reference names for valid Transaction Types
	DECLARE @TT_Buy CHAR(1) = 'B';
	DECLARE @TT_Sell CHAR(1) = 'S';

	--Reference names for valid Order By Fields
	DECLARE @OBF_TransactionId VARCHAR(25) = 'TransactionId';
	DECLARE @OBF_Symbol VARCHAR(25) = 'Symbol';
	DECLARE @OBF_TradeDate VARCHAR(25) = 'TradeDate';
	DECLARE @OBF_TradePrice VARCHAR(25) = 'TradePrice';
	DECLARE @OBF_Quantity VARCHAR(25) = 'Quantity';
	DECLARE @OBF_Notional VARCHAR(25) = 'Notional';

	DECLARE @OBF_Default VARCHAR(25) = @OBF_TradeDate;
	
	--Reference names for valid Order By Directions
	DECLARE @OBD_Ascending CHAR(1) = 'A';
	DECLARE @OBD_Descending CHAR(1) = 'D';

	CREATE TABLE #Temp (
		   TransactionId INT
		 , Symbol VARCHAR(10)
		 , TradeDate DATETIME2(2)
		 , TradePrice DECIMAL
		 , Quantity DECIMAL
		 , Notional DECIMAL
	);

	--Set pagination parameters
	IF @Skip IS NULL OR @Skip < 0
		SET @Skip = 0;
	IF @Take IS NULL OR @Take < 0
		SET @Skip = 25;

	--Set Transaction Type
	IF @TransactionType IS NOT NULL
		BEGIN
			SET @TransactionType = UPPER(@TransactionType);

			SET @TransactionType = 
				CASE @TransactionType
					WHEN @TT_Buy THEN @TT_Buy
					WHEN @TT_Sell THEN @TT_Sell
					ELSE NULL
				END;
		END;

	--Set Order By field
	IF @OrderByField IS NULL
		SET @OrderByField = @OBF_Default;
	ELSE
		BEGIN
			SET @OrderByField = UPPER(@OrderByField);

			SET @OrderByField = 
				CASE @OrderByField
					WHEN UPPER(@OBF_TransactionId) THEN @OBF_TransactionId
					WHEN UPPER(@OBF_Symbol) THEN @OBF_Symbol
					WHEN UPPER(@OBF_TradeDate) THEN @OBF_TradeDate
					WHEN UPPER(@OBF_TradePrice) THEN @OBF_TradePrice
					WHEN UPPER(@OBF_Quantity) THEN @OBF_Quantity
					ELSE @OBF_Default
				END;
		END;

	--Set Order By direction
	IF @OrderByDirection IS NULL
		BEGIN
			SET @OrderByDirection = 
				CASE @OrderByField
					WHEN @OBF_TradeDate THEN @OBD_Descending
					WHEN @OBF_Quantity THEN @OBD_Descending
					ELSE @OBD_Ascending
				END;
		END;
	ELSE
		BEGIN
			SET @OrderByDirection = UPPER(@OrderByDirection);

			IF (@OrderByDirection != @OBD_Ascending 
				AND @OrderByDirection != @OBD_Descending)
				BEGIN
					SET @OrderByDirection = 
						CASE @OrderByField
							WHEN @OBF_TradeDate THEN @OBD_Descending
							WHEN @OBF_Quantity THEN @OBD_Descending
							ELSE @OBD_Ascending
						END;
				END;
		END;

	INSERT INTO #Temp (
		   TransactionId 
		 , Symbol
		 , TradeDate
		 , TradePrice
		 , Quantity
		 , Notional
	)
	SELECT
		   TransactionId
		 , Symbol
		 , TradeDate
		 , TradePrice
		 , Quantity
		 , Notional
	  FROM [Transaction]
	 WHERE AccessKey = @AccessKey
		   AND Symbol = CASE WHEN @Symbol IS NOT NULL THEN @Symbol ELSE Symbol END
		   AND TradeDate >= CASE WHEN @StartDate IS NOT NULL THEN @StartDate ELSE TradeDate END
		   AND TradeDate <= CASE WHEN @EndDate IS NOT NULL THEN @EndDate ELSE TradeDate END
		   AND Quantity >= CASE @TransactionType WHEN @TT_Buy THEN 0 ELSE ABS(Quantity) END
		   AND Quantity <= CASE @TransactionType WHEN @TT_Sell THEN 0 ELSE ABS(Quantity) END;

	SELECT
		   TransactionId
		 , Symbol
		 , TradeDate
		 , TradePrice
		 , Quantity
		 , Notional
	  FROM #Temp
	 ORDER BY 
		   CASE WHEN (@OrderByField = @OBF_TransactionId
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN TransactionId END ASC,
		   CASE WHEN (@OrderByField = @OBF_TransactionId 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN TransactionId END DESC,
		   CASE WHEN (@OrderByField = @OBF_Symbol 
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN Symbol END ASC,
		   CASE WHEN (@OrderByField = @OBF_Symbol 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN Symbol END DESC,
		   CASE WHEN (@OrderByField = @OBF_TradeDate 
					  AND @OrderByDirection = @OBD_Ascending)
						THEN TradeDate END ASC,
		   CASE WHEN (@OrderByField = @OBF_TradeDate 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN TradeDate END DESC,
		   CASE WHEN (@OrderByField = @OBF_Quantity 
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN Quantity END ASC,
		   CASE WHEN (@OrderByField = @OBF_Quantity 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN Quantity END DESC,
		   CASE WHEN (@OrderByField = @OBF_Notional 
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN Notional END ASC,
		   CASE WHEN (@OrderByField = @OBF_Notional 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN Notional END DESC
	OFFSET @Skip ROWS
	 FETCH NEXT @Take ROWS ONLY;

	SELECT COUNT(1)
	  FROM #Temp;

	DROP TABLE #Temp;
END
GO