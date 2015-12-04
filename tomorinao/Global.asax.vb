Imports System.Web.Optimization
Imports System.Web.Helpers
Imports System.Security.Claims

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name
    End Sub
End Class
