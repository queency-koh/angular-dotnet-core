import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IClass } from '../models/class';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  url = 'https://localhost:5001/api/classes/';

  constructor(private http: HttpClient) { }

  getClassess(): Observable<IClass[]> {
    return this.http.get<IClass[]>(this.url);
  }

  get(classModelId) {
    return this.http.get(this.url + classModelId).pipe(
      map(response => response));
  }

  create(classModel) {
    return this.http.post(this.url, classModel).pipe(
      map(response => response));
  }

  update(id, classModel) {
    return this.http.put(this.url + id, classModel).pipe(
      map(response => response));
  }

  delete(id) {
    return this.http.delete(this.url + id).pipe(
      map(response => response));
  }
}
