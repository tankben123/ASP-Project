namespace WebApp.Models
{
    public class CategoryRepository
    {
        StoreContext context;
        public CategoryRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Category?> GetCategoryByIdAsync(byte id)
        {
            return await context.Categories.FindAsync(id);
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public async Task<int> Add(Category category)
        {
            context.Categories.Add(category);
            return await context.SaveChangesAsync();
        }
        public async Task<int> Add(List<Category> categories)
        {
            context.Categories.AddRange(categories);
            return await context.SaveChangesAsync();
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }
        public async Task<int> Delete(byte id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                return await context.SaveChangesAsync();
            }
            return -1;
        }

        public List<Category> Search(byte from, byte to)
        {
            return context.Categories.Where(c => c.Id >= from && c.Id <= to).ToList();
        }
    }
}
