using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CityList : List<City>
    {
        public CityList() { }

        public CityList(IEnumerable<City> city) : base(city) { }

        public CityList(IEnumerable<BaseEntity> city) : base(city.Cast<City>().ToList()) { }
    }
}
