import { Component, OnInit } from "@angular/core";
import { finalize, tap } from "rxjs/operators";
import { Student, StudentsService } from "../../core";

@Component({
  selector: "app-result",
  templateUrl: "./result.component.html",
  styleUrls: ["./result.component.css"],
})
export class ResultComponent implements OnInit {
  students: Student[] = [];
  isLoadingData = false;
  isLoadingSortBtn = false;
  isLoadingDeleteBtn = false;
  isLoadingClearSortBtn = false;
  constructor(private studentsService: StudentsService) {}

  ngOnInit() {
    this.studentsService
      .getAll()
      .pipe(
        tap(() => (this.isLoadingData = true)),
        finalize(() => (this.isLoadingData = false))
      )
      .subscribe((st) => {
        this.students = st;
      });
  }
  sortStudents() {
    this.studentsService
      .getAllSorted()
      .pipe(
        tap(() => (this.isLoadingSortBtn = true)),
        finalize(() => (this.isLoadingSortBtn = false))
      )
      .subscribe((st) => {
        this.students = st;
      });
  }

  reloadStudents() {
    this.studentsService
      .getAll()
      .pipe(
        tap(() => (this.isLoadingClearSortBtn = true)),
        finalize(() => (this.isLoadingClearSortBtn = false))
      )
      .subscribe((st) => {
        this.students = st;
      });
  }
  
  deleteAllStudents() {
    this.studentsService
      .deleteAllStudents()
      .pipe(
        tap(() => (this.isLoadingDeleteBtn = true)),
        finalize(() => (this.isLoadingDeleteBtn = false))
      )
      .subscribe((st) => {
        this.reloadStudents();
      });
  }
}