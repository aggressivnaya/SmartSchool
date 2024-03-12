using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City : BaseEntity
    {
        private string _name;
        public City() : base(){ }
        public string Name { get; set; }
    }
}
