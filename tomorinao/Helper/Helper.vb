Imports System.Security.Claims

Public NotInheritable Class TwitterHelper

    Public Shared Function CreateTokens(claims As IEnumerable(Of Claim)) As CoreTweet.Tokens
        Dim accessTokenClaim = claims.FirstOrDefault(Function(x) x.Type = "urn:tokens:twitter:accesstoken")
        Dim accessTokenSecretClaim = claims.FirstOrDefault(Function(x) x.Type = "urn:tokens:twitter:accesstokensecret")
        If accessTokenClaim Is Nothing OrElse accessTokenSecretClaim Is Nothing Then
            Return Nothing
        End If
        Dim tokens = CoreTweet.Tokens.Create(ConfigurationManager.AppSettings("TwitterConsumerKey"), ConfigurationManager.AppSettings("TwitterConsumerSecret"), accessTokenClaim.Value, accessTokenSecretClaim.Value)
        Return tokens
    End Function

End Class