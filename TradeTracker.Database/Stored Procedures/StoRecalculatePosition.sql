USE [TradeTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE StoRecalculatePosition
	@AccessKey CHAR(36)
  , @Symbol VARCHAR(10)
AS
/*-------------------------------------------------------------------------
	Name: StoRecalculatePosition

	Description:
		Recalculates the position for a particular symbol
		from all transactions associated with the symbol.

	Input:
	@AccessKey			CHAR(36)
	@Symbol				VARCHAR(10)

	Output:
	PositionId			INT
	Symbol				VARCHAR(10)
	Quantity			DECIMAL
*/-------------------------------------------------------------------------
BEGIN
	DECLARE @Quantity DECIMAL = 0;

	SET @Quantity = (SELECT SUM(Quantity)
					   FROM [Transaction]
					  WHERE AccessKey = @AccessKey
						    AND Symbol = @Symbol);

	UPDATE Position
	   SET Quantity = @Quantity
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

	SELECT AccessKey
	     , Symbol
		 , Quantity
	  FROM Position
	 WHERE AccessKey = @AccessKey
		   AND Symbol = @Symbol;

END
GO