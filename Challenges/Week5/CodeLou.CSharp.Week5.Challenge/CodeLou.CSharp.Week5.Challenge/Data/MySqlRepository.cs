using CodeLou.CSharp.Week5.Challenge.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CodeLou.CSharp.Week5.Challenge.Data
{
    public class MySqlRepository
    {
        /// <summary>
        /// Normally it is bad form to pass in a SQL statements directly to your repository methods, but this if for demonstration purposes.
        /// Here is more information on why you shouldn't do this in a real enviroment.
        /// https://en.wikipedia.org/wiki/SQL_injection
        /// </summary>
        private string _ConnectionString;
        /// <summary>
        /// Instantiate a new MySqlRepository class to make available methods to CRUD to a Database
        /// </summary>
        /// <param name="ConnectionString">Connection to mysql server</param>
        public MySqlRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        /// <summary>
        /// Delete an Employee
        /// <para>What SQL statement can we use to delete an employee? Remember to be super careful here as you could delete all data
        /// in that table.</para>
        /// </summary>
        /// <param name="DeleteStatement">SQL Delete Statement</param>
        public void DeleteEmplyee(string DeleteStatement)
        {
            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (MySqlConnection connection = new MySqlConnection(_ConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (MySqlCommand command = new MySqlCommand(DeleteStatement, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Create an Employee
        /// <para>What SQL statement can we use to insert an employee?</para>
        /// </summary>
        /// <param name="InsertStatement">SQL Insert Statement</param>
        public void CreateEmployee(string InsertStatement)
        {
            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (MySqlConnection connection = new MySqlConnection(_ConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (MySqlCommand command = new MySqlCommand(InsertStatement, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Update an Employee
        /// <para>What SQL statement can we use to update an employee? Be careful 
        /// as you could update everyone in the table to whatever parameters you add here... as in everyone's 
        /// FirstName could be changed to Pam.</para>
        /// </summary>
        /// <param name="UpdateStatement">SQL Update Statement</param>
        public void UpdateEmployee(string UpdateStatement)
        {
            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (MySqlConnection connection = new MySqlConnection(_ConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (MySqlCommand command = new MySqlCommand(UpdateStatement, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Get a single Employee
        /// <para>
        /// What SQL statement can we use to select just one employee?</para>
        /// </summary>
        /// <param name="Where">SQL Select One Statement</param>
        /// <returns></returns>
        public Employee GetOneEmployee(string Where)
        {
            // Create an employee to return to the view
            Employee employee = new Employee();

            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (MySqlConnection connection = new MySqlConnection(_ConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (MySqlCommand command = new MySqlCommand(Where, connection))
                {
                    // The adapter that is responsible for connecting to the database and getting the data
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // This is the variable that will contain all of your data returned to you
                        DataSet dataSet = new DataSet();

                        // Fill the dataset
                        adapter.Fill(dataSet);

                        // First lets check to see if we have any data
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            // I used a #region tag to section off code, you can expand it by clicking the plus sign on the left.
                            #region Fill Employee Class
                            // If we have data, now we have to convert it into a View Model, so MVC can create our view. Since
                            // you can make a view strongly typed (meaning you can only pass a certain view model to it) we cannot
                            // pass the raw Table to the view.

                            // We only want 1 employee, so we do not need to loop through any data, assuming we only have 1 returned result

                            // new Employee
                            // the column names are the same as our properties for ease of use
                            // it's best to do this so you don't have to guess what property maps to what column

                            // be sure to match up the datatypes from SQL. You'll have to convert INT and Dates etc.
                            DataRow row = dataSet.Tables[0].Rows[0];
                            employee.ActiveEmployee = Convert.ToBoolean(row["ActiveEmployee"]);
                            employee.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
                            employee.EMail = row["EMail"].ToString();
                            employee.Extension = row["Extension"].ToString();
                            employee.FirstName = row["FirstName"].ToString();
                            employee.LastName = row["LastName"].ToString();
                            employee.HireDate = Convert.ToDateTime(row["HireDate"]);
                            employee.Id = Convert.ToInt32(row["Id"]);
                            employee.Phone = row["Phone"].ToString();
                            employee.PositionId = Convert.ToInt32(row["PositionId"]);
                            employee.StartTime = row["StartTime"].ToString();

                            // be sure to check for null values as well
                            if (row["TerminationDate"] != DBNull.Value)
                            {
                                employee.TerminationDate = Convert.ToDateTime(row["TerminationDate"]);
                            }
                            

                            #endregion
                        }
                    }
                }
            }

            return employee;
        }
        /// <summary>
        /// Get all Employees
        /// <para>What SQL statement can we use to get all employees in the database. This one is a bit more powerful, since it's an open where statement.
        /// As I said before, this is NOT normally how you would get a list of employees... however, you can get employees by more than 1 metric. Say, how do I get
        /// a list of employees in a single department? Or how do I get all managers?</para>
        /// </summary>
        /// <param name="Where">SQL Select Many Statement</param>
        /// <returns></returns>
        public List<Employee> GetEmployees(string Where)
        {
            // Create a list of employees to return to the view
            List<Employee> allEmployees = new List<Employee>();

            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (MySqlConnection connection = new MySqlConnection(_ConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (MySqlCommand command = new MySqlCommand(Where, connection))
                {
                    // The adapter that is responsible for connecting to the database and getting the data
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // This is the variable that will contain all of your data returned to you
                        DataSet dataSet = new DataSet();

                        // Fill the dataset
                        adapter.Fill(dataSet);

                        // First lets check to see if we have any data
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            // I used a #region tag to section off code, you can expand it by clicking the plus sign on the left.
                            #region Fill Employee Class

                            // If we have data, now we have to convert it into a View Model, so MVC can create our view. Since
                            // you can make a view strongly typed (meaning you can only pass a certain view model to it) we cannot
                            // pass the raw Table to the view.

                            // loop through all the rows
                            foreach (DataRow row in dataSet.Tables[0].Rows)
                            {
                                // new Employee
                                // the column names are the same as our properties for ease of use
                                // it's best to do this so you don't have to guess what property maps to what column

                                // also be sure to match up the datatypes from SQL. You'll have to convert INT and Dates etc.
                                Employee employee = new Employee();
                                employee.ActiveEmployee = Convert.ToBoolean(row["ActiveEmployee"]);
                                employee.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
                                employee.EMail = row["EMail"].ToString();
                                employee.Extension = row["Extension"].ToString();
                                employee.FirstName = row["FirstName"].ToString();
                                employee.LastName = row["LastName"].ToString();
                                employee.HireDate = Convert.ToDateTime(row["HireDate"]);
                                employee.Id = Convert.ToInt32(row["Id"]);
                                employee.Phone = row["Phone"].ToString();
                                employee.PositionId = Convert.ToInt32(row["PositionId"]);
                                employee.StartTime = row["StartTime"].ToString();

                                // be sure to check for null values as well
                                if (row["TerminationDate"] != DBNull.Value)
                                {
                                    employee.TerminationDate = Convert.ToDateTime(row["TerminationDate"]);
                                }

                                // add the employee to the list of employees
                                allEmployees.Add(employee);
                            }
                            #endregion
                        }
                    }
                }
            }

            return allEmployees;
        }
    }
}