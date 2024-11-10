using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;

namespace eCommerceApp.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();

        Task<GetCategory> GetByIdAsync(Guid id);

        Task<ServiceResponse> AddAsync(CreateCategory product);

        Task<ServiceResponse> UpdateAsync(UpdateCategory product);

        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
