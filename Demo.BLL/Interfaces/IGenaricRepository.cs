using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenaricRepository<T>
    {
       Task<IEnumerable<T>> GetAllAsync();
       Task <T> GetbyidAsync(int id);
        Task addasync(T item);
        void update(T item);
        void delete(T item);
    }
}
