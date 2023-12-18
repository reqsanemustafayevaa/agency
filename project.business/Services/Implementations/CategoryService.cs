using project.business.Services.Interfaces;
using project.Core.Models;
using project.Core.Repositories.Interfaces;
using project.data.Repostories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepostory _categoryeepository;
        public CategoryService(ICategoryRepostory categoryRepostory)
        {
            _categoryeepository=categoryRepostory;
        }
        public async Task CreateAsync(Category entity)
        {
            if (_categoryeepository.Table.Any(x => x.Name == entity.Name))
            {
                throw new NullReferenceException();
            }
            await _categoryeepository.CreateAsync(entity);
            await _categoryeepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _categoryeepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            _categoryeepository.DeleteAsync(entity);
            await _categoryeepository.CommitAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryeepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity = await _categoryeepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            return entity;
        }

        public async Task UpdateAsync(Category entity)
        {
            var existentity = await _categoryeepository.GetByIdAsync(x => x.Id == entity.Id && x.IsDeleted == false);
            if (_categoryeepository.Table.Any(x => x.Name == entity.Name && existentity.Id != entity.Id))
            {
                throw new NullReferenceException();
            }
            existentity.Name = entity.Name;
            await _categoryeepository.CommitAsync();
        }
    }
}
