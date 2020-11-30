using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Connection;
using UD11___4___Entities;

namespace UD11___4___DAL.Handlers
{
    public class DepartmentHandlerDAL
    {
		public MyConnection connection { get; set; }
		public int rowsAffected { get; set; }

        public DepartmentHandlerDAL()
        {
            this.connection = new MyConnection();
        }
		
        public void updateDepartment(int id, Department newDepartment)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Department> DepartmentList = new List<Department>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "UPDATE Departments " +
                                               "SET Name = @Name " +
                                               "WHERE ID = @ID";

            connection.myCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = newDepartment.Name;
            connection.myCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = newDepartment.ID;
            //Executing non-query statement and passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }
		public void deleteDepartment(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Department> DepartmentList = new List<Department>();

            connection.openConnection();
            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "DELETE FROM Departments " +
                                               "WHERE ID = @id";

            connection.myCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            //Executing non-query statement and passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }
		public void insertDepartment(Department newDepartment)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Department> DepartmentList = new List<Department>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "INSERT INTO Departments (Name) " +
                                               "VALUES @Name";

            connection.myCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = newDepartment.Name;

            //Executing non-query statement and passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }

	}
}
