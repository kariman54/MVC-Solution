using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartmentRepository : IGenaricRepository<Department>
    {
        ////first we make a signetures 
        //IEnumerable<Department> Getall(); // htrg3 list of department
        //Department Getbyid(int id);
        //int add(Department department); // int 3shan 3dd el rows el affected
        //int update(Department department);
        //int delete(Department department);

    }
}
