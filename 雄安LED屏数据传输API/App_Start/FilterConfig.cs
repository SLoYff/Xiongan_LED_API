using System.Web;
using System.Web.Mvc;

namespace 雄安LED屏数据传输API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
