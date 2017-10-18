using ShoppingCart.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Entities.Concrete;
using ShoppingCart.DataAccess.Abstract;

namespace ShoppingCart.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public ICollection<Product> GetList(int categoryID)
        {
            return categoryID ==0 
                ?_productDAL.GetList()
                :_productDAL.GetList(x => x.CategoryId == categoryID);
        }
    }
}
