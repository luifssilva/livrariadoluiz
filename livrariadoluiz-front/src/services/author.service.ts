import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class AuthorService {
        
    constructor(private http: HttpClient) {

    }

    public getAuthors() : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/author`);
    }   
}