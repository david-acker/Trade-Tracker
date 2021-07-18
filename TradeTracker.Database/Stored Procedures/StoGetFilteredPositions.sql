USE [TradeTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE StoGetFilteredPositions
	@AccessKey CHAR(36)
  , @Skip INT = NULL
  , @Take INT = NULL
  , @Symbol VARCHAR(10) = NULL
  , @PositionType CHAR(1) = NULL
  , @OrderByField VARCHAR(25) = NULL
  , @OrderByDirection CHAR(1) = NULL
AS
/*-------------------------------------------------------------------------
	Name: StoGetFilteredPositions

	Description:
		Returns a filtered and paginated list of positions.

	Input:
	@AccessKey			CHAR(36)
	@Skip				INT
	@Take				INT
	@PositionType		CHAR(1)
	@OrderByField		VARCHAR(25)
	@OrderByDirection	CHAR(1)

	Output 1:
	Symbol				VARCHAR(10)
	Quantity			DECIMAL

	Output 2:
	PositionCount		INT
*/-------------------------------------------------------------------------
BEGIN
	--Reference names for valid Position Types
	DECLARE @TT_Long CHAR(1) = 'L';
	DECLARE @TT_Short CHAR(1) = 'S';

	--Reference names for valid Order By Fields
	DECLARE @OBF_Symbol VARCHAR(25) = 'Symbol';
	DECLARE @OBF_Quantity VARCHAR(25) = 'Quantity';

	DECLARE @OBF_Default VARCHAR(25) = @OBF_Quantity;
	
	--Reference names for valid Order By Directions
	DECLARE @OBD_Ascending CHAR(1) = 'A';
	DECLARE @OBD_Descending CHAR(1) = 'D';

	CREATE TABLE #Temp (
		   Symbol VARCHAR(10)
		 , Quantity DECIMAL
	);

	--Set pagination parameters
	IF @Skip IS NULL OR @Skip < 0
		SET @Skip = 0;
	IF @Take IS NULL OR @Take < 0
		SET @Skip = 25;

	--Set Position Type
	IF @PositionType IS NOT NULL
		BEGIN
			SET @PositionType = UPPER(@PositionType);

			SET @PositionType = 
				CASE @PositionType
					WHEN @TT_Long THEN @TT_Long
					WHEN @TT_Short THEN @TT_Short
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
					WHEN UPPER(@OBF_Symbol) THEN @OBF_Symbol
					WHEN UPPER(@OBF_Quantity) THEN @OBF_Quantity
					ELSE @OBF_Default
				END;
		END;

	--Set Order By direction
	IF @OrderByDirection IS NULL
		BEGIN
			SET @OrderByDirection = 
				CASE @OrderByField
					WHEN @OBF_Symbol THEN @OBD_Ascending
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
							WHEN @OBF_Symbol THEN @OBD_Ascending
							WHEN @OBF_Quantity THEN @OBD_Descending
							ELSE @OBD_Ascending
						END;
				END;
		END;

	INSERT INTO #Temp (
		   Symbol
		 , Quantity
	)
	SELECT
		   Symbol
		 , Quantity
	  FROM [Position]
	 WHERE AccessKey = @AccessKey
		   AND Symbol = CASE WHEN @Symbol IS NOT NULL THEN @Symbol ELSE Symbol END
		   AND Quantity >= CASE @PositionType WHEN @TT_Long THEN 0 ELSE ABS(Quantity) END
		   AND Quantity <= CASE @PositionType WHEN @TT_Short THEN 0 ELSE ABS(Quantity) END;

	SELECT
		   Symbol
		 , Quantity
	  FROM #Temp
	 ORDER BY 
		   CASE WHEN (@OrderByField = @OBF_Symbol 
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN Symbol END ASC,
		   CASE WHEN (@OrderByField = @OBF_Symbol 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN Symbol END DESC,
		   CASE WHEN (@OrderByField = @OBF_Quantity 
					  AND @OrderByDirection = @OBD_Ascending) 
						THEN Quantity END ASC,
		   CASE WHEN (@OrderByField = @OBF_Quantity 
					  AND @OrderByDirection = @OBD_Descending) 
						THEN Quantity END DESC
	OFFSET @Skip ROWS
	 FETCH NEXT @Take ROWS ONLY;

	SELECT COUNT(1)
	  FROM #Temp;

	DROP TABLE #Temp;
END
GO
