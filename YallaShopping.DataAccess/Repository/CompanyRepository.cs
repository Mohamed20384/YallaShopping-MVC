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
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var existingEntity = _db.Companies.Local.FirstOrDefault(c => c.Id == company.Id);
            if (existingEntity != null)
            {
                _db.Entry(existingEntity).State = EntityState.Detached;
            }
            _db.Companies.Update(company);
        }
    }
}
