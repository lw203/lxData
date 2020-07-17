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
    public class StudentController : ControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [HttpGet]
        public IEnumerable<StudentViewModel> Get()
        {
            string a = Guid.NewGuid().ToString("N");
            
            return  _studentAppService.GetAll();
        }
    }
}