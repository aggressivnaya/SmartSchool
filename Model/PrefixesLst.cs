using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PrefixesLst : List<PhonePrefix>
    {
        public PrefixesLst() { }

        public PrefixesLst(IEnumerable<PhonePrefix> students) : base(students) { }

        public PrefixesLst(IEnumerable<BaseEntity> students) : base(students.Cast<PhonePrefix>().ToList()) { }
    }
}
