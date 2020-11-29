using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Connection;
using UD11___4___Entities;
using System.Data.SqlClient;







//TENGO QUE SUSTITUIR LOS NOMBRES DE LOS ATRIBUTOS QUE ESCRIBO AQUI POR LOS QUE REALMENTE SON EN LA BBDD








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
        public Person getPerson(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            Person readPerson = new Person();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();
            connection.myCommand.CommandText = "SELECT *" +
                                               "FROM Personas" +
                                              $"WHERE id = {id}";

            try
            {
                connection.myReader = connection.myCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw e;
            }
            
            //Passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myReader.RecordsAffected;

                readPerson.ID = (int)connection.myReader["id"];
                readPerson.FirstName = (string)connection.myReader["firstName"];
                readPerson.LastName = (string)connection.myReader["lastName"];
                readPerson.Birthdate = (DateTime)connection.myReader["birthdate"]; //I think this one's going to be problematic
                readPerson.Email = (string)connection.myReader["email"];
                readPerson.PhoneNumber = (string)connection.myReader["phoneNumber"];

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return readPerson;

        }

        public List<Person> getPersonList()
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();
            connection.myCommand.CommandText = "SELECT id, firstName, lastName, birthdate, email, phoneNumber FROM Personas";
            connection.myReader = connection.myCommand.ExecuteReader();

            if (connection.myReader.HasRows)
            {
                //Read method points to the next record.
                //It also returns true if it's pointing to a record and there are more left
                while (connection.myReader.Read())
                {
                    Person readPerson = new Person();
                    readPerson.ID = (int) connection.myReader["id"];
                    readPerson.FirstName = (string) connection.myReader["firstName"];
                    readPerson.LastName = (string) connection.myReader["lastName"];
                    readPerson.Birthdate = (DateTime) connection.myReader["birthdate"]; //I think this one's going to be problematic
                    readPerson.Email = (string) connection.myReader["email"];
                    readPerson.PhoneNumber = (string) connection.myReader["phoneNumber"];

                    //If the field is null, use this code:
                    //if (connection.myReader["email"] != System.DBNull.Value)
                    //{ readPerson.Email = (string) connection.myReader["email"]; }

                    //Adding retrieved records to our PersonList
                    PersonList.Add(readPerson);

                }
            }

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return PersonList;

        }
       // public List<Person> getPersonListBy() { }
        public void updatePerson(int id, Person newPerson)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information, if any
            connection.openConnection();
            connection.myCommand.CommandText = "UPDATE Personas" +
                                              $"SET firstName = {newPerson.FirstName}," +
                                              $"SET lastName = {newPerson.LastName}," +
                                              $"SET birthdate = {newPerson.Birthdate}," +
                                              $"SET email = {newPerson.Email}," +
                                              $"SET phoneNumber = {newPerson.PhoneNumber}," +
                                              $"SET DepartmentID = {newPerson.DepartmentID}";
            //New department ID would have to be verified

            //Executing non-query statement and passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }
        public void deletePerson(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection = new MyConnection();
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            connection.myCommand.CommandText = "DELETE FROM Personas" +
                                               $"WHERE id = {id}";

            //Executing non-query statement and passing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }
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

            connection.myCommand.CommandText = "INSERT INTO Personas (firstName, lastName, birthdate, email, phoneNumber, DepartmentID" +
                                               $"VALUES  {newPerson.FirstName}," +
                                               $" {newPerson.LastName}," +
                                               $" {newPerson.Birthdate}," +
                                               $" {newPerson.Email}," +
                                               $" {newPerson.PhoneNumber}," +
                                               $" {newPerson.DepartmentID}";
                                                 //DepartmentID should be verified

            //Executing non-query statement andPassing the value of rows affected to our handler's property
            this.rowsAffected = connection.myCommand.ExecuteNonQuery();

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();
        }
    }
}
