using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Application.ViewModels.DataManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Models;
using Lx.Domain.Models.DataManager;
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
            //登录
            CreateMap<Login, LoginViewModel>();

            //账户
            CreateMap<UserAccount, UserAccountViewModel>();

            //登录记录
            CreateMap<LoginRecord, LoginRecordViewModel>()
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserAccount.Id))
                .ForMember(d => d.NickName, o => o.MapFrom(s => s.UserAccount.NickName));

            //人物
            CreateMap<People, PeopleViewModel>()
                .ForMember(d => d.Dynasty, o => o.MapFrom(s => s.DynastyCode));
                //.ForMember(d => d.peopleDetails, o => o.MapFrom(s => s.peopleDetails));
            CreateMap<PeopleDetail, PeopleDetailViewModel>();
            CreateMap<Tag, TagViewModel>();
        }
    }
}
