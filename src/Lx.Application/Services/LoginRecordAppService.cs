using AutoMapper;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Interfaces.SystemManager;
using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Services
{
    public class LoginRecordAppService : ILoginRecordAppService
    {
        //Ioc依赖注入
        private readonly ILoginRecordRepository _repository;
        //用来进行DTO
        private readonly IMapper _mapper;

        public LoginRecordAppService(ILoginRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public void Add(LoginRecordViewModel model)
        {
            //如果是平时的写法，必须要引入Student领域模型，会造成污染
            _repository.addLoginRecoid(_mapper.Map<LoginRecord>(model));
            _repository.SaveChanages();
        }

        public IEnumerable<LoginRecordViewModel> GetByPage(int pageSize, int pageIndex, string startDate, string endDate)
        {
            return _mapper.Map<IEnumerable<LoginRecordViewModel>>(
                _repository.GetByPage(
                    pageSize,
                    pageIndex,
                    t => (string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate)),
                    t => t.CreateTime,
                    false
                ));
        }

        public int GetCount(string startDate, string endDate)
        {
            return _repository.GetCount(
                t => (string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate)));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
