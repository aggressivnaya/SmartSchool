using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Model;
using ViewModell;

namespace ViewModel
{
    public class StudentDB : PeopleDB
    {
        public StudentDB() 
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        protected override BaseEntity newEntetiy()
        {
            return new Student() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Student student = entity as Student;
            base.CreateModel(student);
            return student;
        }

        public StudentsList SelectAll()
        {
            command.CommandText = "SELECT *,PeopleTbl.ID as ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.ID)";
            StudentsList students = new StudentsList(base.Select());
            return students;
        }

        public StudentsList SelectByName(string firstName, string lastName)
        {
            command.CommandText = $"SELECT *,PeopleTbl as ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.ID) WHERE FirstName='{firstName}' AND LastName='{lastName}'";
            List<Student> students = base.Select().Cast<Student>().ToList();
            return new StudentsList(students);
        }

        public Student SelectById(int id)
        {
            command.CommandText = $"SELECT *,PeopleTbl.ID as ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.ID) WHERE PeopleTbl.ID={id}";
            List<Student> students = base.Select().Cast<Student>().ToList();
            if (students.Count == 1)
            {
                return students[0] as Student;
            }
            return null;
        }

        public int Insert(Student student)
        {
            string str = string.Format($"INSERT INTO PeopleTbl (FirstName, LastName, City, Prefix, Number, Gender) VALUES('{student.FirstName}', '{student.LastName}', '{student.City}', '{student.PhoneP}', {student.PhoneN}', '{student.Gender}')");
            return base.SaveChanges(str);
        }

        public int Update(Student student)
        {
            string str = $"UPDATE StudentTbl SET FirstName='{student.FirstName}, LastName='{student.LastName}', City={student.City.Id}, Prefix={student.PhoneP.Id},Number={student.PhoneN.Id}, Gender={student.Gender} WHERE ID={student.Id}";
            return base.SaveChanges(str);
        }

        public int Delete(Student student) 
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat($"DELETE FROM StudentTbl WHERE ID={student.Id}");
            return base.SaveChanges(stringBuilder.ToString());
        }
    }
}
