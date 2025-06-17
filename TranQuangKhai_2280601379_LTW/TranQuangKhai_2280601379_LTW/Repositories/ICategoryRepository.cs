using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuangKhai_2280601379_LTW.Models;

namespace TranQuangKhai_2280601379_LTW.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
