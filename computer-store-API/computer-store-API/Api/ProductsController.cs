using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computer_store_API.Api
{
    public class ProductsController:EntityController<Product>
    {
        public IActionResult InsertFee(Product product)
        {
            return Insert(product);
        }

        public IActionResult UpdateFee(Product product, int id)
        {
            return Update(product, id);
        }
    }
}
