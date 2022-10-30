import { Component, OnInit } from "@angular/core";

import { Student, StudentsService } from "./core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  constructor(private studentsService: StudentsService) {}

  ngOnInit() {
  }
}
