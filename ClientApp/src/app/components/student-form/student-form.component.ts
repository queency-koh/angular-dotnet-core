import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { StudentService } from 'src/app/services/student.service';
import { take } from 'rxjs/operators';
import { ClassService } from 'src/app/services/class.service';
import { IClass } from 'src/app/models/class';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {
  student = {};
  classes: IClass[] = [];
  id: number;
  classId: number;
  disabled: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private classService: ClassService,
    private studentService: StudentService) {

    // Get Class Id from route parameter
    this.classId = +this.route.snapshot.paramMap.get('classId');

    // Get Student Id from router parameter
    this.id = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    // Get Student By ID
    if (this.id)
      this.studentService.get(this.classId, this.id).pipe(take(1)).subscribe(s => this.student = s);

    this.classService.getClassess()
      .subscribe(classes => this.classes = classes);
  }

  onChangeCheckLastName(lastName: string) {
    if (this.classes && this.classes[0].students.length < 1)
      return;

    const student = this.classes[0].students.find(student => student.lastName == lastName);

    if (student)
      this.disabled = true;
    else
      this.disabled = false;
  }

  save(student) {

    var data = {
      classId: this.classId == undefined ? 0 : this.classId,
      firstName: student.firstName,
      lastName: student.lastName,
      age: student.age,
      gpa: student.gpa
    };

    console.log(data);
    if (this.id)
      this.studentService.update(this.id, data).subscribe();
    else
      this.studentService.create(data).subscribe();

    this.router.navigate(['/']);
  }
}
