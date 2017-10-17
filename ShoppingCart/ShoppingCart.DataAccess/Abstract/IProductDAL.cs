using ShoppingCart.Core.DataAccess;
using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {
    }
}
