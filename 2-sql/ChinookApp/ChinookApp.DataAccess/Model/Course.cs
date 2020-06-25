using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string CourseNumber { get; set; }
        public string SectionNumber { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
