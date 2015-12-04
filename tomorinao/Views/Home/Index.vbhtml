@Code
    ViewData("Title") = "友利奈緒 発見器"
End Code

<div class="Content">
    <div class="u-contentCenter">
        <div class="Intro">
            <div>
                @*<a href="http://www.amazon.co.jp/Charlotte-1-%E9%9B%BB%E6%92%83%E3%82%B3%E3%83%9F%E3%83%83%E3%82%AF%E3%82%B9NEXT-%E6%B1%A0%E6%BE%A4%E7%9C%9F/dp/4048654276%3FSubscriptionId%3DAKIAI4AHPHXXKLQMLSAQ%26tag%3Dks04-22%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3D4048654276" target="_blank"><img src="http://ecx.images-amazon.com/images/I/51jT86RjbRL._SX360_.jpg" title="Charlotte (1) (電撃コミックスNEXT)" /></a>*@
                <a href="http://www.amazon.co.jp/%E3%82%AD%E3%83%A3%E3%83%A9%E3%82%A2%E3%83%8B-Charlotte-%E3%83%87%E3%82%B9%E3%82%AF%E3%83%9E%E3%83%83%E3%83%88/dp/B014K8NTWI%3FSubscriptionId%3DAKIAI4AHPHXXKLQMLSAQ%26tag%3Dks04-22%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3DB014K8NTWI"><img src="http://ecx.images-amazon.com/images/I/51yNRanmK3L._SX360_.jpg" title="Charlotte デスクマット" /></a>

            </div>
            <div style="margin-top:20px;">
                <a href="https://twitter.com/share" class="twitter-share-button" data-url="https://tmrn.azurewebsites.net" data-via="jz5" data-size="large" data-lang="ja">ツイート</a>
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
            </div>
        </div>
        @Using Html.BeginForm("Search", "Home", FormMethod.Get, New With {.role = "form", .class = "Form"})
            @<text>

                @*<div class="ms-TextField">
                        <Label class="ms-Label">検索キーワード</Label>
                        <input class="ms-TextField-field" type="text" name="keywords" value="友利奈緒" />
                    </div>

                    <div class="ms-ChoiceFieldGroup">
                        <Label class="ms-Label">検索対象</Label>

                        <div class="ms-ChoiceField">
                            <input id="demo-checkbox-selected" class="ms-ChoiceField-input" type="checkbox" checked />
                            <Label for="demo-checkbox-selected" class="ms-ChoiceField-field"><span class="ms-Label">フレンド</span></Label>
                        </div>

                        <div class="ms-ChoiceField">
                            <input id="demo-checkbox-unselected" class="ms-ChoiceField-input" type="checkbox" />
                            <Label for="demo-checkbox-unselected" class="ms-ChoiceField-field"><span class="ms-Label">フォロワー</span></Label>
                        </div>
                    </div>

                    <div class="ms-ChoiceFieldGroup">
                        <Label class="ms-Label">プロフィール</Label>

                        <div class="ms-ChoiceField">
                            <input id="demo-checkbox-selected" class="ms-ChoiceField-input" type="checkbox" checked />
                            <Label for="demo-checkbox-selected" class="ms-ChoiceField-field"><span class="ms-Label">名前</span></Label>
                        </div>

                        <div class="ms-ChoiceField">
                            <input id="demo-checkbox-unselected" class="ms-ChoiceField-input" type="checkbox" />
                            <Label for="demo-checkbox-unselected" class="ms-ChoiceField-field"><span class="ms-Label">自己紹介</span></Label>
                        </div>
                    </div>*@

                <div class="SubmitButton">
                    <button type="submit" class="ms-Button ms-Button--primary"><span class="ms-Button-label">Twitter にサインインして探す</span></button>
                </div>
            </text>
        End Using

        <div>
            <p><a class="ms-font-s" href="http://pronama.azurewebsites.net/2015/09/03/search-tomori-nao-web-service/">このページについて</a></p>
        </div>
    </div>
</div>
