using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyWebHzg.Frontend.HzgWeb.Helpers
{
    internal class AsIsbundleOrderer : IBundleOrderer
    {
        public virtual IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }

    internal static class BundleExtensions
    {
        public static Bundle ForceOrdered(this Bundle sb)
        {
            sb.Orderer = new AsIsbundleOrderer();
            return sb;
        }
    }
}