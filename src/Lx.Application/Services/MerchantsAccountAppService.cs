using AutoMapper;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
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

        public async Task<IEnumerable<MerchantsAccountViewModel>> GetByPage<Tkey>(int pageSize, int pageIndex, string nickName, string phone, string email, DateTime startDate, DateTime endDate)
        {
            return _mapper.Map<IEnumerable<MerchantsAccountViewModel>>(
                _repository.GetByPage(
                    pageSize,
                    pageIndex,
                    t => string.IsNullOrWhiteSpace(t.NickName) ? true : t.NickName == nickName &
                         string.IsNullOrWhiteSpace(t.Phone) ? true : t.Phone == phone &
                         string.IsNullOrWhiteSpace(t.Email) ? true : t.Email == email,
                    t => t.CreateTime,
                    false
                ));
        }

        public Task<int> GetCount(string nickName, string phone, string email, DateTime startDate, DateTime endDate)
        {
            return _repository.GetCount(
                t => string.IsNullOrWhiteSpace(t.NickName) ? true : t.NickName == nickName &
                     string.IsNullOrWhiteSpace(t.Phone) ? true : t.Phone == phone &
                     string.IsNullOrWhiteSpace(t.Email) ? true : t.Email == email);
        }

        public async Task<List<MerchantsAccountViewModel>> GetData(string nickName, string phone, string email, DateTime startDate, DateTime endDate)
        {
            return _mapper.Map<List<MerchantsAccountViewModel>>(_repository.GetData(nickName, phone, email, startDate, endDate));
        }

        public MerchantsAccountViewModel MerchantsLogin(string loginName, string passWord)
        {
            return _mapper.Map<MerchantsAccountViewModel>(_repository.MerchantsLogin(loginName, passWord));
        }

        public void Register(MerchantsAccountViewModel model)
        {
            //var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            //_bus.SendCommand(registerCommand);

            //如果是平时的写法，必须要引入Student领域模型，会造成污染
            //_studentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanages();
        }

        public void Update(MerchantsAccountViewModel model)
        {
            //_studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanages();
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
