using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModell
{
    public class LessonDB : BaseDB
    {
        public LessonDB() : base() { }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Lesson people = entity as Lesson;
            people.Id = (int)reader["ID"];
            int num = (int)reader["Teacher"];
            //people.City = CityDB.SelectByID(city);
            LecturerDB l = new LecturerDB();
            StudentDB s = new StudentDB();
            people.Teacher = l.SelectById(num);
            num = (int)reader["Student"];
            people.Student = s.SelectById(num);
            num = (int)reader["Course"];
            people.Course = CourseDB.SelectById(num);

            return people;
        }

        protected override BaseEntity newEntetiy()
        {
            return new Lesson() as BaseEntity;
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
