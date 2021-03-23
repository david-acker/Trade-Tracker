import { query } from '@angular/animations';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Credentials } from '../models/credentials';
import { PagedTransactionsWithLinks } from '../models/paged-transactions-with-links';
import { Registration } from '../models/registration';
import { PagedTransactionsParameters } from '../models/resource-parameters/paged-transactions-parameters';
import { TransactionForCreation } from '../models/transaction-for-creation';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    
    constructor(private http: HttpClient) { }

    public pagedTransactionsWithLinks: PagedTransactionsWithLinks;

    public login(credentials: Credentials) {
        return this.http.post('/api/account/authenticate', credentials)
            .pipe(
                map((response: any) => {
                    localStorage.setItem('token', response.token);

                    let expirationDate = new Date(response.expiration);
                    localStorage.setItem('token-expiration', expirationDate.toISOString());

                    return true;
                }));
    }

    public register(registration: Registration) {
        return this.http.post('/api/account/register', registration)
            .pipe(
                map((response: any) => {
                    return true;
                }));
    }

    public addTransaction(transaction: TransactionForCreation) {

        let token: string = localStorage.getItem('token');

        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': `Bearer ${token}`
        });

        return this.http.post('api/transactions', transaction, {
            headers: headers
        }).pipe(
            map((response: any) => {
                return true;
            }));
    }

    public getPagedTransactionsWithLinks(resourceParams: PagedTransactionsParameters): Observable<boolean> {

        let token: string = localStorage.getItem('token');

        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/vnd.trade.hateoas+json',
            'Authorization': `Bearer ${token}`
        });

        let params = new HttpParams()

        params = params.set('Order', resourceParams.order);
        params = params.set('PageNumber', resourceParams.pageNumber.toString());
        params = params.set('PageSize', resourceParams.pageSize.toString());
        if (resourceParams.rangeStart != null) {
            params = params.set('RangeStart', resourceParams.rangeStart.toString());
        }
        if (resourceParams.rangeEnd != null) {
            params = params.set('RangeEnd', resourceParams.rangeEnd.toString());
        }
        
        return this.http.get('/api/transactions', {
            headers: headers,
            params: params
        }).pipe(
            map((data: any) => {
                this.pagedTransactionsWithLinks = data;
                return true;
            })
        );
    }

}