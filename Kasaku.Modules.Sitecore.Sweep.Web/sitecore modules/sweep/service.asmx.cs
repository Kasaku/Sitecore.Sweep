using System.Web.Script.Services;
using System.Web.Services;

namespace Kasaku.Sitecore.Modules.Sweep.Web.sitecore_modules.sweep
{
    [ScriptService]
    public class ScriptService : WebService
    {
        [WebMethod]
        public string Clean(string input)
        {
            return SweepClean.Run(input);
        }
    }
}
