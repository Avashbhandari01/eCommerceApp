using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Services.Implementations
{
    public class CategoryService(IGeneric<Category> _category, IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await _category.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category added successfully!") :
                new ServiceResponse(false, "Category failed to be added!");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await _category.DeleteAsync(id);

            return result > 0 ? new ServiceResponse(true, "Category deleted successfully!") :
                new ServiceResponse(false, "Category not found or failed to be deleted!");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var data = await _category.GetAllAsync();
            if (!data.Any()) return [];

            return mapper.Map<IEnumerable<GetCategory>>(data);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var data = await _category.GetByIdAsync(id);
            if (data == null) return new GetCategory();

            return mapper.Map<GetCategory>(data);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await _category.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category updated successfully!") :
                new ServiceResponse(false, "Category failed to be updated!");
        }
    }
}
