using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LecturerList : List<Lecturer>
    {
        public LecturerList() { }

        public LecturerList(IEnumerable<Lecturer> l) : base(l) { }

        public LecturerList(IEnumerable<BaseEntity> l) : base(l.Cast<Lecturer>().ToList()) { }
    }
}
