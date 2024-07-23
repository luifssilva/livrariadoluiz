import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { environment } from '../environments/environment';
import { Observable, take } from 'rxjs';
import { GenderModel } from '../models/gender.model'

@Injectable({
    providedIn: 'root'
})

export class GenderService {
        
    constructor(private http: HttpClient) {

    }

    getGenders() : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/gender`).pipe(take(1));
    }   

    getGenderById(id: string) : Observable<any> {
        return this.http.get(`${environment.baseUrl}/api/v1/gender/` + id).pipe(take(1));
    }   

    addGender(gender: GenderModel) : Observable<any> {   
        return this.http.post(`${environment.baseUrl}/api/v1/gender/add`, gender).pipe(take(1));
    }

    updateGender(gender: GenderModel) : Observable<any> {
        return this.http.put(`${environment.baseUrl}/api/v1/gender/update`, gender).pipe(take(1));
    }

    deleteGender(id: string) : Observable<any> {
        return this.http.delete(`${environment.baseUrl}/api/v1/gender/delete/` + id).pipe(take(1));
    }
}