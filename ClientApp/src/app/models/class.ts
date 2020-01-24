import { IStudent } from "./student";

export interface IClass {
    id: number;
    className: string;
    location: string;
    teacherName: string;
    students: Array<IStudent>;
}