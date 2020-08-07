using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Models;
using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.AutoMapper
{
    /// <summary>
    /// 配置构造函数，用来创建关系映射
    /// </summary>
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(d => d.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street))
                .ForMember(d => d.County, o => o.MapFrom(s => s.Address.County))
                ;

            CreateMap<Login, LoginViewModel>();

            CreateMap<MerchantsAccount, MerchantsAccountViewModel>();
        }
    }
}
