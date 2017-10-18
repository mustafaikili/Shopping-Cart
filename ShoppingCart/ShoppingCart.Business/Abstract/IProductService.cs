using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Abstract
{
    public interface IProductService
    {
        ICollection<Product> GetList(int categoryID);
    }
}
