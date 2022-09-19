import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';

const baseUrl = `${environment.apiUrl}/users`;

@Injectable({ providedIn: 'root' })
export class UserService {

    readonly rootURL = 'https://localhost:44320/api/usuario';

    constructor(private http: HttpClient) { }
     
    getAll() {
        return this.http.get<User[]>(this.rootURL);
    }

    getById(id: string) {
        return this.http.get<User>(`${this.rootURL}/${id}`);
    }

    create(params: any) {
        return this.http.post(this.rootURL, params);
    }

    update(id: string, params: any) {
        return this.http.put(`${this.rootURL}/${id}`, params);
    }

    delete(id: string) {
        return this.http.delete(`${this.rootURL}/${id}`);
    }
}