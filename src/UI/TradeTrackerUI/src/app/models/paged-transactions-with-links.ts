import { Link } from "./link";
import { PaginationMetadata } from "./pagination-metadata";
import { TransactionWithLinks } from "./transaction-with-links";

export interface PagedTransactionsWithLinks {
    metadata: PaginationMetadata;
    items: TransactionWithLinks[];
    links: Link[];
}