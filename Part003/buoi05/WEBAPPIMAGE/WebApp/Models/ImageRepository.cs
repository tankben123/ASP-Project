using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ImageRepository
    {
        private readonly StoreContext _context;
        public ImageRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Image?> GetImageByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public List<Image> GetImages()
        {
            return _context.Images.ToList();
        }
        public async Task<int> Add(Image image)
        {
            _context.Images.Add(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Add(List<Image> image)
        {
            _context.Images.AddRange(image);
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateImageAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var image = await GetImageByIdAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                return await _context.SaveChangesAsync();
            }
            return -1;
        }
    }
}
