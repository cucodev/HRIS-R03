using System.Web;
using System.Web.Optimization;

namespace HRIS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include());

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include());

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css", 
                "~/Content/site.css"));



            //==========================================================================================START ACE

            bundles.Add(new StyleBundle("~/Content/ACEStyle").Include(
                "~/Content/assets/css/bootstrap.min.css",
                "~/Content/assets/font-awesome/4.5.0/css/font-awesome.min.css",
                "~/Content/assets/css/fonts.googleapis.com.css",
                "~/Content/assets/css/ace.min.css",
                "~/Content/assets/css/ace-skins.min.css",
                "~/Content/assets/css/ace-rtl.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ACEJSonTOP").Include(
                                  "~/Content/assets/js/ace-extra.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ACEJSonBOTTOM").Include(
                                  "~/Content/assets/js/bootstrap.min.js",
                                  "~/Content/assets/js/ace-elements.min.js",
                                  "~/Content/assets/js/ace.min.js"
                                  ));

            bundles.Add(new ScriptBundle("~/bundles/ACEJQuery").Include(
                                              "~/Content/assets/js/jquery-2.1.4.min.js",
                                              "~/Content/assets/js/jquery-ui.custom.min.js",
                                              "~/Content/assets/js/jquery.ui.touch-punch.min.js"
                                              ));



            //==========================================================================================END ACE


            //==========================================================================================CUSTOM css
            #region CUSTOMCSS
            bundles.Add(new StyleBundle("~/Content/Sidebar").Include(
                "~/Content/Sidebar/sidebar-menu.css",
                "~/Content/Sidebar/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Content/LoginStyle").Include("~/Content/LoginStyle.css"));
            bundles.Add(new StyleBundle("~/Content/jsmenu").Include(
                     "~/Content/jsmenu/reset.css",
                     "~/Content/jsmenu/style.css"));
            bundles.Add(new StyleBundle("~/Content/jqx").Include(
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
            #endregion

            //==========================================================================================CUSTOM js
            #region CUSTOMJS
            bundles.Add(new ScriptBundle("~/bundles/Sidebar").Include(
                                  "~/Scripts/Sidebar/sidebar-menu.js"));
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
                        "~/Scripts/jqwidgets/jqxgrid.columnsreorder.js",
                        "~/Scripts/jqwidgets/jqxgrid.columnsresize.js", 
                        "~/Scripts/jqwidgets/jqxlistbox.js",
                        "~/Scripts/jqwidgets/jqxbuttons.js",
                        "~/Scripts/jqwidgets/jqxbuttongroup.js",
                        "~/Scripts/jqwidgets/jqxSwitchButton.js",
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
                        "~/Scripts/jqwidgets/jqxprogressbar.js",
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
                        "~/Scripts/jqwidgets/jqxpopover.js",
                        "~/Scripts/jqwidgets/jqxtextarea.js",
                        "~/Scripts/jqwidgets/jqxexpander.js",
                        "~/Scripts/jqwidgets/jqxcombobox.js"
                        ));
            #endregion


        }
    }
}
