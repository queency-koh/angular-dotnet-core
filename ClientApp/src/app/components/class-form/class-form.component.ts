import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { ClassService } from 'src/app/services/class.service';
import { Route } from '@angular/compiler/src/core';
import { IClass } from 'src/app/models/class';

@Component({
  selector: 'app-class-form',
  templateUrl: './class-form.component.html',
  styleUrls: ['./class-form.component.css']
})
export class ClassFormComponent implements OnInit {
  classModel = {};
  id: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private classService: ClassService) {

    // Get ID from route parameter
    this.id = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    if (this.id)
      this.classService.get(this.id).pipe(take(1)).subscribe(c => this.classModel = c);
  }

  save(classModel) {
    if (this.id)
      this.classService.update(this.id, classModel).subscribe();
    else
      this.classService.create(classModel).subscribe();

    this.router.navigate(['/']);
  }
}
