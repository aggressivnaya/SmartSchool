using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class People : BaseEntity
    {
        protected string _firstName;
        protected string _lastName;
        protected City _city;
        protected PhoneNum _phoneNum;
        protected PhonePrefix _phonePrefix;
        protected bool _gender;

        public People() : base() {
            
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public City City { get => _city; set => _city = value; }
        public PhoneNum PhoneN { get => _phoneNum; set => _phoneNum = value; }
        public PhonePrefix PhoneP { get => _phonePrefix; set => _phonePrefix = value; }
        public bool Gender { get => _gender; set => _gender = value; }
    }
}
