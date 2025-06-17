using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuangKhai_2280601379_LTW.Models;

namespace TranQuangKhai_2280601379_LTW.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
