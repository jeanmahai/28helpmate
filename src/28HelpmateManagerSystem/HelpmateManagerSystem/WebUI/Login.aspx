<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="/res/css/modern.css" />
    <link href="/res/css/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/res/js/jquery-1.9.1.min.js"></script>
    <script src="/res/js/jposition.js" type="text/javascript"></script>
</head>
<body class="metrouicss">
    <form id="frmLogin" runat="server">
    <div class="span5 border bg-color-white  pd10 zi1001" data-id="login">
        <h2>
            用户登录</h2>
        <div class="input-control text">
            <input runat="server" id="UserId" type="text" placeholder="请输入用户名" />
            <button type="button" tabindex="-1" class="btn-clear" />
        </div>
        <div class="input-control password">
            <input runat="server" id="Password" type="password" placeholder="请输入密码" />
            <button type="button" tabindex="-1" class="btn-reveal" />
        </div>
        <button class="image-button bg-color-darken fg-color-white" id="btnOK" runat="server">
            登录<img src="/res/img/old_edit_redo.png" />
        </button>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("[data-id=login]").jposition();
        });
    </script>
</body>
</html>
