<!DOCTYPE html lang="ja">
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://appsforoffice.microsoft.com/fabric/1.0/fabric.min.css">
    <link rel="stylesheet" href="https://appsforoffice.microsoft.com/fabric/1.0/fabric.components.min.css">
    @Styles.Render("~/Content/css")
    @RenderSection("styles", required:=False)
</head>
<body>
    <main class="Container">
        <div class="Header ms-bgColor-themePrimary ms-borderColor-themePrimary">
            <div class="Header-text">
                <div class="u-contentCenter">
                    <h1 class="Header-title ms-font-xxl"><a href="@Href("~/")" class="ms-fontColor-white">友利奈緒 発見器</a></h1>
                    <h3 class="Header-subTitle ms-font-m-plus ms-fontColor-white">フォロワーから友利奈緒を探します</h3>
                </div>
            </div>
        </div>

        @RenderBody()

    </main>
    @Scripts.Render("~/bundles/jquery")
    @RenderSection("scripts", required:=False)
    <script type="text/javascript" src="js/jquery.fabric.min.js"></script>
</body>
</html>
