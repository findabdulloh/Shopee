using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Categories;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private IGenericRepository<Category> genericRepository = new GenericRepository<Category>();
        public Task<Category> CreateAsync(CategoryCreationDto dto)
        {
            var entity = this.genericRepository.GetAsync(u => u.Name == dto.Name);

            if(entity != null) 
                return null;

            var mapperCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            var addModel = this.genericRepository.InsertAsync(mapperCategory);

            return addModel;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = this.genericRepository.GetAsync(c=> c.Id == id);

            if (entity is null)
                return false;

            await this.genericRepository.DeleteAsync(c => c.Id == id);
            return true;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return  this.genericRepository.GetAllAsync();
        }

        public Task<Category> GetByIdAsync(long id)
        {
            return this.genericRepository.GetAsync(c => c.Id == id);
        }

        public Task<Category> ModifyAsync(long id, CategoryCreationDto dto)
        {
            var category = this.genericRepository.GetAsync(c => c.Id == id);
            if (category is null)
                return null;

            var mappedCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            var updatedCategory = this.genericRepository.UpdateAsync(mappedCategory);
            return updatedCategory;
        }
    }
}
