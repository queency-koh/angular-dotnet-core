import { Component } from '@angular/core';
import { ClassService } from '../../services/class.service'
import { IClass } from 'src/app/models/class';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  classes: IClass[] = [];
  selectedClass;
  navigationSubscription;

  constructor(
    private router: Router,
    private classService: ClassService) {
    this.navigationSubscription = this.router.events.subscribe((e: any) => {

      if (e instanceof NavigationEnd) {
        this.initialise();
      }
    });
  }

  initialise() {
    this.getClass();
  }

  ngOnInit() {
    this.getClass();
  }

  ngOnDestroy() {
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
    }
  }

  getClass(): void {
    // Get All Classes
    this.classService.getClassess()
      .subscribe(classes => this.classes = classes);
  }

  onSelect(classModel: IClass) {
    this.selectedClass = classModel;
  }

  delete(id: number) {
    if (confirm('Are you sure you want to delete this class?'))
      this.classService.delete(id).subscribe(() => {
        const index = this.classes.indexOf(id);
        this.classes.splice(index, 1)
      });
  }
}
