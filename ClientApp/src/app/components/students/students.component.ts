import { Component, OnInit, Input } from '@angular/core';
import { IClass } from '../../models/class';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  @Input() classModel;

  constructor(private studentService: StudentService) { }

  ngOnInit() { }

  delete(id: number) {
    if (confirm('Are you sure you want to delete this students?'))
      this.studentService.delete(id).subscribe(() => {
        const index = this.classModel.students.indexOf(id);
        this.classModel.students.splice(index, 1)
      });
  }
}
