using project.Core.Models;
using project.Core.Repositories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Repostories.Implementations
{
    public class CategoryRepository : GenericRepostory<Category>, ICategoryRepostory
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
