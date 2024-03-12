using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseList : List<Course>
    {
        public CourseList() { }

        public CourseList(IEnumerable<Course> city) : base(city) { }

        public CourseList(IEnumerable<BaseEntity> city) : base(city.Cast<Course>().ToList()) { }
    }
}
