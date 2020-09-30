using AutoMapper;
using Lx.Application.Interfaces.DataManager;
using Lx.Application.ViewModels.DataManager;
using Lx.Domain.Interfaces.DataManager;
using Lx.Domain.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lx.Application.Services.DataManager
{
    public class TagAppService : ITagAppService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagAppService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public List<TagViewModel> GetAll()
        {
            var list = _mapper.Map<IEnumerable<TagViewModel>>(_tagRepository.GetAll()).ToList<TagViewModel>();
            var roots = list.Where(t => t.ParentId == Guid.Empty).ToList();
            foreach (var item in roots)
            {
                getChild(item, list);
            }
            return roots;
        }

        public void Add(TagAddViewModel model)
        {
            // 执行添加方法
            model.Id = Guid.NewGuid();
            model.CreateTime = DateTime.Now;

            _tagRepository.Add(_mapper.Map<Tag>(model));
            _tagRepository.SaveChanages();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private TagViewModel getChild(TagViewModel model, List<TagViewModel> list)
        {
            model.ChildTags = list.Where(t => t.ParentId == model.Id).ToList();
            if (model.ChildTags != null && model.ChildTags.Count > 0)
            {
                foreach(var item in model.ChildTags)
                {
                    getChild(item, list);
                }
            }
            return model;
        }
    }
}
