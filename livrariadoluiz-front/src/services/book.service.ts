import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { environment } from '../environments/environment';
import { Observable, take } from 'rxjs';
import { BookModel, BookModelRequest } from '../models/book.model';

@Injectable({
    providedIn: 'root'
})

export class BookService {
        
    constructor(private http: HttpClient) {

    }

    getBooks() : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/book`).pipe(take(1));
    }   

    getBookById(id: string) : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/book/` + id).pipe(take(1));
    }   

    addBook(author: BookModelRequest) : Observable<any> {   
        return this.http.post(`${environment.baseUrl}/api/v1/book/add`, author).pipe(take(1));
    }

    updateBook(author: BookModelRequest) : Observable<any> {
        return this.http.put(`${environment.baseUrl}/api/v1/book/update`, author).pipe(take(1));
    }

    deleteBook(id: string) : Observable<any> {
        return this.http.delete(`${environment.baseUrl}/api/v1/book/delete/` + id).pipe(take(1));
    }
}