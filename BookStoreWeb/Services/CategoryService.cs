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
	}
}
