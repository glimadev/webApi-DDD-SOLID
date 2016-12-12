using System.Web.Optimization;

namespace Api.Architecture.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/Jquery").Include(
                      "~/bower_components/jquery/dist/jquery.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/FastClick").Include(
                      "~/bower_components/fastclick/lib/fastclick.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                               "~/bower_components/angular/angular.min.js",
                               "~/bower_components/angular/angular-locale_pt-br.js",
                               "~/bower_components/angular-cookies/angular-cookies.min.js",
                               "~/bower_components/angular-animate/angular-animate.min.js",
                               "~/bower_components/angular-touch/angular-touch.min.js",
                               "~/bower_components/angular-sanitize/angular-sanitize.min.js",
                               "~/bower_components/angular-ui-router/release/angular-ui-router.min.js",
                               "~/bower_components/ngstorage/ngStorage.min.js",
                               "~/bower_components/angular-translate/angular-translate.min.js",
                               "~/bower_components/angular-translate-loader-url/angular-translate-loader-url.min.js",
                               "~/bower_components/angular-translate-loader-static-files/angular-translate-loader-static-files.min.js",
                               "~/bower_components/angular-translate-storage-local/angular-translate-storage-local.min.js",
                               "~/bower_components/angular-translate-storage-cookie/angular-translate-storage-cookie.min.js",
                               "~/bower_components/oclazyload/dist/ocLazyLoad.min.js",
                               "~/bower_components/angular-breadcrumb/dist/angular-breadcrumb.min.js",
                               "~/bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js",
                               "~/bower_components/angular-loading-bar/build/loading-bar.min.js",
                               "~/bower_components/angular-scroll/angular-scroll.min.js",
                               "~/bower_components/angular-filters/angular-filter.min.js"
                               ));
            bundles.Add(new ScriptBundle("~/bundles/AuthModule").Include(
                                //"http://ajax.googleapis.com/ajax/libs/angularjs/1.2.17/angular-route.min.js",
                                "~/Areas/Application/js/vitali.js",
                                "~/Areas/Application/js/modules/core/module.core.js",
                                "~/Areas/Application/js/modules/auth/module.auth.js",
                                "~/Areas/Application/js/modules/auth/module.auth.routes.js",
                                "~/Areas/Application/js/modules/admin/module.admin.js",
                                "~/Areas/Application/js/modules/admin/module.admin.routes.js",
                                "~/Areas/Application/js/modules/pages/module.pages.js",
                                "~/Areas/Application/js/modules/pages/module.pages.routes.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/ClipTwoScripts").Include(
                                "~/Areas/Application/js/app.js",
                                "~/Areas/Application/js/main.js",
                                "~/Areas/Application/js/config.constant.js",
                                "~/Areas/Application/js/config.router.js",
                                "~/Areas/Application/js/services/eventbusService.js",
                                "~/Areas/Application/js/services/urlService.js",
                                "~/Areas/Application/js/services/userLoggedService.js",
                                "~/Areas/Application/js/services/authenticationService.js",
                                "~/Areas/Application/js/services/authorizationService.js",
                                "~/Areas/Application/js/directives/access.js",
                                "~/Areas/Application/js/directives/loading.js",
                                "~/Areas/Application/js/modules/auth/module.auth.run.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/ClipTwoDirectives").Include(
                                "~/Areas/Application/js/directives/toggle.js",
                                "~/Areas/Application/js/directives/perfect-scrollbar.js",
                                "~/Areas/Application/js/directives/empty-links.js",
                                "~/Areas/Application/js/directives/sidebars.js",
                                "~/Areas/Application/js/directives/off-click.js",
                                "~/Areas/Application/js/directives/full-height.js",
                                "~/Areas/Application/js/directives/panel-tools.js",
                                "~/Areas/Application/js/directives/char-limit.js",
                                "~/Areas/Application/js/directives/dismiss.js",
                                "~/Areas/Application/js/directives/compare-to.js",
                                "~/Areas/Application/js/directives/select.js",
                                "~/Areas/Application/js/directives/messages.js",
                                "~/Areas/Application/js/directives/chat.js",
                                "~/Areas/Application/js/directives/sparkline.js",
                                "~/Areas/Application/js/directives/touchspin.js",
                                "~/Areas/Application/js/directives/file-upload.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/ClipTwoControllers").Include(
                                //"~/Areas/Application/js/controllers/events/eventCtrl.js",
                                "~/Areas/Application/js/controllers/mainCtrl.js",
                                "~/Areas/Application/js/controllers/bootstrapCtrl.js"
                                //"~/Areas/Application/js/controllers/helpMessages/helpsMessagesCtrl.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/GoogleApis").Include(

                                //"http://maps.googleapis.com/maps/api/js?v=3.exp&libraries=weather,visualization",
                                "~/Areas/Application/js/services/apiService.js",
                                "~/Areas/Application/js/services/alertService.js"

            ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/GoogleFonts").Include(
                //"http://fonts.googleapis.com/css?family=Lato:300,400,400italic,600,700|Raleway:300,400,500,600,700|Crete+Round:400italic"
                ));

            bundles.Add(new StyleBundle("~/Content/BootstrapCliptwo").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css"
                ));
            bundles.Add(new StyleBundle("~/Content/FontAwesome").Include(
                "~/bower_components/font-awesome/css/font-awesome.min.css"
                ));
            bundles.Add(new StyleBundle("~/Content/ThemifyIcons").Include(
                "~/bower_components/themify-icons/themify-icons.css"
            ));
            bundles.Add(new StyleBundle("~/Content/LoadingBar").Include(
                "~/bower_components/angular-loading-bar/build/loading-bar.min.css"
            ));
            bundles.Add(new StyleBundle("~/Content/AnimateCss").Include(
                "~/bower_components/animate.css/animate.min.css"
            ));
            bundles.Add(new StyleBundle("~/Content/ClipTwo").Include(
                    "~/Areas/Application/css/styles.css",
                    "~/Areas/Application/css/plugins.css",
                    "~/Areas/Application/css/themes/{{ app.layout.theme }}.css"
            ));*/

        }
    }
}
