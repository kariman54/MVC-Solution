using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IEmployeesRepository : IGenaricRepository<Employees>
    {
        #region
        ////first we make a signetures 
        //IEnumerable<Employees> Getall(); // htrg3 list of Employee
        //Employees Getbyid(int id);
        //int add(Employees employee); // int 3shan 3dd el rows el affected
        //int update(Employees employee);
        //int delete(Employees employee);
        #endregion

        //ienumrablle<employee> // filter in application then give you your request
        IQueryable<Employees> Getemployeesbyaddress(string address);   // filter in database your request yhen give you the answer match condition
        IQueryable<Employees> Getemployeesbyname(string searchvalue);
    }
}
