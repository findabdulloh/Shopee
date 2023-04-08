using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Categories;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private IGenericRepository<Category> genericRepository = new GenericRepository<Category>(new ShopeDbContext());

        public async Task<Category> CreateAsync(CategoryCreationDto dto)
        {
            var entity = await genericRepository.GetAsync(u => u.Name == dto.Name);

            if(entity is not null) 
                return null;

            var mapperCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            var addedModel = await genericRepository.InsertAsync(mapperCategory);

            return addedModel;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await genericRepository.GetAsync(c=> c.Id == id);

            if (entity is null)
                return false;

            await genericRepository.DeleteAsync(c => c.Id == id);
            return true;
        }

        public async Task<List<Category>> GetAllAsync()
        {
             var entities = await genericRepository.GetAllAsync();
            return entities.ToList();
        }

        public async Task<Category> GetByIdAsync(long id)
        {
            var entity = await this.genericRepository.GetAsync(c => c.Id == id);
            if (entity is null) 
                return null;

            return entity;
        }

        public async Task<Category> ModifyAsync(long id, CategoryCreationDto dto)
        {
            var category = await genericRepository.GetAsync(c => c.Id == id);
            if (category is null)
                return null;

            var mappedCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            var updatedCategory = await genericRepository.UpdateAsync(mappedCategory);
            return updatedCategory;
        }
    }
}
