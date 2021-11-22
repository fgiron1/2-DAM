using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Connection;
using DAL.Handlers;
using Entities;

namespace DAL.Lists
{
    public class PersonListDAL
    {
        public MyConnection connection { get; set; }

        //This field reflects the number of rows affected by the last instruction executed.
        //Helps debug code. (0 fields mean erroneous statement or no changes made,
        //                  -1 fields means no rows were read by a SELECT instruction)
        public int rowsAffected { get; set; }
        public PersonListDAL()
        {
            this.connection = new MyConnection();
        }
        public Person getPerson(int id)
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection.myCommand = new SqlCommand();
            Person readPerson = new Person();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            connection.openConnection();

            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT ID, FirstName, LastName, Birthdate, Email, PhoneNumber, DepartmentID " +
                                               "FROM dbo.Persons " +
                                               "WHERE ID = @id";


            connection.myCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                connection.myReader = connection.myCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw e;
            }

            //Passing the value of rows affected to our handler's property
            //this.rowsAffected = connection.myReader.RecordsAffected;
            connection.myReader.Read();

            readPerson.id = (int)connection.myReader["ID"];
            readPerson.FirstName = (string)connection.myReader["FirstName"];
            readPerson.LastName = (string)connection.myReader["LastName"];
            readPerson.Birthdate = (DateTime)connection.myReader["Birthdate"]; //I think this one's going to be problematic
            readPerson.Email = (string)connection.myReader["Email"];
            readPerson.PhoneNumber = (string)connection.myReader["PhoneNumber"];
            readPerson.DepartmentID = (int)connection.myReader["DepartmentID"];

            //Closing reader and connection
            this.connection.myReader.Close();
            this.connection.closeConnection();

            return readPerson;

        }
        public List<Person> getPersonList()
        {
            //Opening and closing methods already check for possible exceptions. No need to wrap them around try catch again

            //Instantiating necessary objects
            connection.myCommand = new SqlCommand();
            List<Person> PersonList = new List<Person>();

            //Opening DB connection -> setting SQL sentence as a SqlCommand object -> SQLCommand object executes the code and returns
            //a new reader, passed to our own reader -> Reader returns queried information
            
            connection.openConnection();
            //Passing myConnection property to myCommand's own connection property
            connection.myCommand.Connection = connection.myConnection;

            connection.myCommand.CommandText = "SELECT ID, FirstName, LastName, Birthdate, Email, PhoneNumber, DepartmentID FROM Persons";
            connection.myReader = connection.myCommand.ExecuteReader();
            

            if (connection.myReader.HasRows)
            {
                //Read method points to the next record.
                //It also returns true if it's pointing to a record and there are more left
                while (connection.myReader.Read())
                {

                    Person readPerson = new Person();
                    readPerson.id = (int)connection.myReader["ID"];
                    readPerson.FirstName = (string)connection.myReader["FirstName"];
                    readPerson.LastName = (string)connection.myReader["LastName"];
                    readPerson.Birthdate = (DateTime)connection.myReader["Birthdate"];
                    readPerson.Email = (string)connection.myReader["Email"];
                    readPerson.PhoneNumber = (string)connection.myReader["PhoneNumber"];
                    readPerson.DepartmentID = (int)connection.myReader["DepartmentID"];

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

    }
}
