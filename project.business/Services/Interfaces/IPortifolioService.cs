using project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IPortifolioService
    {
        Task CreateAsync(Portiofolio entity);
        Task Delete(int id);

        Task<List<Portiofolio>> GetAllAsync();
        Task<Portiofolio> GetByIdAsync(int id);
        Task UpdateAsync(Portiofolio entity);

    }
}
