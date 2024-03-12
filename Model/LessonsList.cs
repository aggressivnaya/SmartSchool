using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonsList : List<Lesson>
    {
        public LessonsList() { }

        public LessonsList(IEnumerable<Lesson> lessons) : base(lessons) { }

        public LessonsList(IEnumerable<BaseEntity> lessons) : base(lessons.Cast<Lesson>().ToList()) { }
    }
}
