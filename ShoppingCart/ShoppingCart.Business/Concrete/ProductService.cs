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

        public void Add(Product product)
        {
            _productDAL.Add(product);
        }

        public void Delete(Product product)
        {
            _productDAL.Delete(product);
        }

        public Product Get(int productId)
        {
            return _productDAL.Get(x => x.ProductId == productId);
        }

        public ICollection<Product> GetList(int categoryID)
        {
            return categoryID ==0 
                ?_productDAL.GetList()
                :_productDAL.GetList(x => x.CategoryId == categoryID);
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }
    }
}
