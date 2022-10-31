using Microsoft.AspNetCore.Mvc;

namespace TSLP_Website_Merge.Controllers
{
    public class MyCommunityController : Controller
    {
        public IActionResult CommunityDashboard()
        {
            return View();
        }
    }
}
