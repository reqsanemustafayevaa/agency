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
    public class PortifolioRepostory : GenericRepostory<Portiofolio>, IPortifolioRepostory
    {
        public PortifolioRepostory(AppDbContext context) : base(context)
        {
        }
    }
}
