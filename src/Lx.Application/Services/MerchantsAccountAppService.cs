using AutoMapper;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Core.Bus;
using Lx.Domain.Interfaces.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Services
{
    public class MerchantsAccountAppService : IMerchantsAccountAppService
    {
        //Ioc依赖注入
        private readonly IMerchantsAccountRepository _repository;
        //用来进行DTO
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public MerchantsAccountAppService(IMerchantsAccountRepository repository, IMapper mapper, IMediatorHandler bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;

        }

        public IEnumerable<MerchantsAccountViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<MerchantsAccountViewModel>>(_repository.GetAll());
        }

        public MerchantsAccountViewModel GetById(Guid id)
        {
            return _mapper.Map<MerchantsAccountViewModel>(_repository.GetById(id));
        }

        public IEnumerable<MerchantsAccountViewModel> GetByPage(int pageSize, int pageIndex, string nickName, string phone, string email, string startDate, string endDate)
        {
            return _mapper.Map<IEnumerable<MerchantsAccountViewModel>>(
                _repository.GetByPage(
                    pageSize,
                    pageIndex,
                    t => (string.IsNullOrWhiteSpace(nickName) ? true : t.NickName == nickName) &
                         (string.IsNullOrWhiteSpace(phone) ? true : t.Phone == phone) &
                         (string.IsNullOrWhiteSpace(email) ? true : t.Email == email) &
                         ((string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate))),
                    t => t.CreateTime,
                    false
                ));
        }

        public int GetCount(string nickName, string phone, string email, string startDate, string endDate)
        {
            return _repository.GetCount(
                t => (string.IsNullOrWhiteSpace(nickName) ? true : t.NickName == nickName) &
                     (string.IsNullOrWhiteSpace(phone) ? true : t.Phone == phone) &
                     (string.IsNullOrWhiteSpace(email) ? true : t.Email == email) &
                     ((string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate)))
                    );
        }

        public async Task<List<MerchantsAccountViewModel>> GetData(string nickName, string phone, string email, DateTime startDate, DateTime endDate)
        {
            return _mapper.Map<List<MerchantsAccountViewModel>>(_repository.GetData(nickName, phone, email, startDate, endDate));
        }

        public MerchantsAccountViewModel MerchantsLogin(string loginName, string passWord)
        {
            return _mapper.Map<MerchantsAccountViewModel>(_repository.MerchantsLogin(loginName, passWord));
        }

        public void Add(MerchantsAccountViewModel model)
        {
            var command = _mapper.Map<AddMerchantsAccountCommand>(model);
            _bus.SendCommand(command);
        }

        public void Update(MerchantsAccountViewModel model)
        {
            var command = _mapper.Map<UpdateMerchantsAccountCommand>(model);
            _bus.SendCommand(command);
        }

        public void Remove(Guid id)
        {
            //_studentRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
