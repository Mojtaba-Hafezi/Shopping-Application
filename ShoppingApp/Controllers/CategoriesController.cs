﻿using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories= CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.ActionName = "edit";
            ViewBag.SubmitButtonName = "Save";
            Category? category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.ActionName = "add";
            ViewBag.SubmitButtonName = "Submit";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            return View(category);
        }

        
        public IActionResult Delete(int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof (Index));
        }
    }
}
