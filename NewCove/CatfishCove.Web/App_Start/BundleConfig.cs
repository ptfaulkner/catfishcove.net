using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CatfishCove.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var lessBundle = new LessBundle("~/bundles/semantic-ui").Include(
                "~/less/basic.icon.less",
                "~/less/button.less",
                "~/less/divider.less",
                "~/less/form.less",
                "~/less/grid.less",
                "~/less/header.less",
                "~/less/icon.less",
                "~/less/input.less",
                "~/less/item.less",
                "~/less/list.less",
                "~/less/menu.less",
                "~/less/message.less",
                "~/less/segment.less",
                "~/less/table.less",
                "~/less/dropdown.less"
                );

            lessBundle.Transforms.Add(new LessTransform());
            lessBundle.Transforms.Add(new CssMinify());

            bundles.Add(lessBundle);


                BundleTable.EnableOptimizations = true;
            
        }
    }
}