using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NumbersLst : List<PhoneNum>
    {
        public NumbersLst() { }

        public NumbersLst(IEnumerable<PhoneNum> students) : base(students) { }

        public NumbersLst(IEnumerable<BaseEntity> students) : base(students.Cast<PhoneNum>().ToList()) { }
    }
}
