import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { environment } from '../environments/environment';
import { Observable, take } from 'rxjs';
import { AuthorModel } from '../models/author.model';

@Injectable({
    providedIn: 'root'
})

export class AuthorService {
        
    constructor(private http: HttpClient) {

    }

    getAuthors() : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/author`).pipe(take(1));
    }   

    getAuthorById(id: string) : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/author/` + id).pipe(take(1));
    }   

    addAuthor(author: AuthorModel) : Observable<any> {   
        return this.http.post(`${environment.baseUrl}/api/v1/author/add`, author).pipe(take(1));
    }

    updateAuthor(author: AuthorModel) : Observable<any> {
        return this.http.put(`${environment.baseUrl}/api/v1/author/update`, author).pipe(take(1));
    }

    deleteAuthor(id: string) : Observable<any> {
        return this.http.delete(`${environment.baseUrl}/api/v1/author/delete/` + id).pipe(take(1));
    }
}