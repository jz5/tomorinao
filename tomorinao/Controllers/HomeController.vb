Imports System.Threading.Tasks
Imports CoreTweet
Imports Microsoft.Owin.Security

<RequireHttps>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private Function AuthenticationManager() As IAuthenticationManager
        Return HttpContext.GetOwinContext().Authentication
    End Function

    <HttpGet>
    Function Index() As ActionResult
        Return View()
    End Function

    <Authorize>
    <HttpGet>
    Function Search() As ActionResult

        Dim tokens As Core.TokensBase
        tokens = TwitterHelper.CreateTokens(AuthenticationManager.User.Claims)

        Dim followerIds = New List(Of Long)
        Dim result = New Result

        ' API GET followers/ids (5000人までフォロワーの ID を取得)
        Dim screenName = AuthenticationManager.User.Identity.Name
        Dim cursor As Long = -1
        Do
            Try
                Dim idsResult = tokens.Followers.Ids(New Dictionary(Of String, Object) From {
                                       {"screen_name", screenName},
                                       {"cursor", cursor}})

                followerIds.AddRange(idsResult)
                cursor = idsResult.NextCursor

                If idsResult.RateLimit.Remaining = 0 Then
                    Exit Do
                End If

            Catch ex As Exception
                result.Errors.AddRange(CreateErrorItems(ex))
                Exit Do
            End Try
        Loop While cursor > 0

        If followerIds.Count = 0 Then
            Return View(result)
        End If

        Dim sync = New Object

        Parallel.For(0, Convert.ToInt32(Math.Floor(followerIds.Count / 100)),
            Sub(i)
                Dim ids = followerIds.Skip(i * 100).Take(100)

                Try
                    ' API GET users/lookup (100人ごとにユーザー情報を取得)
                    Dim lookupResult = tokens.Users.Lookup(New Dictionary(Of String, Object) From {
                                                            {"user_id", ids}})

                    For Each u In lookupResult
                        If u.Name.Contains("友利") AndAlso u.Name.Contains("奈緒") Then ' 友利奈緒を探す
                            SyncLock sync
                                result.Users.Add(u)
                            End SyncLock
                        End If
                    Next
                Catch ex As Exception
                    result.Errors.AddRange(CreateErrorItems(ex))
                End Try
            End Sub)

        Return View(result)
    End Function

    Private Function CreateErrorItems(ex As Exception) As IEnumerable(Of ErrorItem)
        Dim errors = New List(Of ErrorItem)

        If TypeOf ex Is TwitterException Then
            For Each e In DirectCast(ex, TwitterException).Errors
                errors.Add(New ErrorItem With {.Code = e.Code, .Message = e.Message})
            Next
        Else
            errors.Add(New ErrorItem With {.Message = ex.Message})
        End If

        Return errors
    End Function

End Class

Public Class ErrorItem
    Property Code As Integer ' For TwitterException
    Property Message As String
End Class

Public Class Result
    Property Users As New List(Of User)
    Property Errors As New List(Of ErrorItem)
End Class
