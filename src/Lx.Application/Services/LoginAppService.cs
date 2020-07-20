using AutoMapper;
using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Lx.Domain.Interfaces;
using Lx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginAppService(ILoginRepository LoginRepository, IMapper Mapper)
        {
            this._loginRepository = LoginRepository;
            _mapper = Mapper;
        }

        public IEnumerable<LoginViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<LoginViewModel>>(_loginRepository.GetAll());
        }
        public LoginViewModel GetById(Guid id)
        {
            return _mapper.Map<LoginViewModel>(_loginRepository.GetById(id));
        }

        public LoginViewModel Login(string loginName, string passWord)
        {
            return _mapper.Map<LoginViewModel>(_loginRepository.Login( loginName,  passWord));
        }

        public void Register(LoginViewModel LoginViewModel)
        {
            //如果是平时的写法，必须要引入Student领域模型，会造成污染
            _loginRepository.Add(_mapper.Map<Login>(LoginViewModel));
            _loginRepository.SaveChanages();
        }

        public void Update(LoginViewModel LoginViewModel)
        {
            //_loginRepository.Update(_mapper.Map<Student>(LoginViewModel));
            //_loginRepository.SaveChanages();
        }

        public void Remove(Guid id)
        {
            //_loginRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
