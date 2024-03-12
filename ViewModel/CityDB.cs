using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModell
{
    public class CityDB : BaseDB
    {
        static private CityList lst = null;

        public CityDB() : base() { }
        
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM CityTbl";
            lst = new CityList(Select());
            return lst;
        }

        static public City SelectByID(int id)
        {
            if(lst == null)
            {
                CityDB db = new CityDB();
                lst = db.SelectAll();
            }

            City city = lst.Find(item => item.Id == id);
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
            City city = entity as City;
            city.Id = (int)reader["ID"];
            city.Name = reader["Name"].ToString();
            return city;
        }
    }
}
