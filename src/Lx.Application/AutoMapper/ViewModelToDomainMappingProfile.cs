using AutoMapper;
using Lx.Application.ViewModels;
using Lx.Application.ViewModels.SystemManager;
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
            //登录
            CreateMap<LoginViewModel, Login>();

            //商家账户注册命令
            CreateMap<MerchantsAccountViewModel, AddMerchantsAccountCommand>()
                .ConstructUsing(t => new AddMerchantsAccountCommand(t.NickName,t.Email,t.Phone,t.PassWord));
            //商家账户修改命令
            CreateMap<MerchantsAccountViewModel, UpdateMerchantsAccountCommand>()
                .ConstructUsing(t => new UpdateMerchantsAccountCommand(t.Id, t.NickName, t.Email, t.Phone, t.PassWord));
            //商家账户
            CreateMap<MerchantsAccountViewModel, MerchantsAccount>();

            //登录记录
            CreateMap<LoginRecordViewModel, LoginRecord>()
                .ForPath(d => d.MerchantsAccount.Id, o => o.MapFrom(s => s.MerchantId))
                .ForPath(d => d.MerchantsAccount.NickName, o => o.MapFrom(s => s.MerchantNickName));
        }
    }
}
