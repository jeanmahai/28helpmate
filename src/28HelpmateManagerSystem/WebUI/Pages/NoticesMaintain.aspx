<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="NoticesMaintain.aspx.cs" Inherits="WebUI.Pages.NoticesMaintain" %>
<%@ Import Namespace="WebUI.Utility" %>

<asp:Content ID="conPage" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmPayCard" runat="server">
    <div>
        <h2>新闻公告维护</h2>
        <div class="span12">
            <table class="border">
                <tr>
                    <td class="span2">卡类型</td>
                    <td>
                        <div class="input-control select ">
                            <select runat="server" id="sCate">
                                <option value="1">天</option>
                                <option value="1">月</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">生成张数</td>
                    <td>
                        <div class="input-control text ">
                            <input type="text" runat="server" id="numCount" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">有效期起</td>
                    <td>
                        <div class="input-control text">
                            <input type="text" runat="server" id="dateFrom" data-role="datepicker" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">有效期止</td>
                    <td>
                        <div class="input-control text ">
                            <input type="text" runat="server" id="dateTo" data-role="datepicker" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">
                    </td>
                    <td>
                        <button class="bg-color-blueDark fg-color-blueLight" runat="server" id="btnSave">保存</button>
                        <input type="reset" value="取消" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</asp:Content>
