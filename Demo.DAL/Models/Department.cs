﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "code is required")]
        public string Code { get; set; }
        public DateTime Dateofcretion { get; set; }
        [InverseProperty("Department")]
        public ICollection<Employees> Employees { get; set; } = new HashSet<Employees>() ;
    }
}
