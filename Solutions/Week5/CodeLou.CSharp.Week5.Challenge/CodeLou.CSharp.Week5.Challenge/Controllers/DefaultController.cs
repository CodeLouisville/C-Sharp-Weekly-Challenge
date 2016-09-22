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
        private string _MySqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        private string _MsSqlConnectionString = ConfigurationManager.ConnectionStrings["MsSqlConnectionString"].ConnectionString;
        private string _LocalFileConnectionString = ConfigurationManager.ConnectionStrings["LocalFileConnectionString"].ConnectionString;
        private string _OrderDirection { get { return Session["OrderDirection"].ToString(); } set { Session["OrderDirection"] = value;  } }
        // GET: Default
        public ActionResult Index(string OrderBy, string OrderDirection = "ASC")
        {
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

            string sql = "SELECT * FROM Employee";

            ViewBag.EnableSorting = true;
            if (!String.IsNullOrEmpty(OrderBy))
            {
                sql += String.Format(" ORDER BY {0} {1}", OrderBy, OrderDirection);

                if (OrderDirection == "ASC")
                {
                    _OrderDirection = "DESC";
                }
                else
                {
                    _OrderDirection = "ASC";
                }

                ViewBag.OrderDirection = _OrderDirection;
            }
            
            List<Employee> allEmployees = repository.GetEmployees(sql);
            return View(allEmployees);
        }
        // GET: Detail
        public ActionResult Details(int id)
        {
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);
            string sql = String.Format("SELECT * FROM Employee WHERE Id = {0}", id);

            Employee employee = repository.GetOneEmployee(sql);
            return View(employee);
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
            try
            {
                SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

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

                sql += $" WHERE Id = {employee.Id}";

                repository.UpdateEmployee(sql);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorText = ex.ToString();
                return View("Error");
            }
        }
        // GET: Delete
        public ActionResult Delete(int id)
        {
            SqlRepository repository = new SqlRepository(_LocalFileConnectionString);
            string sql = String.Format("SELECT * FROM Employee WHERE Id = {0}", id);

            Employee employee = repository.GetOneEmployee(sql);
            ViewBag.EmployeeFullName = String.Format("{0} {1}", employee.FirstName, employee.LastName);

            return View(employee);
        }
        // POST: Delete
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                SqlRepository repository = new SqlRepository(_LocalFileConnectionString);
                string sql = $"DELETE FROM Employee WHERE Id = {employee.Id}";

                repository.DeleteEmplyee(sql);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorText = ex.ToString();
                return View("Error");
            }
        }
        // GET: Create
        public ActionResult Create()
        {
            return View(new Employee { HireDate = DateTime.Now, StartTime = "9:00 AM", ActiveEmployee = true });
        }
        // POST: Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                SqlRepository repository = new SqlRepository(_LocalFileConnectionString);

                string sql = String.Format($@"INSERT INTO Employee(PositionId, DepartmentId, FirstName, LastName, Email, Phone, Extension, HireDate, StartTime, ActiveEmployee, TerminationDate) 
                Values(
                1,
                1,
                '{employee.FirstName}',
                '{employee.LastName}',
                '{employee.EMail}',
                '{employee.Phone}',
                '{employee.Extension}',
                '{employee.HireDate.ToString()}',
                '{employee.StartTime}',
                ");

                if (employee.ActiveEmployee)
                {
                    sql += $"1";
                }
                else
                {
                    sql += $"0";
                }

                if (employee.TerminationDate.HasValue)
                {
                    sql += $", '{employee.TerminationDate.Value.ToString()}'";
                }
                else
                {
                    sql += $", null";
                }

                sql += $")";

                repository.CreateEmployee(sql);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorText = ex.ToString();
                return View("Error");
            }
        }        
    }    
}