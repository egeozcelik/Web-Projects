﻿using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface ICategoryService : IServiceBase
    {
        List<CategoryDTO> getAll();
        CategoryDTO getCategory(int categoryId);
        List<CategoryDTO> getCategoryNameList(string categoryName);
        CategoryDTO newCategory(CategoryDTO category);
        CategoryDTO updateCategory(CategoryDTO category);
        bool deleteCategory(int categoryId);
    }
}
