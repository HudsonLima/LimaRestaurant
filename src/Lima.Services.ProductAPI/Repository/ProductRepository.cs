using AutoMapper;
using Lima.Services.ProductAPI.DbContexts;
using Lima.Services.ProductAPI.Models;
using Lima.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Lima.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else 
            {
                _db.Products.Add(product);

            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProducByIdAsync(int productId)
        {
            Product productList = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync(); 
            return _mapper.Map<ProductDto>(productList);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
