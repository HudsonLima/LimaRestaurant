using Lima.Services.ProductAPI.Models.Dto;

namespace Lima.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProducByIdAsync(int productId);

        Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto);

        Task<bool> DeleteProductAsync(int productId);
    }
}
