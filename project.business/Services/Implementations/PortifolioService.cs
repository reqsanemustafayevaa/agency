using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.Core.Models;
using project.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class PortifolioService : IPortifolioService
    {
        private readonly IPortifolioRepostory _portifolioRepostory;
        private readonly ICategoryRepostory _categoryRepostory;
        public PortifolioService(IPortifolioRepostory portifolioRepostory,ICategoryRepostory categoryRepostory)
        {
            _portifolioRepostory = portifolioRepostory;
            _categoryRepostory= categoryRepostory;
        }
        public async Task CreateAsync(Portiofolio entity)
        {
            if (_portifolioRepostory.Table.Any(x => x.Name == entity.Name))
            {
                throw new NullReferenceException();
            }
            if (_categoryRepostory.Table.Any(x => x.Id == entity.CategoryId))
            {
                throw new NotFoundException("CategoryId", "Category not found");
            }
           
                if (entity.ImageFile.ContentType != "image/png" && entity.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "can must be .png or .jpeg");
                }
                if (entity.ImageFile.Length > 2097152)
                {
                    throw new NotFoundException("ImageFile", "hecm 2 mb dan cox ola bilmez");
                }
            await _portifolioRepostory.CreateAsync(entity);
            await _portifolioRepostory.CommitAsync();




        }

        public async Task Delete(int id)
        {
            var entity = await _portifolioRepostory.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            _portifolioRepostory.DeleteAsync(entity);
            await _portifolioRepostory.CommitAsync();
        }

        public async Task<List<Portiofolio>> GetAllAsync()
        {
            return await _portifolioRepostory.GetAllAsync();
        }

        public async Task<Portiofolio> GetByIdAsync(int id)
        {
            var entity = await _portifolioRepostory.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            return entity;
        }

        public async Task UpdateAsync(Portiofolio entity)
        {
            var existentity = await _portifolioRepostory.GetByIdAsync(x => x.Id == entity.Id && x.IsDeleted == false);
            if (_portifolioRepostory.Table.Any(x => x.Name == entity.Name && existentity.Id != entity.Id))
            {
                throw new NullReferenceException();
            }
           

            if (entity.ImageFile.ContentType != "image/png" && entity.ImageFile.ContentType != "image/jpeg")
            {
                throw new ImageContentException("ImageFile", "can must be .png or .jpeg");
            }
            if (entity.ImageFile.Length > 2097152)
            {
                throw new NotFoundException("ImageFile", "hecm 2 mb dan cox ola bilmez");
            }


            existentity.Name = entity.Name;
            
            await _portifolioRepostory.CommitAsync();
        }
    }
}
