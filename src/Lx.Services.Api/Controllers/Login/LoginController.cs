using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Commons;
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
        public IActionResult Get(string loginName,string passWord)
        {
            passWord = GlobalFunction.sha256(passWord);
            var info = _loginAppService.Login(loginName, passWord);
            if (info == null)
            {
                return CustomResponse(new Response(1, "账号或密码错误"));
            }
            return CustomResponse(new Response(0, "成功", info));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _loginAppService.GetAll();
            if(list==null || list.ToList().Count()<1)
            {
                return CustomResponse(new Response(400, "查无数据"));
            }
            return CustomResponse(new Response(0, "成功", list));
        }

        [HttpPost]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState); //添加命令验证，采用构造函数方法实例
            // 执行添加方法
            loginViewModel.Id = Guid.NewGuid();
            loginViewModel.PassWord = GlobalFunction.sha256(loginViewModel.PassWord);
            loginViewModel.CreateTime = DateTime.Now;
            _loginAppService.Register(loginViewModel);
            return CustomResponse(new Response(0, "成功", loginViewModel));
            //return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(_studentAppService.Register(studentViewModel));
        }
    }
}