using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.AsNoTracking().ToList();
        }

		public Category? FindById(int id)
		{
			return _dbContext.Categories.FirstOrDefault(cat => cat.Id == id);  
		}

        internal void Update(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        internal void Remove(Category category)
        {
            _dbContext?.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        internal Category? RemoveById(int id)
        {
            Category? category = FindById(id);
            if (category == null) {
                return null;
            }
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
            return category;
        }
    }
}
