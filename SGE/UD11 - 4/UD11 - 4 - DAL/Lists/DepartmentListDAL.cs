using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Connection;
using UD11___4___DAL.Handlers;
using UD11___4___Entities;

namespace UD11___4___DAL.Lists
{
    public class DepartmentListDAL
    {
        public MyConnection connection { get; set; }
        public int rowsAffected { get; set; }

        public DepartmentListDAL()
        {
            this.connection = new MyConnection();
        }
        public Department getDepartment(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            Department readDepartment = new Department();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT ID, Name FROM Departments WHERE ID = @id";
            connection.myCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            connection.myReader = connection.myCommand.ExecuteReader();

            //Passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myReader.RecordsAffected;

            //Gets the only row
            connection.myReader.Read();

            readDepartment.ID = (int)connection.myReader["ID"];
            readDepartment.Name = (string)connection.myReader["Name"];


            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return readDepartment;
        }
        public List<Department> getDepartmentList()
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Department> DepartmentList = new List<Department>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT * FROM Departments";
            connection.myReader = connection.myCommand.ExecuteReader();


            if (connection.myReader.HasRows)
            {
                //Read method points to the next record.
                //It also returns true if it's pointing to a record and there are more left
                while (connection.myReader.Read())
                {

                    Department readDepartment = new Department();
                    readDepartment.ID = (int)connection.myReader["ID"];
                    readDepartment.Name = (string)connection.myReader["Name"];

                    //If the field is null, use this code:
                    //if (connection.myReader["email"] != System.DBNull.Value)
                    //{ readPerson.Email = (string) connection.myReader["email"]; }

                    //Adding retrieved records to our PersonList
                    DepartmentList.Add(readDepartment);

                }
            }

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return DepartmentList;

        }
    }
}
