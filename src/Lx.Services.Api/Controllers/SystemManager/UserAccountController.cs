using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Lx.Domain.Core.Notifications;
using Lx.Redis;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Lx.Services.Api.Controllers.SystemManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ApiController
    {
        private readonly IUserAccountAppService _appService;
        private readonly DomainNotificationHandler _notifications;

        public UserAccountController(IUserAccountAppService appService, INotificationHandler<DomainNotification> notifications)
        {
            _appService = appService;
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpGet("login")]
        public IActionResult UserLogin(string loginName, string passWord)
        {
            if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(passWord))
            {
                return CustomResponse(new Response(ErrorCode.账号和密码不能为空));
            }
            var data = _appService.UserLogin(loginName, passWord.Sha256());
            if (data == null)
            {
                return CustomResponse(new Response(ErrorCode.账号或密码错误));
            }

            //var a = RedisHelper.Default.SetStringKey<UserAccountViewModel>(data.Id.ToString(), data, TimeSpan.FromSeconds(1));
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        public IEnumerable<UserAccountViewModel> GetAll()
        {
            return _appService.GetAll();
        }

        [HttpGet("GetByPage")]
        public IActionResult GetByPage(int pageSize, int pageIndex, string userName, string phone, string email, string startDate, string endDate)
        {
            var list = _appService.GetByPage(pageSize, pageIndex, userName, phone, email, startDate, endDate);
            if (list == null || list.Count() < 1)
            {
                return CustomResponse(new Response(ErrorCode.查无数据));
            }
            int pageCount = _appService.GetCount(userName, phone, email, startDate, endDate);

            var data = new { pageIndex, pageSize, pageCount, list };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        [HttpPost("add-user")]
        public IActionResult Post([FromBody]UserAccountViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));

            _appService.Add(model);

            // 是否存在消息通知
            if (_notifications.HasNotifications())
            {
                var list = _notifications.GetNotifications();
                return CustomResponse(new Response(1, string.Join(',', list.Select(t => t.Value).ToArray())));
            }
            return CustomResponse(new Response(ErrorCode.成功, model));
        }

        [HttpPut("UserEdit")]
        public IActionResult Put([FromBody]UserAccountViewModel model)
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

        [HttpPost("UploadAvatar")]
        public async Task<IActionResult> uploadAvatar(IFormFile file)
        {
            var filePath = Path.Combine("E:\\images", file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return CustomResponse(new Response(ErrorCode.成功, filePath));
        }
    }
}