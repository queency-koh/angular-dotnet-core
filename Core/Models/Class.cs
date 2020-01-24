using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace quantum_it.Core.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}