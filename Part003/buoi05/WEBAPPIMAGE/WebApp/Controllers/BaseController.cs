using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        SiteProvider _siteProvider = null!;
        
        protected SiteProvider Provider
        {
            get
            {
                if (_siteProvider == null)
                {
                    _siteProvider = new SiteProvider(HttpContext.RequestServices.GetService<StoreContext>()!);
                }
                return _siteProvider;
            }
        }
    }
}
