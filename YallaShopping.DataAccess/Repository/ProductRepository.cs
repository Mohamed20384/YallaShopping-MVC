using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YallaShopping.DataAccess.Data;
using YallaShopping.DataAccess.Repository.IRepository;
using YallaShopping.Models;

namespace YallaShopping.DataAccess.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            _db.Products.Include(p => p.Category).Include(p => p.CategoryId);
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.ISBN = product.ISBN;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.Author = product.Author;
                objFromDb.ProductImages = product.ProductImages;
            }
        }

    }
}
