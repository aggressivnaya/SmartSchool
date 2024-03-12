using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : People
    {
        private LessonsList lessonsList;
        //Class1 c = new Class1() {X=7,Y=3.0;}
        public Student() : base()
        {

        }

        public LessonsList LessonsList { get => lessonsList; set => lessonsList = value; }
    }
}
