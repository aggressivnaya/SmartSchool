using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lesson : BaseEntity
    {
        private Lecturer _teacher;
        private Student _student;
        private Course _course;
        private double _grade;

        public Lesson() { }

        public double Grade
        {
            get { return this._grade; }
            set { this._grade = value;}
        }

        public Course Course { 
            get { return this._course; }
            set { this._course = value; }
        }

        public Student Student
        { 
            get { return this._student; } 
            set { this._student = value; }
        }

        public Lecturer Teacher
        {
            get { return _teacher; }
            set { _teacher = value; }
        }
    }
}
