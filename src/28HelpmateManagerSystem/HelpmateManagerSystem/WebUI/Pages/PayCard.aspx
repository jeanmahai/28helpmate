<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayCard.aspx.cs" Inherits="WebUI.Pages.PayCard" %>
<%@ Import Namespace="WebUI.Utility" %>

<%@ Register Src="../UserControls/UCPager.ascx" TagName="UCPager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div>
        <form id="frmPayCard" runat="server">
        <div>
            <h2>
                创建充值卡</h2>
            <div class="span12">
                <table class="border">
                    <tr>
                        <td class="span2">
                            卡类型
                        </td>
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
                        <td class="span2">
                            生成张数
                        </td>
                        <td>
                            <div class="input-control text ">
                                <input type="text" runat="server" id="numCount" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                            有效期起
                        </td>
                        <td>
                            <div class="input-control text">
                                <input type="text" runat="server" id="dateFrom" data-role="datepicker" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                            有效期止
                        </td>
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
                            <button class="bg-color-blueDark fg-color-blueLight" runat="server" id="btnSave">
                                保存</button>
                            <input type="reset" value="取消" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div >
            <table class="no-border-all">
                <tbody>
                    <tr>
                        <td class="span1">
                            卡类型
                        </td>
                        <td class="span2">
                            <div class="input-control select">
                                <select id="sCate2">
                                    <option value="-1">全部</option>
                                    <option value="1">天</option>
                                    <option value="1">月</option>
                                </select>
                            </div>
                        </td>
                        <td class="span1">
                            状态
                        </td>
                        <td class="span2">
                            <div class="input-control select">
                                <select id="sStatus">
                                    <option value="-1">全部</option>
                                    <option value="0">无效</option>
                                    <option value="1">有效</option>
                                </select>
                            </div>
                        </td>
                        <td>
                            <a class="button bg-color-blueDark fg-color-blueLight" href="<%=UrlHelper.GetPageUrl(Request.Url.ToString()) %>" onclick="pageChange(this);return false;" >
                                查询</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="span1">
                            有效期起
                        </td>
                        <td class="span4">
                            <div class="input-control text ">
                                <input type="text" id="dateFrom2" data-role="datepicker" value="<%=From==null?"":From.Value.ToShortDateString() %>"/>
                            </div>
                        </td>
                        <td class="span1">
                            有效期止
                        </td>
                        <td class="span4">
                            <div class="input-control text">
                                <input type="text" id="dateTo2" data-role="datepicker" value="<%=To==null?"":To.Value.ToShortDateString() %>"/>
                            </div>
                        </td>
                        <td class="span2 right">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="hovered border mini">
                <thead>
                    <tr class="bg-color-teal">
                        <th>
                            编号
                        </th>
                        <th>
                            卡号
                        </th>
                        <th>
                            类型
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            生成时间
                        </th>
                        <th>
                            有效期起
                        </th>
                        <th>
                            有效期止
                        </th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptData" OnItemDataBound="rptData_DataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("SysNo")%>
                                </td>
                                <td>
                                    <%#Eval("PayCardID")%>
                                </td>
                                <td>
                                    <%#Eval("StrCategory")%>
                                </td>
                                <td>
                                    <%#Eval("StrStatus")%>
                                </td>
                                <td>
                                    <%#Eval("StrInDate")%>
                                </td>
                                <td>
                                    <%#Eval("StrBeginTime")%>
                                </td>
                                <td>
                                    <%#Eval("StrEndTime")%>
                                </td>
                                <td>
                                    <button class="bg-color-greenDark fg-color-blueLight" id="btnEnabled" runat="server" onserverclick="btnEnabled_ServerClick">
                                        启用</button>
                                    <button class="bg-color-purple fg-color-blueLight" id="btnDisabled" runat="server" onserverclick="btnDisabled_ServerClick">
                                        禁用</button>
                                    <button class="" id="btnDelete" runat="server" onserverclick="btnDelete_serverClick">
                                        删除</button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="8">
                            <uc1:UCPager ID="UCPager1" runat="server" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        </form>
    </div>
    <script type="text/javascript">
        $(function () {

            var cartType = '<%=CardType %>';
            $("#sCate2").find("option[value="+cartType+"]").attr("selected", "selected");
            var cartStatus = '<%=CardStatus %>';
            $("#sStatus").find("option[value=" + cartStatus + "]").attr("selected", "selected");
        });

        function pageChange(tag) {
            var me = $(tag);
            var href = me.attr("href");
            var params = [];
            var from = $.trim($("#dateFrom2").val());
            if (from != "") params.push("from=" + from);
            var to = $.trim($("#dateTo2").val());
            if (to != "") params.push("to=" + to);
            var cartType = $("#sCate2 option:selected").attr("value");
            params.push("type=" + cartType);
            var cartStatus = $("#sStatus option:selected").attr("value");
            params.push("status=" + cartStatus);
            if (params.length > 0) href += "?" + params.join("&");
            window.location.href = href;
        }
    </script>
</asp:Content>
