﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPager.ascx.cs" Inherits="WebUI.UserControls.UCPager" %>
<div class="span12">
    <a class="button bg-color-greenLight" href="<%=FirstPage %>">
        首页</a>
    <a class="button bg-color-pinkDark fg-color-blueLight" href="<%=PrevPage %>">
        上一页</a>
    <a class="button bg-color-pinkDark fg-color-blueLight" href="<%=NextPage %>">
        下一页</a>
    <a class="button bg-color-greenLight" href="<%=LastPage %>">
        尾页</a>
    <span>共<strong><%=RecordCount %></strong>条记录--第<strong><%=PageIndex %></strong>页--共<strong><%=PageCount %>页</strong></span>
</div>
