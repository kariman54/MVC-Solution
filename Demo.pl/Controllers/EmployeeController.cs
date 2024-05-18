using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.pl.Helpers;
using Demo.pl.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.pl.Controllers
{
    public class EmployeeController : Controller
    {
        
       
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork , //ask clr to create obj
         IMapper mapper) // ask cl for create object from class to implement IEmployeesRepository
        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task <IActionResult> Index(string searchvalue)
        {
            IEnumerable<Employees> employees;
            if (string.IsNullOrEmpty(searchvalue))

           employees  = await _unitOfWork.EmployeesRepository.GetAllAsync();
              
            else

           employees =  _unitOfWork.EmployeesRepository.Getemployeesbyname(searchvalue);
            var mappedemployee = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedemployee);

        }
       
        [HttpGet]
        public async Task <IActionResult> Create()
        {

            var employee = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(EmployeeViewModel employeevm)
        {
            if (ModelState.IsValid) //server side validation
            {
               employeevm.Imagename= Documentsetting.uploadfile(employeevm.Image, "images");

              var mappedemployee =  _mapper.Map<EmployeeViewModel,Employees>(employeevm);
               await _unitOfWork.EmployeesRepository.addasync(mappedemployee);
                await _unitOfWork.completeAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(employeevm);//to show client issu

        }

        public async Task <IActionResult> Details(int? id, string viewname = "Details")
        {
            if (id is null)

            return BadRequest();// client error 400
            var employee = await  _unitOfWork.EmployeesRepository.GetbyidAsync(id.Value);
            if (employee is null)
                return NotFound();
            var mappedemployee = _mapper.Map<Employees , EmployeeViewModel>(employee);
            return View(viewname, mappedemployee);

        }
        [HttpGet]
        public async Task <IActionResult> Edit(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var employee = _employeeRepository.Getbyid(id.Value);
            //if (employee is null)
            //    return NotFound();
            //return View(employee);
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(EmployeeViewModel employeevm, [FromRoute] int id)
        {
            if (id != employeevm.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                   employeevm.Imagename = Documentsetting.uploadfile(employeevm.Image, "images");
                    var mappedemployee = _mapper.Map<EmployeeViewModel, Employees>(employeevm);
                     _unitOfWork.EmployeesRepository.update(mappedemployee);
                   await _unitOfWork.completeAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1.log
                    //2.form
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeevm);
        }
        [HttpGet]
        public async Task <IActionResult> Delete(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var employee = _employeeRepository.Getbyid(id.Value);
            //if (employee is null)
            //    return NotFound();
            //return View(employee);
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(EmployeeViewModel employee, [FromRoute] int id)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedemployee = _mapper.Map<EmployeeViewModel, Employees>(employee);
                     _unitOfWork.EmployeesRepository.delete(mappedemployee);
                   var result = await _unitOfWork.completeAsync();
                    if(result > 0 && employee.Imagename is not null)
                    {
                        Documentsetting.Deletefile(employee.Imagename, "images");
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1.log
                    //2.form
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(employee);
        }
    }
}
