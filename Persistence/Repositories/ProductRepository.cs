using Application.Interfaces;
using DomainModel.Products;
using DomainModel.Products.Repositories;
using Infrastructure.Helpers.PaginationHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<bool> ExistsProductWithEmailOrProduceDate(string email, DateTime produceDate)
        {
            return await _context.Products.AnyAsync(c => c.ManufacturerEmail == email || produceDate == c.ProduceDate);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<List<Product>> GetAllWithPaginationAsync(PageQuery pageQuery)
        {
            return await _context.Products.AsNoTracking()
                .Sort(pageQuery)
                .ToFilters(pageQuery)
                .ToPaging(pageQuery)
                .ToListAsync();
        }
    }
}
