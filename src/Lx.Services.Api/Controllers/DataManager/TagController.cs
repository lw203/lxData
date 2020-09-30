using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces.DataManager;
using Lx.Application.ViewModels.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers.DataManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ApiController
    {
        private readonly ITagAppService _appService;

        public TagController(ITagAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var list = _appService.GetAll();
            if (list == null)
            {
                return CustomResponse(new Response(ErrorCode.查无数据));
            }
            var data = new { list };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        [HttpPost("add-tag")]
        public IActionResult Post([FromBody]TagAddViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));

            _appService.Add(model);

            return CustomResponse(new Response(ErrorCode.成功, model));
        }
    }
}