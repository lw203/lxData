using AutoMapper;
using IdentityServer4.Models;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Core.Bus;
using Lx.Domain.Interfaces.SystemManager;
using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Services
{
    public class UserAccountAppService : IUserAccountAppService
    {
        //Ioc依赖注入
        private readonly IUserAccountRepository _repository;
        //用来进行DTO
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public UserAccountAppService(IUserAccountRepository repository, IMapper mapper, IMediatorHandler bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;

        }

        public IEnumerable<UserAccountViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserAccountViewModel>>(_repository.GetAll());
        }

        public UserAccountViewModel GetById(Guid id)
        {
            return _mapper.Map<UserAccountViewModel>(_repository.GetById(id));
        }

        public IEnumerable<UserAccountViewModel> GetByPage(int pageSize, int pageIndex, string UserName, string phone, string email, string startDate, string endDate)
        {
            return _mapper.Map<IEnumerable<UserAccountViewModel>>(
                _repository.GetByPage(
                    pageSize,
                    pageIndex,
                    t => (string.IsNullOrWhiteSpace(UserName) ? true : t.UserName == UserName) &
                         (string.IsNullOrWhiteSpace(phone) ? true : t.Phone == phone) &
                         (string.IsNullOrWhiteSpace(email) ? true : t.Email == email) &
                         ((string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate))),
                    t => t.CreateTime,
                    false
                ));
        }

        public int GetCount(string userName, string phone, string email, string startDate, string endDate)
        {
            return _repository.GetCount(
                t => (string.IsNullOrWhiteSpace(userName) ? true : t.UserName == userName) &
                     (string.IsNullOrWhiteSpace(phone) ? true : t.Phone == phone) &
                     (string.IsNullOrWhiteSpace(email) ? true : t.Email == email) &
                     ((string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate)) ? true : (t.CreateTime >= Convert.ToDateTime(startDate) & t.CreateTime <= Convert.ToDateTime(endDate)))
                    );
        }

        public UserAccountViewModel UserLogin(string loginName, string passWord)
        {
            return _mapper.Map<UserAccountViewModel>(_repository.UserLogin(loginName, passWord));
        }

        public void Add(UserAccountViewModel model)
        {
            // 执行添加方法
            model.Id = Guid.NewGuid();
            model.PassWord = model.PassWord.Sha256();
            model.CreateTime = DateTime.Now;
            var command = _mapper.Map<AddUserAccountCommand>(model);
            _bus.SendCommand(command);
        }

        public void Update(UserAccountViewModel model)
        {
            var command = _mapper.Map<UpdateUserAccountCommand>(model);
            _bus.SendCommand(command);
        }

        public void Remove(Guid id)
        {
            //_studentRepository.Remove(id);
        }

        public void AddLoginRecord(LoginRecordViewModel model)
        {
            _repository.AddLoginRecord(_mapper.Map<LoginRecord>(model));
            _repository.SaveChanages();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
