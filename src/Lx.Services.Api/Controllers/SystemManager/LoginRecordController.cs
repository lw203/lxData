using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.ViewModels.SystemManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers.SystemManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRecordController : ApiController
    {
        private readonly ILoginRecordAppService _appService;

        public LoginRecordController(ILoginRecordAppService appService)
        {
            _appService = appService;
        }

        [HttpPost("AddLoginRecord")]
        public IActionResult Post([FromBody]LoginRecordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));
                //执行添加方法
                model.Id = Guid.NewGuid();
                model.CreateTime = DateTime.Now.ToString();
                _appService.Add(model);

                return CustomResponse(new Response(ErrorCode.成功, model));
            }
            catch (Exception ex)
            {
                return CustomResponse(new Response(1, ex.Message));
            }
        }

        [HttpGet("GetByPage")]
        public IActionResult GetByPage(int pageSize, int pageIndex, string startDate, string endDate)
        {
            var list = _appService.GetByPage(pageSize, pageIndex, startDate, endDate);
            if (list == null || list.Count() < 1)
            {
                return CustomResponse(new Response(ErrorCode.查无数据));
            }
            int pageCount = _appService.GetCount(startDate, endDate);

            var data = new { pageIndex, pageSize, pageCount, list };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }
    }
}