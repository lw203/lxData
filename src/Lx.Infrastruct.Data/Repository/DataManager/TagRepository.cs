using Lx.Domain.Interfaces.DataManager;
using Lx.Domain.Models.DataManager;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lx.Infrastruct.Data.Repository.DataManager
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(LxContext context) : base(context)
        {

        }
    }
}
