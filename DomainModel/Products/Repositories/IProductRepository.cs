using Infrastructure.Helpers.PaginationHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Products.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);

        Task<bool> ExistsProductWithEmailOrProduceDate(string email , DateTime produceDate);

        Task<Product> GetByIdAsync(Guid id);

        void Remove(Product product);

        Task<List<Product>> GetAllWithPaginationAsync(PageQuery pageQuery);

        Task<int> CountAsync();
    }
}
