USE [TradeTracker]
GO

CREATE TABLE [Transaction] (
	TransactionId INT IDENTITY(1,1)
  , AccessKey CHAR(36) NOT NULL
  , Symbol VARCHAR(10) NOT NULL
  , TradeDate DATETIME2(2) NOT NULL
  , TradePrice DECIMAL NOT NULL
  , Quantity DECIMAL NOT NULL
  , Notional DECIMAL NOT NULL
  CONSTRAINT PK_Transaction PRIMARY KEY (TransactionId)
);
GO
