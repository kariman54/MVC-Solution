using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.pl.Controllers
{
  
    public class DepartmentController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)//ask clr for creating object from class implement interface IDepartmentRepository
        {
            _unitOfWork = unitOfWork;
        }
        public async Task <IActionResult> Index()
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Department department)
        {
            if (ModelState.IsValid) //server side validation
            {
                await _unitOfWork.DepartmentRepository.addasync(department);
                int result = await _unitOfWork.completeAsync();
                if (result>0)
                {
                    TempData["message"] = "departmentn is created";
                }
             
                return RedirectToAction(nameof(Index));
            }
            return View(department);//to show client issu

        }

        public async Task <IActionResult> Details(int? id, string viewname = "Details")
        {
            if (id is null)

                return BadRequest();// client error 400
            var department = await _unitOfWork.DepartmentRepository.GetbyidAsync(id.Value);
            if (department is null)
                return NotFound();
            return View(viewname, department);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var department =  _unitOfWork.EmployeesRepository.Getbyid(id.Value);
            //if (department is null)
            //    return NotFound();
            //return View(department);
            return await Details(id, "Edit");
        }
           
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(Department department, [FromRoute] int id)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.update(department);
                    await _unitOfWork.completeAsync();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    //1.log
                    //2.form
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
        [HttpGet]
        public async Task <IActionResult> Delete(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var department =  _unitOfWork.EmployeesRepository.Getbyid(id.Value);
            //if (department is null)
            //    return NotFound();
            //return View(department);
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(Department department, [FromRoute] int id)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.delete(department);
                   await _unitOfWork.completeAsync();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    //1.log
                    //2.form
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(department);
        }
    }
}
