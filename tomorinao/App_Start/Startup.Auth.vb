Imports Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Twitter
Imports System.Security.Claims

Partial Public Class Startup

    Public Sub ConfigureAuth(app As IAppBuilder)
        Dim cookieOptions = New CookieAuthenticationOptions With {
            .LoginPath = New PathString("/Account/Login")}
        app.UseCookieAuthentication(cookieOptions)

        app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType)

        app.UseTwitterAuthentication(
            New TwitterAuthenticationOptions With {
                .ConsumerKey = ConfigurationManager.AppSettings("TwitterConsumerKey"),
                .ConsumerSecret = ConfigurationManager.AppSettings("TwitterConsumerSecret"),
                .Provider = New TwitterAuthenticationProvider With {
                    .OnAuthenticated = Async Function(context)
                                           context.Identity.AddClaim(New Claim("urn:tokens:twitter:accesstoken", context.AccessToken))
                                           context.Identity.AddClaim(New Claim("urn:tokens:twitter:accesstokensecret", context.AccessTokenSecret))
                                       End Function
                    }})

    End Sub
End Class
