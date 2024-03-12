using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using ViewModell;

namespace SmartSchool
{
  public class ServiceClient
    {
        public CityList GetAllCity()
        {
            CityList lst = new CityList();
            lst.Add(new City() { Id = 1, Name= "Netanya" });
            lst.Add(new City() { Id = 2, Name = "Lod" });
            lst.Add(new City() { Id = 3, Name = "Tel Aviv" });
            lst.Add(new City() { Id = 4, Name = "Kfar Saba" });
            lst.Add(new City() { Id = 5, Name = "Moscow" });

            return lst;
        }

        public PrefixesLst GetAllPrefix()
        {
            PrefixesLst lst = new PrefixesLst();
            lst.Add(new PhonePrefix() { Id = 1, Num = "050" });
            lst.Add(new PhonePrefix() { Id = 2, Num = "052" });
            lst.Add(new PhonePrefix() { Id = 3, Num = "054" });
            return lst;
        }
        public People GetUser1()
        {
            People user = new People();
            user.FirstName = "fname";
            user.LastName = "lname";
            user.City = new City { Id = 3 ,Name= "Raanana" };
            //user.BDate = new DateTime (2002,5,4,21,12,13);    // time=  4/5/2002  21:12:13
            user.Gender = false;
            user.PhoneP= new PhonePrefix { Id = 1, Num = "050" };
            user.PhoneN.Num = "123456";
            return user;
        }
        public People GetUser2()
        {
            People user = new People();
            user.FirstName = "fname2";
            user.LastName = "lname2";
            user.City = new City { Id = 4 , Name = "Eilat" };
            //user.BDate = new DateTime(1990,3,8,12,34,21);   // time=  12/8/1990  12:34:21
            user.Gender = true;
            user.PhoneP = new PhonePrefix { Id =2, Num = "052" };
            user.PhoneN.Num = "987654";
            return user;
        }
    }
}
