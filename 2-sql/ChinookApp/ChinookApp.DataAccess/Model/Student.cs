using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
