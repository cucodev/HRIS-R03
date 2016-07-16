using System.Web;
using System.Web.Optimization;

namespace HRIS_R03
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          // "~/Scripts/jquery-1.11.3.js"));
                          "~/Scripts/jquery-1.11.3.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //==========================================================================================CUSTOM js
            bundles.Add(new ScriptBundle("~/bundles/jsmenu").Include(
                                  "~/Scripts/jsmenu/jquery.menu-aim.js",
                                  "~/Scripts/jsmenu/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/jstorage").Include("~/Scripts/jstorage.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include(
                        "~/Scripts/jqwidgets/jqxcore.js",
                        "~/Scripts/jqwidgets/jqxdata.js",
                        "~/Scripts/jqwidgets/jqxdata.export.js",
                        "~/Scripts/jqwidgets/jqxdate.js",
                        "~/Scripts/jqwidgets/jqxscheduler.js",
                        "~/Scripts/jqwidgets/jqxscheduler.api.js",
                        "~/Scripts/jqwidgets/jqxwindow.js",
                        "~/Scripts/jqwidgets/jqxgrid.js",
                        "~/Scripts/jqwidgets/jqxgrid.edit.js",
                        "~/Scripts/jqwidgets/jqxgrid.selection.js",
                        "~/Scripts/jqwidgets/jqxgrid.pager.js",
                        "~/Scripts/jqwidgets/jqxlistbox.js",
                        "~/Scripts/jqwidgets/jqxbuttons.js",
                        "~/Scripts/jqwidgets/jqxscrollbar.js",
                        "~/Scripts/jqwidgets/jqxdatatable.js",
                        "~/Scripts/jqwidgets/jqxtreegrid.js",
                        "~/Scripts/jqwidgets/jqxmenu.js",
                        "~/Scripts/jqwidgets/jqxcalendar.js",
                        "~/Scripts/jqwidgets/jqxgrid.sort.js",
                        "~/Scripts/jqwidgets/jqxgrid.export.js",
                        "~/Scripts/jqwidgets/jqxgrid.filter.js",
                        "~/Scripts/jqwidgets/jqxgrid.grouping.js",
                        "~/Scripts/jqwidgets/jqxdatetimeinput.js",
                        "~/Scripts/jqwidgets/jqxdropdownlist.js",
                        "~/Scripts/jqwidgets/jqxdropdownbutton.js",
                        "~/Scripts/jqwidgets/jqxslider.js",
                        "~/Scripts/jqwidgets/jqxfileupload.js",
                        "~/Scripts/jqwidgets/jqxsplitter.js",
                        "~/Scripts/jqwidgets/jqxeditor.js",
                        "~/Scripts/jqwidgets/jqxinput.js",
                        "~/Scripts/jqwidgets/jqxdraw.js",
                        "~/Scripts/jqwidgets/jqxtabs.js",
                        "~/Scripts/jqwidgets/jqxchart.core.js",
                        "~/Scripts/jqwidgets/jqxchart.rangeselector.js",
                        "~/Scripts/jqwidgets/jqxtree.js",
                        "~/Scripts/jqwidgets/globalize.js",
                        "~/Scripts/jqwidgets/jqxbulletchart.js",
                        "~/Scripts/jqwidgets/jqxcheckbox.js",
                        "~/Scripts/jqwidgets/jqxradiobutton.js",
                        "~/Scripts/jqwidgets/jqxvalidator.js",
                        "~/Scripts/jqwidgets/jqxpanel.js",
                        "~/Scripts/jqwidgets/jqxtooltip.js",
                        "~/Scripts/jqwidgets/jqxlayout.js",
                        "~/Scripts/jqwidgets/jqxribbon.js",
                        "~/Scripts/jqwidgets/jqxpasswordinput.js",
                        "~/Scripts/jqwidgets/jqxnumberinput.js",
                        "~/Scripts/jqwidgets/jqxtextarea.js",
                        "~/Scripts/jqwidgets/jqxcombobox.js"
                        ));

            //==========================================================================================CUSTOM css
            bundles.Add(new StyleBundle("~/Content/LoginStyle").Include("~/Content/LoginStyle.css"));
            bundles.Add(new StyleBundle("~/Content/jsmenu").Include(
                     "~/Content/jsmenu/reset.css",
                     "~/Content/jsmenu/style.css"));
            bundles.Add(new StyleBundle("~/Content/jqwidgets").Include(
                    "~/Content/jqwidgets/jqx.base.css",
                    "~/Content/jqwidgets/jqx.arctic.css",
                    "~/Content/jqwidgets/jqx.black.css",
                    "~/Content/jqwidgets/jqx.bootstrap.css",
                    "~/Content/jqwidgets/jqx.classic.css",
                    "~/Content/jqwidgets/jqx.darkblue.css",
                    "~/Content/jqwidgets/jqx.energyblue.css",
                    "~/Content/jqwidgets/jqx.fresh.css",
                    "~/Content/jqwidgets/jqx.highcontrast.css",
                    "~/Content/jqwidgets/jqx.metro.css",
                    "~/Content/jqwidgets/jqx.metrodark.css",
                    "~/Content/jqwidgets/jqx.office.css",
                    "~/Content/jqwidgets/jqx.orange.css",
                    "~/Content/jqwidgets/jqx.shinyblack.css",
                    "~/Content/jqwidgets/jqx.summer.css",
                    "~/Content/jqwidgets/jqx.web.css",
                    "~/Content/jqwidgets/jqx.ui-darkness.css",
                    "~/Content/jqwidgets/jqx.ui-lightness.css",
                    "~/Content/jqwidgets/jqx.ui-le-frog.css",
                    "~/Content/jqwidgets/jqx.ui-overcast.css",
                    "~/Content/jqwidgets/jqx.ui-redmond.css",
                    "~/Content/jqwidgets/jqx.ui-smoothness.css",
                    "~/Content/jqwidgets/jqx.ui-start.css",
                    "~/Content/jqwidgets/jqx.ui-sunny.css"));


        }
    }
}
