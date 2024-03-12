using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentsList : List<Student>
    {
        public StudentsList() { }

        public StudentsList(IEnumerable<Student> students) : base(students) { }

        public StudentsList(IEnumerable<BaseEntity> students) : base(students.Cast<Student>().ToList()) { }
    }
}
