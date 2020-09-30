using AutoMapper;
using Lx.Application.Interfaces.DataManager;
using Lx.Application.ViewModels.DataManager;
using Lx.Domain.Core.Bus;
using Lx.Domain.Interfaces.DataManager;
using Lx.Domain.Models.DataManager;
using Lx.Domain.Shared.DataManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Services.DataManager
{
    public class PeopleAppService : IPeopleAppService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public PeopleAppService(IPeopleRepository peopleRepository, IMapper mapper, IMediatorHandler bus)
        {
            _peopleRepository = peopleRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public IEnumerable<PeopleViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PeopleViewModel>>(_peopleRepository.GetAll());
        }

        public IEnumerable<PeopleViewModel> GetByPage(int pageSize, int pageIndex, string dynasty)
        {
            return _mapper.Map<IEnumerable<PeopleViewModel>>(
                _peopleRepository.GetByPage(
                    pageSize,
                    pageIndex,
                    t => string.IsNullOrWhiteSpace(dynasty) ? true : t.Dynasty.ToString() == dynasty,
                    t => t.PeopleName,
                    false
                ));
        }

        public int GetCount(string dynasty)    
        {
            return _peopleRepository.GetCount(
                    t => string.IsNullOrWhiteSpace(dynasty) ? true : t.Dynasty.ToString() == dynasty
                );
        }
        
        public void Add(PeopleAddViewModel model)
        {
            // 执行添加方法
            model.Id = Guid.NewGuid();
            model.CreateTime = DateTime.Now;

            _peopleRepository.Add(_mapper.Map<People>(model));
            _peopleRepository.SaveChanages();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
