using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Application.ViewModels.DataManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Models;
using Lx.Domain.Models.DataManager;
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
            //登录
            CreateMap<LoginViewModel, Login>();

            //账户注册命令
            CreateMap<UserAccountViewModel, AddUserAccountCommand>()
                .ConstructUsing(t => new AddUserAccountCommand(t.UserName,t.Email,t.Phone,t.PassWord));
            //账户修改命令
            CreateMap<UserAccountViewModel, UpdateUserAccountCommand>()
                .ConstructUsing(t => new UpdateUserAccountCommand(t.Id, t.UserName, t.Email, t.Phone, t.PassWord));
            //账户
            CreateMap<UserAccountViewModel, UserAccount>();

            //登录记录
            CreateMap<LoginRecordViewModel, LoginRecord>()
                .ForPath(d => d.UserAccount.Id, o => o.MapFrom(s => s.UserId))
                .ForPath(d => d.UserAccount.UserName, o => o.MapFrom(s => s.NickName));

            CreateMap<PeopleAddViewModel, People>();
            CreateMap<PeopleViewModel, People>();
            CreateMap<PeopleDetailViewModel, PeopleDetail>();
            CreateMap<TagAddViewModel, Tag>();
        }
    }
}
