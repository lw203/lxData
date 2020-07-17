﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Lx.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lx.Application.Services
{
    /// <summary>
    /// StudentAppService 服务接口实现类，继承 服务接口
    /// 通过 DTO 实现视图模型和领域模型的关系处理
    /// 作为调度者，协调领域层和基础层
    /// 这里制作一个面向用户用例的服务接口，不包含业务规则
    /// </summary>
    public class StudentAppService : IStudentAppService
    {
        //Ioc依赖注入
        private readonly IStudentRepository _studentRepository;
        //用来进行DTO
        private readonly IMapper _mapper;

        public StudentAppService(IStudentRepository StudentRepository, IMapper Mapper)
        {
            _studentRepository = StudentRepository;
            _mapper = Mapper;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            //第一种写法 Map
            return _mapper.Map<IEnumerable<StudentViewModel>>( _studentRepository.GetAll());
            
            //第二种写法 ProjectTo
            //return (_studentRepository.GetAll()).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            //如果是平时的写法，必须要引入Student领域模型，会造成污染
            //_studentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanages();
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            //_studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanages();
        }

        public void Remove(Guid id)
        {
            //_studentRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
