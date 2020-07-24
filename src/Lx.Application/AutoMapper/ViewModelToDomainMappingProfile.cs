using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Domain.Commands.Student;
using Lx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
                .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
                .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street))
                ;

            CreateMap<StudentViewModel, RegisterStudentCommand>()
                .ConstructUsing(c => new RegisterStudentCommand(c.Name, c.Email, c.BirthDate, c.Phone, c.Province, c.City,
            c.County, c.Street));

            CreateMap<LoginViewModel, Login>();

        }
    }
}
