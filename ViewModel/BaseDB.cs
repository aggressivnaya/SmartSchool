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
    public abstract class BaseDB
    {
        protected string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Magshimim\\source\\repos\\SmartSchool\\ViewModel\\smartschoolproj.accdb;Persist Security Info=True";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public abstract List<BaseEntity> Select();

        protected abstract BaseEntity newEntetiy();

        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseDB() 
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }
        protected int SaveChanges(string commandTxt)
        {
            OleDbCommand cmd = new OleDbCommand();
            int records = 0;
            try
            {
                command.Connection = this.connection;
                command.CommandText = commandTxt;
                connection.Open();
                records = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nOleDB: " + command.CommandText);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return records;
        }
    }
}
