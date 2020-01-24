import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStudent } from '../models/student';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  url = 'https://localhost:5001/api/students/';

  constructor(private http: HttpClient) { }

  getStudents(classId: number): Observable<IStudent[]> {
    return this.http.get<IStudent[]>(this.url + classId);
  }

  get(classId: number, studentId: number): Observable<IStudent[]> {
    return this.http.get<IStudent[]>(this.url + classId + '/' + studentId).pipe(
      map(response => response));
  }

  create(student) {
    return this.http.post(this.url, student).pipe(
      map(response => response));
  }

  update(id: number, student) {
    return this.http.put(this.url + id, student).pipe(
      map(response => response));
  }

  delete(id: number) {
    return this.http.delete(this.url + id).pipe(
      map(response => response));
  }

}
