using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //signature for property each and every repository interface
        public IEmployeesRepository EmployeesRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
       Task<int> completeAsync();
      
    }
}
