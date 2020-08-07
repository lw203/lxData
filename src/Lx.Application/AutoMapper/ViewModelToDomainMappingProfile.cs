using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Commands.Student;
using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Models;
using Lx.Domain.Models.SystemManager;
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

            CreateMap<MerchantsAccountViewModel, AddMerchantsAccountCommand>()
                .ConstructUsing(t => new AddMerchantsAccountCommand(t.NickName,t.Email,t.Phone,t.PassWord));
            CreateMap<MerchantsAccountViewModel, UpdateMerchantsAccountCommand>()
                .ConstructUsing(t => new UpdateMerchantsAccountCommand(t.Id, t.NickName, t.Email, t.Phone, t.PassWord));
            CreateMap<MerchantsAccountViewModel, MerchantsAccount>();

        }
    }
}
