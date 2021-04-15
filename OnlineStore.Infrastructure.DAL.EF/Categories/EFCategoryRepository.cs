using OnlineStore.Core.Contracts.Categories;
using OnlineStore.Core.Domain.Categories;
using OnlineStore.Infrastructure.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.DAL.EF.Categories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly OnlineStoreContext _OnlineStoreContext;
        public EFCategoryRepository(OnlineStoreContext onlineStoreContext)
        {
            _OnlineStoreContext = onlineStoreContext;
        }

        public List<Category> GetAll()
        {
            return _OnlineStoreContext.Categories.ToList();
        }
    }
}
