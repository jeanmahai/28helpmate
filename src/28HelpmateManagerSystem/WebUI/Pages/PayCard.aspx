<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="PayCard.aspx.cs" Inherits="WebUI.Pages.PayCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div>
        <div class="input-control select">
            <span class="label">卡类型</span>
            <select>
                
            </select>
        </div>
        <div class="input-control number">
            <span class="label">生成张数</span>
            <input type="number" placeholder="请输入生成卡的张数"/>
            <button class="btn-clear"></button>
        </div>
    </div>
</asp:Content>
