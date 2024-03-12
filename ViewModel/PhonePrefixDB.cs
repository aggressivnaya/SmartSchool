using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModell
{
    public class PhonePrefixDB : BaseDB
    {
        static private PrefixesLst lst = null;

        public PhonePrefixDB() : base() { }

        public PrefixesLst SelectAll()
        {
            command.CommandText = "SELECT * FROM PhonePrefixTbl";
            lst = new PrefixesLst(Select());
            return lst;
        }

        static public PhonePrefix SelectByID(int id)
        {
            if (lst == null)
            {
                PhonePrefixDB db = new PhonePrefixDB();
                lst = db.SelectAll();
            }

            PhonePrefix city = lst.Find(item => item.Id == id);
            return city;
        }
        public override List<BaseEntity> Select()
        {
            List<BaseEntity> peopleLst = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                BaseEntity people;
                while (reader.Read())
                {
                    people = newEntetiy();

                    peopleLst.Add(CreateModel(people));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return peopleLst;
        }

        protected override BaseEntity newEntetiy()
        {
            return new City() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            PhonePrefix city = entity as PhonePrefix;
            city.Id = (int)reader["ID"];
            city.Num = reader["Num"].ToString();
            return city;
        }
    }
}
