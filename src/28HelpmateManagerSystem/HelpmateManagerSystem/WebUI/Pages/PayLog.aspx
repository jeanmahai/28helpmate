<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayLog.aspx.cs" Inherits="WebUI.Pages.PayLog" %>

<%@ Import Namespace="WebUI.Utility" %>
<%@ Register Src="../UserControls/UCPager.ascx" TagName="UCPager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <form runat="server">
    <div>
        <h2>
            充值记录查询</h2>
        <table class="no-border-all">
            <tr>
                <td class="span2">
                    充值开始时间
                </td>
                <td class="span4">
                    <div class="input-control text">
                        <input type="text" data-role="datepicker" id="dateFrom" value="<%=From==null?"":From.Value.ToShortDateString() %>" />
                    </div>
                </td>
                <td class="span2">
                    充值结束时间
                </td>
                <td class="span4">
                    <div class="input-control text">
                        <input type="text" data-role="datepicker" id="dateTo" value="<%=To==null?"":To.Value.ToShortDateString() %>" />
                    </div>
                </td>
                <td>
                    <a class="button bg-color-blueDark fg-color-blueLight" href="<%=UrlHelper.GetPageUrl(Request.Url.ToString()) %>" onclick="pageChange(this);return false;">
                        查询</a>
                </td>
            </tr>
        </table>
    </div>
    <table class="striped hovered bordered">
        <thead>
            <tr class="bg-color-teal">
                <th>
                    系统编号
                </th>
                <th>
                    充值卡卡号
                </th>
                <th>
                    用户名
                </th>
                <th>
                    充值时间
                </th>
                <th>
                    充值IP
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptDataList">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("SysNo")%>
                        </td>
                        <td>
                            充值卡卡号 <%#Eval("CardSysNo")%>
                        </td>
                        <td>
                            用户名 <%#Eval("UserID")%>
                        </td>
                        <td>
                            充值时间 <%#Eval("StrInDate")%>
                        </td>
                        <td>
                            充值IP <%#Eval("IP")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <uc1:UCPager ID="UCPager1" runat="server" />
    </form>
    <script type="text/javascript">
        function pageChange(tag) {
            var me = $(tag);
            var href = me.attr("href");
            var params = [];
            var from = $.trim($("#dateFrom").val());
            if (from != "") params.push("from=" + from);
            var to = $.trim($("#dateTo").val());
            if (to != "") params.push("to=" + to);
            if (params.length > 0) href += "?" + params.join("&");
            window.location.href = href;
        }
    </script>
</asp:Content>
