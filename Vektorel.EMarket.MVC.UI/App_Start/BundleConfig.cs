using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Vektorel.EMarket.MVC.UI.App_Start
{

    //System.Web.Optimization ns için nuggetten Microsoft.AspNet.Web.Optimization kurulması gerekli BunldeCollection sınıfı için - Author Microsoft 

    //Bu sınıf; dosyaları minimize etmek, ayrıca js ve css dosyları için kolaylıkla çağırma keyleri oluşturmamıza yarıyor.
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //.Include("~/Content/js/unobstrusive/jquery-1.8.0.min.js")
            //.Include("~/Content/js/unobstrusive/jquery.unobtrusive-ajax.min.js")
            //.Include("~/Content/js/unobstrusive/jquery-1.8.0.intellisense.js"));

            bundles.Add(new StyleBundle("~/style/index")
                .Include("~/Content/theme/themes/bootshop/bootstrap.min.css")
                .Include("~/Content/theme/themes/css/base.css")
                .Include("~/Content/theme/themes/css/bootstrap-responsive.min.css")
                .Include("~/Content/theme/themes/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Content/theme/themes/js/google-code-prettify/prettify.css")
                .Include("~/Content/css/alertify.min.css")
                
            );

            bundles.Add(new ScriptBundle("~/script/layout")
                .Include("~/Content/js/jquery-{version}.min.js")
                .Include("~/Content/theme/themes/js/bootstrap.min.js")
                .Include("~/Content/theme/themes/js/google-code-prettify/prettify.js")
                .Include("~/Content/theme/themes/js/bootshop.js")
                .Include("~/Content/theme/themes/js/jquery.lightbox-0.5.js")
                .Include("~/Content/js/jquery.validate.min.js")
                .Include("~/Content/js/jquery.validate.unobtrusive.min.js")
                .Include("~/Content/js/jquery.unobtrusive-ajax.min.js")
                .Include("~/Content/js/alertify.min.js")
                );

            BundleTable.EnableOptimizations = true;
        }
    }
}