using AutoMapper;
using Demo.DAL.Models;
using Demo.pl.ViewModels;

namespace Demo.pl.mappingprofile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employees>().ReverseMap();
        }
    }
}
