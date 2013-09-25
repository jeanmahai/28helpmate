<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="WebUI.Pages.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmChangePsw" runat="server">
    <div>
        <h2>
            密码修改</h2>
        <div class="input-control password">
            <input type="password" runat="server" id="OldPsw" placeholder="旧密码" style="display: inline-block;" />
            <button type="button" tabindex="-1" class="btn-reveal" />
        </div>
        <div class="input-control password">
            <input type="password" runat="server" id="NewPsw" placeholder="新密码" />
            <button type="button" tabindex="-1" class="btn-reveal" />
        </div>
        <button id="btnOK" runat="server" class="image-button bg-color-darken fg-color-white">
            确认<img src="/res/img/check.png" />
        </button>
    </div>
    </form>
</asp:Content>
