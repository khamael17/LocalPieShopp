namespace BethanysPieShop.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;
        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            this._bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        IEnumerable<Category> ICategoryRepository.AllCategories => _bethanysPieShopDbContext.Categories.OrderBy(p=> p.CategoryName);
    }
}
