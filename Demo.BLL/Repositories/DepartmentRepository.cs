using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository : GenaricRepository<Department> , IDepartmentRepository
    {
     public DepartmentRepository(MVCDbContext dbContext):base(dbContext) { }
        
        //private MVCDbContext _dbContext; // dh attribute byshawr 3la address el object elli el clr carito
        //public DepartmentRepository(MVCDbContext dbContext) //ask el clr for object from eldbcontextBB
        //{ 
        //    _dbContext = dbContext;
        //}
        //public int add(Department department)
        //{
        //    _dbContext.Add(department);//add localy
        //    return _dbContext.SaveChanges();// h3ml sve 3shan tsma3

        //}

        //public int delete(Department department)
        //{
        //    _dbContext.Remove(department);//add localy
        //    return _dbContext.SaveChanges();// h3ml sve 3shan tsma3
        //}

        //public IEnumerable<Department> Getall()  // 3aiz yrag3 kol eldepartment
        //{
        //   return _dbContext.Departments.ToList();
        //}

        //public Department Getbyid(int id)
        //{
        //    //var department = _dbContext.Departments.Local.where(d=>d.Id==id).FirstOrDefault;
        //    //if(department == null)
        //    //    _dbContext.Departments.Where(d=>d.Id== id).FirstOrDefault();
        //    //return department;
        //  return  _dbContext.Departments.Find(id);
        //}

        //public int update(Department department)
        //{
        //    _dbContext.Update(department);//add localy
        //    return _dbContext.SaveChanges();// h3ml sve 3shan tsma3
        //}
    }
}
