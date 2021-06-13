USE [TradeTracker]
GO

CREATE TABLE [Position] (
	PositionId INT IDENTITY(1,1)
  , AccessKey CHAR(36) NOT NULL
  , Symbol VARCHAR(10) NOT NULL
  , Quantity DECIMAL NOT NULL
  CONSTRAINT PK_Position PRIMARY KEY (PositionId)
);
GO

ALTER TABLE [Position] 
	ADD CONSTRAINT UQ_Position_AccessKey_Symbol 
	UNIQUE (AccessKey, Symbol);
GO