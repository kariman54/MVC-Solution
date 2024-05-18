using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly MVCDbContext _dbContext;

        public GenaricRepository(MVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task addasync(T item)
        {
          await _dbContext.AddAsync(item);
        }

        public void delete(T item)
        {
            _dbContext.Remove(item);
        }

        //public async Task<IEnumerable<T>> GetallAsync()
        //=>
        //   await   _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync()
        =>
            await _dbContext.Set<T>().ToListAsync();
        

        public async Task<T> GetbyidAsync(int id)
        =>
          await  _dbContext.Set<T>().FindAsync(id);

        

        public void update(T item)
        {

            _dbContext.Update(item);
          
        }
    }
}
