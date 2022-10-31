using Microsoft.AspNetCore.Mvc;

namespace TSLP_Website_Merge.Controllers
{
    public class MySellersController : Controller
    {
        public IActionResult SellersDashboard()
        {
            return View();
        }
    }
}
