using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Connection;
using UD11___4___Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace UD11___4___DAL.Handlers
{
    //All the fields are hardcoded, this code won't be able to handle changes on the database schema
    public class PersonHandlerDAL
    {
        public MyConnection connection { get; set; }

        //This field reflects the number of rows affected by the last instruction executed.
        //Helps debug code. (0 fields mean erroneous statement or no changes made,
        //                  -1 fields means no rows were read by a SELECT instruction)
        public int rowsAffected { get; set; }
        public PersonHandlerDAL()
        {
            this.connection = new MyConnection();
        }

        /// <summary>
        /// This method takes a Person object as a parameter and
        /// updates the database person record with the same ID
        /// </summary>
        /// <pre>id attribute </pre>
        /// <param name="id"></param>
        /// <param name="newPerson"></param>
        public void updatePerson(Person newPerson)
        {

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "UPDATE Persons " +
                                              "SET FirstName = @FirstName, " +
                                              "LastName = @LastName, " +
                                              "Birthdate = @Birthdate, " +
                                              "Email = @Email, " +
                                              "PhoneNumber = @PhoneNumber, " +
                                              "DepartmentID = @DepartmentID " +
                                              "WHERE ID = @ID";
            //New department ID would have to be verified

            connection.myCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = newPerson.id;
            connection.myCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = newPerson.FirstName;
            connection.myCommand.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = newPerson.LastName;
            connection.myCommand.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar).Value = newPerson.PhoneNumber;
            connection.myCommand.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = newPerson.Email;
            connection.myCommand.Parameters.Add("@Birthdate", System.Data.SqlDbType.DateTime).Value = newPerson.Birthdate;
            connection.myCommand.Parameters.Add("@DepartmentID", System.Data.SqlDbType.Int).Value = newPerson.DepartmentID;

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

        /// <summary>
        /// This method takes a person id as a parameter and
        /// delete the database person record with the same id
        /// </summary>
        /// <param name="id"></param>
        public void deletePerson(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            connection.openConnection();
            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "DELETE FROM Persons " +
                                               "WHERE ID = @id";

            connection.myCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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

        /// <summary>
        /// This method takes a Person object as a parameter
        /// and inserts its data as a new database record
        /// </summary>
        /// <param name="newPerson"></param>
        public void insertPerson(Person newPerson)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "INSERT INTO Persons (FirstName, LastName, Birthdate, Email, PhoneNumber, DepartmentID)" +
                                               " VALUES (@FirstName, " +
                                               " @LastName, " +
                                               " @PhoneNumber, " +
                                               " @Email, " +
                                               " CAST(@Birthdate AS date), " +
                                               " @DepartmentID)";
                                                //DepartmentID should be verified

            connection.myCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = newPerson.FirstName;
            connection.myCommand.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = newPerson.LastName;
            connection.myCommand.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar).Value = newPerson.PhoneNumber;
            connection.myCommand.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = newPerson.Email;
            connection.myCommand.Parameters.Add("@Birthdate", System.Data.SqlDbType.DateTime).Value = newPerson.Birthdate;
            connection.myCommand.Parameters.Add("@DepartmentID", System.Data.SqlDbType.Int).Value = newPerson.DepartmentID;

            //Executing non-query statement andPassing the value of rows affected to our handler's property
            try { 
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();
            } catch (InvalidOperationException e)
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
