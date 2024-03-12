using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModell
{
    public class LecturerDB : PeopleDB
    {
        public LecturerDB() : base() { }

        protected override BaseEntity newEntetiy()
        {
            return new Lecturer() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Lecturer lecturer = entity as Lecturer;
            base.CreateModel(lecturer);

            return lecturer;
        }

        public LecturerList SelectAll()
        {
            command.CommandText = "SELECT *,PeopleTbl.ID as ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.ID)";
            LecturerList lecturers = new LecturerList(base.Select());
            return lecturers;
        }

        public LecturerList SelectByName(string firstName, string lastName)
        {
            command.CommandText = $"SELECT *,PeopleTbl as ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.ID) WHERE FirstName='{firstName}' AND LastName='{lastName}'";
            List<Lecturer> lecturers = base.Select().Cast<Lecturer>().ToList();
            return new LecturerList(lecturers);
        }

        public Lecturer SelectById(int id)
        {
            command.CommandText = $"SELECT * ,PeopleTbl.ID as ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.ID) WHERE PeopleTbl.ID={id}";
            List<Lecturer> lecturer = base.Select().Cast<Lecturer>().ToList();
            if (lecturer.Count == 1)
            {
                return lecturer[0] as Lecturer;
            }
            return null;
        }

        public int Insert(Lecturer student)
        {
            string str = string.Format($"INSERT INTO PeopleTbl (FirstName, LastName, City, Prefix, Number ,Gender) VALUES('{student.FirstName}', '{student.LastName}', '{student.City}',  '{student.PhoneP}', {student.PhoneN}', '{student.Gender}')");
            return base.SaveChanges(str);
        }

        public int Update(Lecturer student)
        {
            string str = $"UPDATE LecturerTbl SET FirstName='{student.FirstName}, LastName='{student.LastName}', City={student.City.Id}, Prefix={student.PhoneP.Id},Number={student.PhoneN.Id}, Gender={student.Gender} WHERE ID={student.Id}";
            return base.SaveChanges(str);
        }

        public int Delete(Lecturer student)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat($"DELETE FROM LecturerTbl WHERE ID={student.Id}");
            return base.SaveChanges(stringBuilder.ToString());
        }
    }
}
