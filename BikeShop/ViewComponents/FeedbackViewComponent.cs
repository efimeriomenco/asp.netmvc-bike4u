using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.ViewModel
{
    public class FeedbackViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FeedbackViewModel
            {
                selectList = new SelectList(new[] { "Moldova", "Romania" })
            };
            return View(model);
           
        }   
    }
}