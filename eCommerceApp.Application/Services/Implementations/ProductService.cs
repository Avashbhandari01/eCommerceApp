using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Services.Implementations
{
    public class ProductService(IGeneric<Product> _product, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await _product.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product added successfully!") :
                new ServiceResponse(false, "Product failed to be added!");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await _product.DeleteAsync(id);
            return result > 0 ? new ServiceResponse(true, "Product deleted successfully!") :
                new ServiceResponse(false, "Product failed to be deleted!");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var data = await _product.GetAllAsync();
            if (!data.Any()) return [];

            return mapper.Map<IEnumerable<GetProduct>>(data);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var data = await _product.GetByIdAsync(id);
            if (data == null) return new GetProduct();

            return mapper.Map<GetProduct>(data);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await _product.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product updated successfully!") :
                new ServiceResponse(false, "Product failed to be updated!");
        }
    }
}
