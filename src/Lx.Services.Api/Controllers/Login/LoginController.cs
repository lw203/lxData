using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ApiController
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [HttpGet]
        public LoginViewModel Get(string loginName,string passWord)
        {
            return _loginAppService.Login(loginName, passWord);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<LoginViewModel> GetAll()
        {
            return _loginAppService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState); //添加命令验证，采用构造函数方法实例
            // 执行添加方法
            loginViewModel.Id = Guid.NewGuid();
            loginViewModel.CreateTime = DateTime.Now;
            _loginAppService.Register(loginViewModel);
            return CustomResponse(loginViewModel);
            //return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(_studentAppService.Register(studentViewModel));
        }
    }
}