using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenaricRepository<Employees> , IEmployeesRepository
    {
        private readonly MVCDbContext _dbContext;
        #region
        //private readonly MVCDbContext _dbContext;

        //public EmployeeRepository(MVCDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public int add(Employees employee)
        //{
        //   _dbContext.Add(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public int delete(Employees employee)
        //{
        //    _dbContext.Remove(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public IEnumerable<Employees> Getall()
        //=>
        //   _dbContext.Employees.ToList();


        //public Employees Getbyid(int id)
        //=>
        //    _dbContext.Employees.Find(id);// find locally first then db


        //public int update(Employees employee)
        //{
        //    _dbContext.Update(employee);
        //    return _dbContext.SaveChanges();
        //}
        #endregion

        public EmployeeRepository(MVCDbContext dbContext) : base(dbContext)
        {
              _dbContext = dbContext;
        }

        public IQueryable<Employees> Getemployeesbyaddress(string address)
        =>
            _dbContext.Employees.Where(e => e.Address == address);

        public IQueryable<Employees> Getemployeesbyname(string searchvalue)
        =>
            _dbContext.Employees.Where(e => e.Name.ToLower().Contains(searchvalue.ToLower()));

        
    }
}
