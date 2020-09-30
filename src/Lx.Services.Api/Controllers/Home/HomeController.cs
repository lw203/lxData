using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces.SystemManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ApiController
    {
        private readonly ILoginRecordAppService _loginRecordAppService;

        public HomeController(ILoginRecordAppService loginRecordAppService)
        {
            _loginRecordAppService = loginRecordAppService;
        }
    }
}