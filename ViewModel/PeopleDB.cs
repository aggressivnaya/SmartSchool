using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModell
{
    public class PeopleDB : BaseDB
    {
        public PeopleDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            People people = entity as People;
            people.Id = (int)reader["ID"];
            people.FirstName = reader["FirstName"].ToString();
            people.LastName = reader["LastName"].ToString();
            people.PhoneP = PhonePrefixDB.SelectByID((int)reader["Prefix"]);
            people.PhoneN = PhoneNumDB.SelectByID((int)reader["Number"]);
            people.City = CityDB.SelectByID((int)reader["City"]);
            people.Gender = (bool)reader["Gender"];

            return people;
        }

        protected override BaseEntity newEntetiy()
        {
            return new People() as BaseEntity;
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
    }
}
