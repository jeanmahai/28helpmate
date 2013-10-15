<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="NoticesMaintain.aspx.cs" Inherits="WebUI.Pages.NoticesMaintain" %>
<%@ Import Namespace="WebUI.Utility" %>

<asp:Content ID="conPage" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmPayCard" runat="server">
    <div>
        <h2>新闻公告维护</h2>
        <div class="span12">
            <table class="border">
                <tr>
                    <td class="span2">公告内容：</td>
                    <td>
                        <div class="input-control text ">
                            <asp:TextBox ID="txtContents" TextMode="MultiLine" Width="750px" Height="100px" runat="server"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">优先级：</td>
                    <td>
                        <div class="input-control text">
                            <input type="text" runat="server" id="txtRank" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">
                    </td>
                    <td>
                        <asp:HiddenField ID="hidSysNo" runat="server" />
                        <button class="bg-color-blueDark fg-color-blueLight" runat="server" id="btnSave">保存</button>
                        <input type="reset" value="取消" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</asp:Content>
