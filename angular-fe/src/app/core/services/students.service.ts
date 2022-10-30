import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';

import { ApiService } from './api.service';
import { map, tap } from 'rxjs/operators';
import { Student } from '../../core';

 @Injectable()
export class StudentsService {
  constructor (
    private apiService: ApiService
  ) {}

  getAll(): Observable<[Student]> {
    return this.apiService.get('/GetAll')
          .pipe(map(data => data.data.students));
  }

  getAllSorted(): Observable<[Student]> {
    return this.apiService.get('/GetAllSorted')
          .pipe(map(data => data.data.students));
  }

  addStudents(students: Student[]) {
    return this.apiService.post('/AddStudents', {
      students: students
    }).pipe(tap(res => {
      if(!res.isSuccess) throwError('Error Add Students');
    }));
  }

  deleteAllStudents() {
    return this.apiService.post('/DeleteStudents').pipe(tap(res => {
      if(!res.isSuccess) throwError('Error Add Students');
    }));
  }
}
