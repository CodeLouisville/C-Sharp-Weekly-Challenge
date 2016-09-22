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

        // TODO: Bonus - Install MySql or Microsoft SQL Server Express and use it instead of the localdb file.
        private string _MySqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        private string _MsSqlConnectionString = ConfigurationManager.ConnectionStrings["MsSqlConnectionString"].ConnectionString;
        private string _LocalFileConnectionString = ConfigurationManager.ConnectionStrings["LocalFileConnectionString"].ConnectionString;
        
        // GET: Default
        public ActionResult Index(string OrderBy, string OrderDirection = "ASC")
        {
            // Instantiate a repository class so you can start using data, since we're using SQL Repository, pass in either the
            // local file connection string or MsSql connection string, as the libraries they use are the same.
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

            // Create a list of employees to return to the view based on our SQL statement

            // Basic select statement, however we do not get all the information we need.
            string sql = "SELECT * FROM Employee";

            #region Bonus - Joining another table
            // TODO: Bonus - Joining another table
            // remember relational databased store additional data in other tables. If we join
            // our employee on the Department table and Position table then we get that information to display            
            //string sql = "SELECT * FROM Employee E INNER JOIN Department D ON D.Id = E.DepartmentId INNER JOIN Position P ON P.Id = E.PositionId";
            #endregion

            // TODO: How to we order the data by a column, enable sorting?
            ViewBag.EnableSorting = false;
            if (!String.IsNullOrEmpty(OrderBy))
            {
                // sql += ??
                // TODO: Bonus - How do we persist the OrderDirection?
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
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);
            string sql = String.Format("SELECT * FROM Employee WHERE Id = {0}", id);        

            Employee employee = repository.GetOneEmployee(sql);
            ViewBag.EmployeeFullName = String.Format("{0} {1}", employee.FirstName, employee.LastName);

            return View(employee);
        }
        // POST: Edit
        [HttpPost]        
        public ActionResult Edit(Employee employee)
        {
            // TODO: Bonus - Saving an employee failed. What happens next?
            
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

            // Note: there is a way better way to do this using parameterized sql, but since we're practicing sql we're going it this way
            // Also, since we're writing SQL Code as a string in C# pay attension to quotes that you would use in an actual query.
            // luckily Sql uses single quotes for strings, so no need to escape them here.
            string sql = String.Format($@"UPDATE Employee SET 
            PositionId = {employee.PositionId},
            DepartmentId = {employee.DepartmentId},
            FirstName = '{employee.FirstName}',
            LastName = '{employee.LastName}',
            Email = '{employee.EMail}',
            Phone = '{employee.Phone}',
            Extension = '{employee.Extension}',
            HireDate = '{employee.HireDate.ToString()}',
            StartTime = '{employee.StartTime}',
            ");

            if (employee.ActiveEmployee)
            {
                sql += $" ActiveEmployee = 1";
            }
            else
            {
                sql += $" ActiveEmployee = 0";
            }

            if (employee.TerminationDate.HasValue)
            {
                sql += $", TerminationDate = '{employee.TerminationDate.Value.ToString()}'";
            }

            // really important step, to specifiy the employee id you want to update
            // as of right now this command will update EVERYONE in the Employee table
            // to these values
            sql += $" WHERE Id = {employee.Id}";

            // Note: if you want to see what your string says all combined, set a breakpoint and debug your code.
            // While in debug mode you can hover over a variable to see it's value. Or right click on it and
            // select Quick Watch.

            repository.UpdateEmployee(sql);
            
            return RedirectToAction("Index");
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
            // Hint: This method will be similar to the update method.
            // Hint: for now set the Position and Department to Id 1
            
            // TODO: Create employee from form submission, redirect to list
            return View();
        }        
    }    
}