using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Lx.Domain.Commands.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers
{
    [ApiController]
    public class StudentController : ApiController
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [HttpGet("Student")]
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

        [HttpPost("Student1")]
        public IActionResult Post([FromBody]StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState); //添加命令验证，采用构造函数方法实例
            RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate, studentViewModel.Phone, studentViewModel.Province, studentViewModel.City, studentViewModel.County,studentViewModel.Street); //如果命令无效，证明有错误
            if (!registerStudentCommand.IsValid())
            {
                List<string> errorInfo = new List<string>(); //获取到错误，请思考这个Result从哪里来的 
                foreach (var error in registerStudentCommand.ValidationResult.Errors)
                {
                    errorInfo.Add(error.ErrorMessage);
                } //对错误进行记录，还需要抛给前台
                return CustomResponse(errorInfo);
            } // 执行添加方法
            _studentAppService.Register(studentViewModel);
            return CustomResponse(studentViewModel);
            //return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(_studentAppService.Register(studentViewModel));
        }
    }
}