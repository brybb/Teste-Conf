import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Schooling } from '@app/_models';


@Injectable({
  providedIn: 'root'
})
export class SchoolingService {

  readonly rootURL = 'https://localhost:44320/api';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Schooling[]>(this.rootURL + '/escolaridade');
  }
}
