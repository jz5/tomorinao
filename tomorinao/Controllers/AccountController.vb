Imports Microsoft.Owin.Security

<RequireHttps>
<Authorize>
Public Class AccountController
    Inherits Controller

    Private Function AuthenticationManager() As IAuthenticationManager
        Return HttpContext.GetOwinContext().Authentication
    End Function

    <AllowAnonymous>
    Function Login(returnUrl As String) As ActionResult
        Return New ChallengeResult("Twitter", Url.Action("ExternalLoginCallback", "Account", New With {.ReturnUrl = returnUrl}))
    End Function

    <AllowAnonymous>
    Function ExternalLoginCallback(returnUrl As String) As ActionResult
        Dim claims = AuthenticationManager.User.Claims

        If returnUrl Is Nothing Then
            returnUrl = "/Search"
        End If

        Return New RedirectResult(returnUrl.Replace("#", "%23"))
    End Function

    '
    ' POST: /Account/LogOff
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LogOff() As ActionResult
        AuthenticationManager.SignOut()
        Session.RemoveAll()
        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/ExternalLoginFailure
    <AllowAnonymous>
    Public Function ExternalLoginFailure() As ActionResult
        Return View()
    End Function

    Private Class ChallengeResult
        Inherits HttpUnauthorizedResult
        Public Sub New(provider As String, redirectUri As String)
            Me.LoginProvider = provider
            Me.RedirectUri = redirectUri
        End Sub


        Public Property LoginProvider As String
        Public Property RedirectUri As String

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            Dim properties = New AuthenticationProperties() With {.RedirectUri = RedirectUri}
            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider)
        End Sub
    End Class
End Class
