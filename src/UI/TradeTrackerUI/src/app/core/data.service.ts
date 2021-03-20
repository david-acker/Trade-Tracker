import { query } from '@angular/animations';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Credentials } from '../models/credentials';
import { PagedTransactionsWithLinks } from '../models/paged-transactions-with-links';
import { PagedTransactionsParameters } from '../models/resource-parameters/paged-transactions-parameters';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    
    constructor(private http: HttpClient) { }

    public pagedTransactionsWithLinks: PagedTransactionsWithLinks;

    public get loginRequired(): boolean {
        let token: string = JSON.parse(localStorage.getItem('token'));
        let tokenExpiration: Date = new Date(JSON.parse(localStorage.getItem('token-expiration')));
        
        return token.length == 0 || tokenExpiration > new Date();
    }

    public login(credentials: Credentials) {
        return this.http.post("/api/account/authenticate", credentials)
            .pipe(
                map((response: any) => {
                    localStorage.setItem('token', response.token);
                    localStorage.setItem('token-expiration', response.expiration);

                    return true;
                }));
    }

    public getPagedTransactionsWithLinks(resourceParams: PagedTransactionsParameters): Observable<boolean> {

        let token: string = localStorage.getItem('token');

        const requestHeaders = {
            'Content-Type': 'application/json',
            'Accept': 'application/vnd.trade.hateoas+json',
            'Authorization': `Bearer ${token}`
        }

        let queryParams = new HttpParams()

        queryParams = queryParams.set('Order', resourceParams.order);
        queryParams = queryParams.set('PageNumber', resourceParams.pageNumber.toString());
        queryParams = queryParams.set('PageSize', resourceParams.pageSize.toString());
        if (resourceParams.rangeStart != null) {
            queryParams = queryParams.set('RangeStart', resourceParams.rangeStart.toString());
        }
        if (resourceParams.rangeEnd != null) {
            queryParams = queryParams.set('RangeEnd', resourceParams.rangeEnd.toString());
        }
        
        return this.http.get('/api/transactions', {
            headers: requestHeaders,
            params: queryParams
        })
        .pipe(
            map((data: any) => {
                this.pagedTransactionsWithLinks = data;
                return true;
            })
        );
    }

}