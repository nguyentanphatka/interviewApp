import { Router } from "@angular/router";
import { NzTableModule } from "ng-zorro-antd/table";
import { StudentsService } from "../core";
import { Student } from "../core";
import { Component, OnInit } from "@angular/core";
import { finalize, tap } from "rxjs/operators";
import { NzMessageService } from "ng-zorro-antd/message";

@Component({
  selector: "nz-demo-table-edit-cell",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
  constructor(
    private router: Router,
    private studentsService: StudentsService,
    private message: NzMessageService,
  ) {}

  i = 0;
  editId: string | null = null;
  students: Student[] = [];
  isLoadingSaveBtn = false;
  ngOnInit() {
    
  }

  startEditName(id: string): void {
    this.editId = id;
  }

  stopEdit(): void {
    this.editId = null;
  }

  addRow(): void {
    const newData = {
      id: `${this.i}`,
      fullName: `Student Name`,
      dob: new Date(),
    };
    this.students = [...this.students, newData];
    this.i++;
  }

  deleteRow(id: string): void {
    this.students = this.students.filter((d) => d.id !== id);
  }

  handleSave() {
    if (this.isLoadingSaveBtn) return;
    this.studentsService
      .addStudents(this.students)
      .pipe(
        tap(() => (this.isLoadingSaveBtn = true)),
        finalize(() => (this.isLoadingSaveBtn = false))
      )
      .subscribe({
        next: ()=> {
          this.message.success('Save Successfully');
          this.router.navigate(['/result']);
        },
        error: () => {
          this.message.error('Save Failure, Min length of list students is 30.');
        }
      });
  }
}
