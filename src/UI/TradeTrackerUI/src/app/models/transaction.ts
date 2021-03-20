export interface Transaction {
    transactionId: string;
    dateTime: Date;
    symbol: string;
    type: string;
    quantity: number;
    notional: number;
    tradePrice: number;
}