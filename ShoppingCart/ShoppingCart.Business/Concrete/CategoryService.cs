using ShoppingCart.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Entities.Concrete;
using ShoppingCart.DataAccess.Abstract;

namespace ShoppingCart.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public List<Category> GetAll()
        {
            return _categoryDAL.GetList();
        }
    }
}
