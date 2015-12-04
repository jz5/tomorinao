@ModelType Result
@Code
    Dim title = "フォロワーから" & Model.Users.Count.ToString & "人の友利奈緒を見つけました"
    ViewData("Title") = title
End Code

<div class="Content">
    <div class="u-contentCenter">
        <div class="Intro">
            <h2 class="Intro-title ms-font-m-plus">@title</h2>

            <h3 class="ms-font-m" style="margin-top:20px;">結果をツイートする</h3>

            <div style="margin-top:10px;">
                <a href="https://twitter.com/share" class="twitter-share-button" data-url="https://tmrn.azurewebsites.net" data-text="@title" data-via="jz5" data-size="large" data-lang="ja">ツイート</a>
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
            </div>
        </div>

        @For Each u In Model.Users
            @<div class="user-wrapper">
                <div class="ms-Persona ms-Persona ms-Persona--square ms-Persona--sm">
                    <div class="ms-Persona-imageArea">
                        <i class="ms-Persona-placeholder ms-Icon ms-Icon--person"></i>
                        <img class="ms-Persona-image" src="@u.ProfileImageUrl" />
                        @*<div class="ms-Persona-presence"></div>*@
                    </div>
                    <div class="ms-Persona-details">
                        <div class="ms-Persona-primaryText">@u.Name</div>
                        <div class="ms-Persona-secondaryText"><a href="https://twitter.com/@u.ScreenName" target="_blank" class="ms-Persona-secondaryText">@@@u.ScreenName</a></div>
                    </div>
                </div>
            </div>
        Next

        <div style="margin-top:20px;">
            @If Model.Errors.Count > 0 Then
                @<p class="ms-font-m">何かエラーが発生したので、結果が少ないかもしれません。</p>
            End If
        </div>

    </div>
</div>
