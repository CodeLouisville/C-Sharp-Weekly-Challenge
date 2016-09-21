using CodeLou.CSharp.Week4.Challenge.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeLou.CSharp.Week4.Challenge.Controllers
{
    public class DefaultController : Controller
    {
        // get connection strings from your webconfig
        // Note: It is best practice to store your connection string in a file that does not have to be compiled, like the webconfig
        // If something happens and a server goes down, you can change your webconfig and not have to redeploy your code.
        private string _MySqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        private string _MsSqlConnectionString = ConfigurationManager.ConnectionStrings["MsSqlConnectionString"].ConnectionString;
        private string _LocalFileConnectionString = ConfigurationManager.ConnectionStrings["LocalFileConnectionString"].ConnectionString;
        
        // GET: Default
        public ActionResult Index(string OrderBy)
        {
            // I am going to add my SQL directly here for the demonstration, however it is not good practice to do so. It definitely violates separation of concerns

            // Create a list of employees to return to the view based on our SQL statement

            // Basic select statement, however we do not get all the information we need.
            // string sql = "SELECT * FROM Employee";

            // remember relational databased store additional data in other tables. If we join
            // our employee on the Department table and Position table then we get that information to display

            string sql = "SELECT * FROM Employee E INNER JOIN Department D ON D.Id = E.DepartmentId INNER JOIN Position P ON P.Id = E.PositionId";

            // TODO: How to we order the data by a column, enable sorting?
            if (!String.IsNullOrEmpty(OrderBy))
            {
                
            }

            List<Employee> allEmployees = getEmployees(sql);
            return View(allEmployees);
        }
        // GET: Detail
        public ActionResult Details(int id)
        {
            // TODO: Create View For Details and return employee model to view
            return View();
        }
        // GET: Edit
        public ActionResult Edit(int id)
        {
            // TODO: Return employee model to edit view
            return View();
        }
        // POST: Edit
        [HttpPost]        
        public ActionResult Edit(Employee employee)
        {
            // TODO: Create employee from form submission, redirect to list
            return View();
        }
        // GET: Delete
        public ActionResult Delete(int id)
        {
            // TODO: Create View For Delete and return employee model to view
            return View();
        }
        // POST: Delete
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            // TODO: Delete employee from the database and redirect to list
            return View();
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            // TODO: Create employee from form submission, redirect to list
            return View();
        }

        private void deleteEmplyee(int Id)
        { 
            // TODO: Delete Employee based on the Id
        }
        private void createEmployee(Employee employee)
        { 
            // TODO: Create an employee based on the model
        }
        private Employee getOneEmployee(int Id)
        {
            // TODO: Get only 1 employee from the database matching the Id passed in.
            return null;
        }
        private List<Employee> getEmployees(string Where)
        {
            // Create a list of employees to return to the view
            List<Employee> allEmployees = new List<Employee>();

            // Connection to your SQL server, MySql, MsSql, Local MDF File
            using (SqlConnection connection = new SqlConnection(_LocalFileConnectionString))
            {
                // The SQL command you want to run on your server to get data back
                using (SqlCommand command = new SqlCommand(Where, connection))
                {
                    // The adapter that is responsible for connecting to the database and getting the data
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // This is the variable that will contain all of your data returned to you
                        DataSet dataSet = new DataSet();

                        // Fill the dataset
                        adapter.Fill(dataSet);

                        // First lets check to see if we have any data
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
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

                                // is the table joined?, remember relational databased store additional data in other tables. If we join
                                // our employee on the Department table and Position table then we get that information to display
                                if (row["DepartmentName"] != DBNull.Value)
                                {
                                    employee.DepartmentName = row["DepartmentName"].ToString();
                                }

                                if (row["PositionName"] != DBNull.Value)
                                {
                                    employee.PositionName = row["PositionName"].ToString();
                                }

                                // add the employee to the list of employees
                                allEmployees.Add(employee);
                            }
                        }
                    }
                }
            }

            return allEmployees;
        }
    }    
}