using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PhonePrefix : BaseEntity
    {
        private string _num;

        public PhonePrefix() : base() { }

        public string Num { get; set; }
    }
}
