using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Category.Dtos
{
    public class CategoryWithProductsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;
        public List<ProductVm> Products { get; set; } = new();
    } // CategoryWithProductsDto class done

    public class ProductVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        
    } // ProductVm class done

}

