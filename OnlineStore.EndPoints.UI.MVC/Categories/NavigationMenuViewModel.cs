using OnlineStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.EndPoints.UI.MVC.Categories
{
    public class NavigationMenuViewModel
    {
        public List<Category> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}
