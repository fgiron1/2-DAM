using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Connection;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___DAL.Handlers
{
    public class DepartmentHandlerDAL
    {
		public MyConnection connection { get; set; }
		public int rowsAffected { get; set; }

        public DepartmentHandlerDAL()
        {
            this.connection = new MyConnection();
        }

        /// <summary>
        /// This method takes a Department object as a parameter and
        /// updates the database department record with the same ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newDepartment"></param>
        public void updateDepartment(Department newDepartment)
        {

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Department> DepartmentList = new List<Department>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code
            //The UPDATE SQL statement doesn't return any information, so no reader objects are necessary
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "UPDATE Departments " +
                                               "SET Name = @Name " +
                                               "WHERE ID = @ID";

            connection.myCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = newDepartment.Name;
            connection.myCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = newDepartment.ID;

            //Executing non-query statement and passing the value of rows affected to our handler's property
            try
            {
                this.rowsAffected = connection.myCommand.ExecuteNonQuery();
            }
            catch(InvalidOperationException e)
            {
                throw e;
            }
            catch(SqlException e)
            {
                throw e;
            }

            //Closing connection
            this.connection.closeConnection();
        }

        /// <summary>
        /// This method takes a department id as a parameter and
        /// delete the database department record with the same id
        /// </summary>
        /// <param name="id"></param>
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
            try
            {
                this.rowsAffected = connection.myCommand.ExecuteNonQuery();
            }catch(InvalidOperationException e)
            {
                throw e;

            }catch(SqlException e)
            {
                throw e;
            }

            //Closing connection
            this.connection.closeConnection();
        }

        /// <summary>
        /// This method takes a Department object as a parameter
        /// and inserts its data as a new database record
        /// </summary>
        /// <param name="newDepartment"></param>
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
            try
            {
                this.rowsAffected = connection.myCommand.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (SqlException e)
            {
                throw e;
            }
            

            //Closing connection
            this.connection.closeConnection();
        }

	}
}
