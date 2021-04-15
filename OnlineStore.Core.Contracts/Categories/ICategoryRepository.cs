using OnlineStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Contracts.Categories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
