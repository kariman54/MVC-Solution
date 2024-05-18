using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOFWork : IUnitOfWork
    {
        private readonly MVCDbContext _dbContext;

        public IEmployeesRepository EmployeesRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public UnitOFWork(MVCDbContext dbContext)// ask clr foor object from dbcontex
        {
            EmployeesRepository = new EmployeeRepository(dbContext); 
            DepartmentRepository = new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> completeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
