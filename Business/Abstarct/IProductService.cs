using Business.DTOs;
using Business.Filters;
using Core.Ultilities.Responses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductWithImagesByCategoryIdAsync(Guid categoryid);
        Task<IResponse> AddAsync(ProductDTO model);
        Task<IResponse> UpdateAsync(ProductDTO model);
        Task<IResponse> RemoveAsync(Guid id);
        Task<IResponse> GetProductDetail(string slug);
        Task<IResponse> GetAllAdminProducts();
        Task<IResponse> GetAdminProduct(Guid productid);
        IResponse GetProductsWithImage(ProductFilter filter);
        Task<IResponse> GetLast10ProductsWithImage();
    }
}
