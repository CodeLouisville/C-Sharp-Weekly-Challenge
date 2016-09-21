using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLou.CSharp.Week4.Challenge.Models
{
    // Note: view models generally do not contain any SQL code. They are only supposed to contain Methods and Properties that pertain
    // to your front facing website.    

    // The data attributes that you see here (above each property) are MVC related attributes that help MVC
    // try to decide what to do with the propery when displaying it on the website

    // Some properties you do not want to display by default, such as Primary Key Ids etc, but are essential to help I identify that data in the database
    public class Department
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }   
             
        [ScaffoldColumn(false)]
        public int FloorId { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int PositionId { get; set; }

        [ScaffoldColumn(false)]
        public int? DepartmentId { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Ext.")]
        public string Extension { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Termination Date")]
        [DataType(DataType.DateTime)]
        [ScaffoldColumn(false)]
        public DateTime? TerminationDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        public bool ActiveEmployee { get; set; }

        // joined properties
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Position")]
        public string PositionName { get; set; }
    }    
    public class Floor
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Floor Number")]
        public int FloorNumber { get; set; }

        [Required]
        [Display(Name = "Floor Name")]
        public string FloorName { get; set; }
    }    
    public class Position
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }
    }
}