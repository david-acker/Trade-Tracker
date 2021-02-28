namespace TradeTracker.Domain.Enums
{
    public enum TransactionType
    {
        NotSpecified,

        // Long Exposure.
        BuyToOpen,
        SellToClose,

        // Short Exposure.
        SellToOpen,
        BuyToClose,

        CashDividend
    }
}