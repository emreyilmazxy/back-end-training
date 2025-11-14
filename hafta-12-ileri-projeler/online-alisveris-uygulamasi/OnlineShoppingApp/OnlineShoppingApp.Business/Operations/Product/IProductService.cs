using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Product
{
    public interface IProductService
    {
        Task<ServiceMessage<AddProductDto>> AddProductAsync(AddProductDto addProductDto);
        Task<List<ProductListDto>> GetAllAsync();
        Task<ServiceMessage> DeleteProductAsync(int id);

        Task<ServiceMessage> UpdateProductAsync(UpdateProductDto updateProductDto);

        Task<ServiceMessage> ApplyPartialUpdateAsync(PatchProductDto dto);
        Task<ServiceMessage<ProductListDto>> GetProductByIdAsync(int id);

    } // IProductService done  
}
