using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers.SystemManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsAccountController : ApiController
    {
        private readonly IMerchantsAccountAppService _appService;
        private readonly DomainNotificationHandler _notifications;

        public MerchantsAccountController(IMerchantsAccountAppService appService, INotificationHandler<DomainNotification> notifications)
        {
            _appService = appService;
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpGet("MerchantsLogin")]
        public IActionResult MerchantsLogin(string loginName, string passWord)
        {
            if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(passWord))
            {
                return CustomResponse(new Response(ErrorCode.账号和密码不能为空));
            }
            var data = _appService.MerchantsLogin(loginName, passWord.Sha256());
            if (data == null)
            {
                return CustomResponse(new Response(ErrorCode.账号或密码错误));
            }
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        public IEnumerable<MerchantsAccountViewModel> GetAll()
        {
            return _appService.GetAll();
        }

        [HttpGet("GetByPage")]
        public IActionResult GetByPage(int pageSize, int pageIndex, string nickName, string phone, string email, string startDate, string endDate)
        {
            var list = _appService.GetByPage(pageSize, pageIndex, nickName, phone, email, startDate, endDate);
            if (list == null || list.Count() < 1)
            {
                return CustomResponse(new Response(ErrorCode.查无数据));
            }
            int pageCount = _appService.GetCount(nickName, phone, email, startDate, endDate);

            var data = new { pageIndex, pageSize, pageCount, list };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        [HttpPost("MerchantsRegister")]
        public IActionResult Post([FromBody]MerchantsAccountViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));
            // 执行添加方法
            model.Id = Guid.NewGuid();
            model.PassWord = model.PassWord.Sha256();
            model.CreateTime = DateTime.Now;
            _appService.Add(model);

            // 是否存在消息通知
            if (_notifications.HasNotifications())
            {
                var list = _notifications.GetNotifications();
                return CustomResponse(new Response(1, string.Join(',', list.Select(t => t.Value).ToArray())));
            }
            return CustomResponse(new Response(ErrorCode.成功, model));
        }

        [HttpPut("MerchantsEdit")]
        public IActionResult Put([FromBody]MerchantsAccountViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));

            _appService.Update(model);

            // 是否存在消息通知
            if (_notifications.HasNotifications())
            {
                var list = _notifications.GetNotifications();
                return CustomResponse(new Response(1, string.Join(',', list.Select(t => t.Value).ToArray())));
            }
            return CustomResponse(new Response(ErrorCode.成功, model));
        }
    }
}