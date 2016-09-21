using CodeLou.CSharp.Week5.Challenge.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeLou.CSharp.Week5.Challenge.Controllers
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
            // new up a repository class so you can start using data, since we're using SQL Repository, pass in either the
            // local file connection string or MsSql connection string, as the libraries they use are the same.
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

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

            List<Employee> allEmployees = repository.GetEmployees(sql);
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
    }    
}