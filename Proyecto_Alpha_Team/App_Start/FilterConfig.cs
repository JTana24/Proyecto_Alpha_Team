using System.Web;
using System.Web.Mvc;

namespace Proyecto_Alpha_Team
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
