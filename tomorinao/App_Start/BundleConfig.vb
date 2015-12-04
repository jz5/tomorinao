Imports System.Web.Optimization

Public Module BundleConfig
    ' バンドルの詳細については、http://go.microsoft.com/fwlink/?LinkId=301862 を参照してください
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.fabric.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
        ' できたら、http://modernizr.com にあるビルド ツールを使用して、必要なテストのみを選択します。
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/site.css"))
    End Sub
End Module

