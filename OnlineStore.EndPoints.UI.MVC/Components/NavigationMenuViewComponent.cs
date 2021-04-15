using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Contracts.Categories;
using OnlineStore.EndPoints.UI.MVC.Categories;

namespace OnlineStore.Infrastructure.DAL.EF.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public NavigationMenuViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new NavigationMenuViewModel
            {
                Categories = _categoryRepository.GetAll(),
            };
            if (RouteData?.Values.ContainsKey("category") == true)
            {
                model.CurrentCategory = RouteData.Values["category"].ToString();
            }
            return View(model);
        }
    }
}
