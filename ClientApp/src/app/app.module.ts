import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ClassFormComponent } from './components/class-form/class-form.component';
import { StudentFormComponent } from './components/student-form/student-form.component';

import { ClassService } from './services/class.service';
import { StudentService } from './services/student.service';
import { StudentsComponent } from './components/students/students.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClassFormComponent,
    StudentsComponent,
    StudentFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'class/new', component: ClassFormComponent, pathMatch: 'full' },
      { path: 'class/:id', component: ClassFormComponent, pathMatch: 'full' },
      { path: 'student/new/:classId', component: StudentFormComponent, pathMatch: 'full' },
      { path: 'student/:id', component: StudentFormComponent, pathMatch: 'full' },
    ])
  ],
  providers: [ClassService, StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }