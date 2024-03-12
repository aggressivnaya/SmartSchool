using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Course : BaseEntity
    {
        private string _name;
        public Course() : base() { }
        public string Name { get; set; }
    }
}
