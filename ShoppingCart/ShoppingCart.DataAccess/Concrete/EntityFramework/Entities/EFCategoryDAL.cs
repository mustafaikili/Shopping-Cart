using ShoppingCart.Core.DataAccess.EntityFramework;
using ShoppingCart.DataAccess.Abstract;
using ShoppingCart.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DataAccess.Concrete.EntityFramework.Entities
{
    public class EFCategoryDAL : EFEntityRepositoryBase<Category, ShoppingCartDbContext>, ICategoryDAL
    {
    }
}
