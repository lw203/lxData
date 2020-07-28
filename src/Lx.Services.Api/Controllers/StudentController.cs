using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Lx.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers
{
    [ApiController]
    public class StudentController : ApiController
    {
        private readonly IStudentAppService _studentAppService;
        // 将领域通知处理程序注入Controller
        private readonly DomainNotificationHandler _notifications;

        public StudentController(IStudentAppService studentAppService, INotificationHandler<DomainNotification> notifications)
        {
            _studentAppService = studentAppService;
            // 强类型转换
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpGet("Student")]
        [Authorize]
        public IEnumerable<StudentViewModel> Get()
        {     
            return  _studentAppService.GetAll();
        }

        [HttpGet("Student/GetById/{id:guid}")]
        public StudentViewModel GetById(Guid id)
        {
            return _studentAppService.GetById(id);
        }

        [HttpGet("Student/GetByEmail")]
        public StudentViewModel GetByEmail(string email)
        {
            return _studentAppService.GetByEmail(email);
        }

        [HttpPost("Student")]
        public IActionResult Post([FromBody]StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(1, "失败", ModelState)); //添加命令验证，采用构造函数方法实例
            // 执行添加方法
            _studentAppService.Register(studentViewModel);

            // 是否存在消息通知
            if (_notifications.HasNotifications())
            {
                var list = _notifications.GetNotifications();
                return CustomResponse(new Response(1, string.Join(',',list.Select(t=>t.Value).ToArray())));
            }        
            return CustomResponse(new Response(0, "成功"));
            //return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(_studentAppService.Register(studentViewModel));
        }
    }
}