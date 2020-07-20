using Lx.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Interfaces
{
    public interface ILoginAppService : IDisposable
    {
        void Register(LoginViewModel loginViewModel);

        IEnumerable<LoginViewModel> GetAll();

        LoginViewModel GetById(Guid id);

        void Update(LoginViewModel loginViewModel);

        void Remove(Guid id);
        LoginViewModel Login(string loginName, string passWord);
    }
}
