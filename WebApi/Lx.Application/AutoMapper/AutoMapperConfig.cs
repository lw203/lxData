using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.AutoMapper
{
    /// <summary>
    /// 静态全局 AutoMapper 配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg => 
            {
                //领域模型 -> 视图模型的映射，读命令
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                //视图模型 -> 领域模型的映射， 写命令
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
