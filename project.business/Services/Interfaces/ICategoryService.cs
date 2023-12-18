using project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category entity);
        Task Delete(int id);

        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category entity);
    }
}
