using System.Web;
using System.Web.Mvc;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
