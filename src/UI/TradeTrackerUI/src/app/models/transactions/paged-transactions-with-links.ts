import { Link } from "../shared/link";
import { PaginationMetadata } from "../shared/pagination-metadata";
import { TransactionWithLinks } from "./transaction-with-links";

export interface PagedTransactionsWithLinks {
    metadata: PaginationMetadata;
    items: TransactionWithLinks[];
    links: Link[];
}