using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PhoneNum : BaseEntity
    {
        private string _num;

        public PhoneNum() : base() { }

        public string Num { get; set; }
    }
}
