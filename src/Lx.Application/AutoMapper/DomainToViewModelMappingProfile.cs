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
            //登录
            CreateMap<Login, LoginViewModel>();

            //商家账户
            CreateMap<MerchantsAccount, MerchantsAccountViewModel>();

            //登录记录
            CreateMap<LoginRecord, LoginRecordViewModel>()
                .ForMember(d => d.MerchantId, o => o.MapFrom(s => s.MerchantsAccount.Id))
                .ForMember(d => d.MerchantNickName, o => o.MapFrom(s => s.MerchantsAccount.NickName));
        }
    }
}
