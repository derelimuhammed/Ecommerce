using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
     public interface IProductRepository : IEntityRepository<Product>
    {
        //Task<IEnumerable<AdminProductDetails>> GetAdminProducts();
        Task<Product?> GetWithOptionsAndImagesByProductId(Guid productid);
        //Task<AdminProductDetail> GetAdminProduct(int productid);
        Task<Product?> GetProductWithImagesByIdAsync(Guid id);
        //Task<ProductDetail> GetProductDetail(string slug);
        //IQueryable<ProductWithMainImage> GetProductsWithImage(ProductFilter filter);
        //Task<IEnumerable<ProductWithMainImage>> GetLast10ProductsWithImage();
        Task<Product> GetProductWithImagesByCategoryIdAsync(Guid categoryid);
    }
}
