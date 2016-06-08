using System.Web;
using System.Web.Mvc;

namespace MyWebHzg.Frontend.HzgWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
