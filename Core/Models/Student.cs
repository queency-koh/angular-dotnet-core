using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace quantum_it.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
    }
}