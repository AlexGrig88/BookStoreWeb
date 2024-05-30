using BookStoreWeb.Data;
using BookStoreWeb.Models;
using BookStoreWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Regex _nameRegex = new Regex(@"[^а-яА-Я ]+");
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!_nameRegex.IsMatch(category.Name)) {       // кастомная проверка входных данных
                ModelState.AddModelError("name", "Название категории должно содержать только русские буквы, цифры и пробелы");
            }
            if (!ModelState.IsValid) {
                return View();
            }
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue || id == 0) {
                return NotFound();
            }
            Category? category = _categoryService.FindById(id.Value);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!_nameRegex.IsMatch(category.Name)) {       // кастомная проверка входных данных
                ModelState.AddModelError("name", "Название категории должно содержать только русские буквы и пробелы");
            }
            if (!ModelState.IsValid) {
                return View();
            }
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue || id.Value == 0) {
                return NotFound();
            }
            Category? category = _categoryService.FindById(id.Value);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (!id.HasValue || id.Value == 0) {
                return NotFound();
            }
            var category = _categoryService.RemoveById(id.Value);
            if (category == null) { return NotFound(); }
            return RedirectToAction("Index");
        }
    }
}
