﻿using BloggerSample.BLL.Abstract;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggerSample.BLL.BlogService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork uow;
        public CategoryService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteCategory(int categoryId)
        {
            try
            {
                var delete = uow.GetRepository<Category>().Get(z => z.Id == categoryId);
                uow.GetRepository<Category>().Delete(delete);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public List<CategoryDTO> getAll()
        {
            var categoryList = uow.GetRepository<Category>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CategoryDTO>>(categoryList);
        }

        public CategoryDTO getCategory(int Id)
        {
            var category = uow.GetRepository<Category>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(category);
        }

        public List<CategoryDTO> getCategoryNameList(string CategoryName)
        {
            var name = uow.GetRepository<Category>().Get(z => z.Name.Contains(CategoryName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<CategoryDTO>>(name);

        }

        public CategoryDTO newCategory(CategoryDTO category)
        {
            if (!uow.GetRepository<Category>().GetAll().Any(z => z.Name.ToLower() == category.Name.ToLower()))
            {
                var added = MapperFactory.CurrentMapper.Map<Category>(category);
                added = uow.GetRepository<Category>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CategoryDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public CategoryDTO updateCategory(CategoryDTO category)
        {
            var update = uow.GetRepository<Category>().Get(z => z.Id == category.Id);
            update = MapperFactory.CurrentMapper.Map<Category>(category);
            uow.GetRepository<Category>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(update);
        }
    }
}
