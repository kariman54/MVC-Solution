using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employees
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
    
        public int? Age { get; set; }
        public string Address { get; set; }
      
        public decimal Salary { get; set; }
        
        public string Email { get; set; }
        public string Imagename { get; set; }   
        public string Phonenumber { get; set; } 
        public DateTime Hiredate { get; set; }
        public DateTime Creationdate { get; set; } = DateTime.Now;
        public bool Isactive { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }
}
