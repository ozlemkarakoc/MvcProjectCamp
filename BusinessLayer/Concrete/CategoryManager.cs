using BusinessLayer.Abstract;
using DataAccessLayerr.Abstract;
using DataAccessLayerr.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICatagoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {
        //        //Hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {
        //        //Hata mesajı
        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}
    }
}
