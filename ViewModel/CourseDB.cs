using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ViewModell
{
    public class CourseDB : BaseDB
    {
        static private CourseList lst = null;

        public CourseDB() : base() { }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Course people = entity as Course;
            people.Id = (int)reader["ID"];
            people.Name = reader["Name"].ToString();
            
            return people;
        }

        protected override BaseEntity newEntetiy()
        {
            return new Course() as BaseEntity;
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

        public CourseList SelectAll()
        {
            command.CommandText = "SELECT * FROM CourseTbl";
            CourseList students = new CourseList(Select());
            return students;
        }

        static public Course SelectById(int id)
        {
            if (lst == null)
            {
                CourseDB db = new CourseDB();
                lst = db.SelectAll();
            }

            Course city = lst.Find(item => item.Id == id);
            return city;
        }
    }
}
